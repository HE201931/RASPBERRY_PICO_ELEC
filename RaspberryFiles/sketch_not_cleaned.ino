#include <EEPROM.h>
#define SERIAL_BUFFER_SIZE 4096

byte data[SERIAL_BUFFER_SIZE];

enum PAYLOAD_HELPER : byte
{
  GET_DISTANCE_CAPTED =   0,
  SEND_TEXT =             1,
  GET_LIMIT_DISTANCE =    2,
  SET_LIMIT_DISTANCE =    3  
};

int address_b1 = 0x0;
int address_b2 = 0x1;
int address_b3 = 0x2;
int address_b4 = 0x3;

uint32_t current_distance_limit = 870;
/* 
 * Code d'exemple pour un capteur à ultrasons HC-SR04.
 https://www.carnetdumaker.net/articles/mesurer-une-distance-avec-un-capteur-ultrason-hc-sr04-et-une-carte-arduino-genuino/
 */

/* Constantes pour les broches */
const byte TRIGGER_PIN = 15; // Broche TRIGGER
const byte ECHO_PIN = 14;    // Broche ECHO
 
//DEMANDER SI ON PEUT SEPARER AFFICHEURS AU PROF

/* Constantes pour le timeout */
const unsigned long MEASURE_TIMEOUT = 25000UL; // 25ms = ~8m à 340m/s

/* Vitesse du son dans l'air en mm/us */
const float SOUND_SPEED = 340.0 / 1000;

//https://www.carnetdumaker.net/articles/utiliser-un-afficheur-7-segments-avec-une-carte-arduino-genuino/
//https://forum.arduino.cc/t/convert-a-float-to-a-series-of-bytes/176165/2

const byte ALIM_SEG_1 = 27;//PIN32 GP27 ALIM1
const byte ALIM_SEG_2 = 28;//PIN34 GP28 ALIM2

const byte PIN_SEGMENT_A = 22;// NUM GPIO PAS NUM PIN
const byte PIN_SEGMENT_B = 21;
const byte PIN_SEGMENT_C = 20;
const byte PIN_SEGMENT_D = 19;
const byte PIN_SEGMENT_E = 18;
const byte PIN_SEGMENT_F = 17;
const byte PIN_SEGMENT_G = 16;
const byte PIN_SEGMENT_DP = 26;


const byte LUT_ETATS_SEGMENTS[] =
{
  0b00111111,
  0b00000110,
  0b01011011,
  0b01001111,
  0b01100110,
  0b01101101,
  0b01111101,
  0b00000111,
  0b01111111,
  0b01101111,
  0b01110111,
  0b01111100,
  0b00111001,
  0b01011110,
  0b01111001,
  0b01110001
};


void affiche_chiffre_7seg(byte chiffre, byte dp) 
{
  /* Simple sécurité */
  if (chiffre > 15)
    return; // Accepte uniquement des valeurs de 0 à 15.

  /* Conversion chiffre -> états des segments */
  byte segments = LUT_ETATS_SEGMENTS[chiffre];

  digitalWrite(PIN_SEGMENT_A, bitRead(segments, 0));
  digitalWrite(PIN_SEGMENT_B, bitRead(segments, 1));
  digitalWrite(PIN_SEGMENT_C, bitRead(segments, 2));
  digitalWrite(PIN_SEGMENT_D, bitRead(segments, 3));
  digitalWrite(PIN_SEGMENT_E, bitRead(segments, 4));
  digitalWrite(PIN_SEGMENT_F, bitRead(segments, 5));
  digitalWrite(PIN_SEGMENT_G, bitRead(segments, 6));
  digitalWrite(PIN_SEGMENT_DP, dp);
}

int parse_mm(int mm_received)
{
  int cm = mm_received / 10;
  if(cm < 100)
  {
    int dizaine = cm / 10;
    int unite = cm - (dizaine * 10);
    affiche_chiffre_7seg(dizaine , 0);
    digitalWrite(27, LOW);
    digitalWrite(28, HIGH);
    delay(20);//25
    affiche_chiffre_7seg(unite , 0);
    digitalWrite(27, HIGH);
    digitalWrite(28, LOW);
  }
  if(cm >= 100)
  {
    int unite = cm / 100;//M
    int reste = (cm % 100) /10;
    affiche_chiffre_7seg(unite , 1);
    digitalWrite(27, LOW);
    digitalWrite(28, HIGH);
    delay(20);//25
    affiche_chiffre_7seg(reste , 0);
    digitalWrite(27, HIGH);
    digitalWrite(28, LOW);
  }
  return 0;
}
/** Fonction setup() */
void setup()
{
 
  /* Initialise le port série */
  Serial.begin(115200);
  EEPROM.begin(512);
  pinMode(10, OUTPUT);
  pinMode(11, OUTPUT);

  pinMode(22 ,OUTPUT);//POINT? 29 : GP22
  pinMode(16, OUTPUT);//21 : GP16
  digitalWrite(16, HIGH);

  pinMode(27, OUTPUT);// PIN32 GP27 ALIM1 = AFFICHER 1 
  digitalWrite(27, LOW);

  pinMode(28, OUTPUT);// PIN34 GP28 ALIM2 = AFFICHER 2
  digitalWrite(28, HIGH);
  
  pinMode(PIN_SEGMENT_A, OUTPUT);
  digitalWrite(PIN_SEGMENT_A, HIGH); 
  pinMode(PIN_SEGMENT_B, OUTPUT);
  digitalWrite(PIN_SEGMENT_B, HIGH);
  pinMode(PIN_SEGMENT_C, OUTPUT);
  digitalWrite(PIN_SEGMENT_C, HIGH);
  pinMode(PIN_SEGMENT_D, OUTPUT);
  digitalWrite(PIN_SEGMENT_D, HIGH);
  pinMode(PIN_SEGMENT_E, OUTPUT);
  digitalWrite(PIN_SEGMENT_E, HIGH);
  pinMode(PIN_SEGMENT_F, OUTPUT);
  digitalWrite(PIN_SEGMENT_F, HIGH);
  pinMode(PIN_SEGMENT_G, OUTPUT);
  digitalWrite(PIN_SEGMENT_G, HIGH);
  pinMode(PIN_SEGMENT_DP, OUTPUT);
  digitalWrite(PIN_SEGMENT_DP, HIGH);

  /* Initialise les broches */
  pinMode(TRIGGER_PIN, OUTPUT);
  digitalWrite(TRIGGER_PIN, LOW); // La broche TRIGGER doit être à LOW au repos
  pinMode(ECHO_PIN, INPUT);

  digitalWrite(10, LOW);
  digitalWrite(11, LOW);
  
  get_limit_distance();
} 
 
/** Fonction loop() */
void loop()
{
  /* 1. Lance une mesure de distance en envoyant une impulsion HIGH de 10µs sur la broche TRIGGER */
  
  digitalWrite(TRIGGER_PIN, HIGH);
  delayMicroseconds(10);
  digitalWrite(TRIGGER_PIN, LOW);
  
  /* 2. Mesure le temps entre l'envoi de l'impulsion ultrasonique et son écho (si il existe) */
  long measure = pulseIn(ECHO_PIN, HIGH, MEASURE_TIMEOUT);
   
  /* 3. Calcul la distance à partir du temps mesuré */
  float distance_mm = measure / 2.0 * SOUND_SPEED;
   
  /* Affiche les résultats en mm, cm et m */
  
  /*Serial.print(F("Distance: "));
  Serial.print(distance_mm);
  Serial.print(F("mm ("));
  Serial.print(distance_mm / 10.0, 2);
  Serial.print(F("cm, "));
  Serial.print(distance_mm / 1000.0, 2);
  Serial.println(F("m)"));
   
  Serial.println(distance_mm);*/

  if(distance_mm <= current_distance_limit)
  {
    digitalWrite(10, LOW); //ROUGE
    digitalWrite(11, HIGH);  //VERTE
    digitalWrite(11, LOW);  //VERTE
    delay(20);//25
    digitalWrite(11, HIGH);  //VERTE
  }
  else
  {
    digitalWrite(10, HIGH);
    digitalWrite(11, LOW); 
  }

  parse_mm(distance_mm);

  if(Serial.available() > 0)
  {
    int rlen = Serial.readBytes(data, 4096);    
    PAYLOAD_HELPER payload_type = (PAYLOAD_HELPER)data[0];

    switch(payload_type)
    {
      case SEND_TEXT:
        send_text_serial_port("Arduino");      
        break;
        
      case SET_LIMIT_DISTANCE:
        set_limit_distance(new byte[4]{data[4], data[3], data[2], data[1]});
        break;

      case GET_LIMIT_DISTANCE:
        get_current_limit_distance();
        break;
    }
     memset(data, 0, SERIAL_BUFFER_SIZE);
  }
  get_current_limit_distance();
  delay(20);//25
  send_mm_distance(distance_mm);
}

int send_mm_distance(int mm_distance)
{
  byte buffer_return[9];
  buffer_return[0] = GET_DISTANCE_CAPTED;
  buffer_return[1] = (mm_distance >> 24) & 0xFF;
  buffer_return[2] = (mm_distance >> 16) & 0xFF;
  buffer_return[3] = (mm_distance >> 8) & 0xFF;
  buffer_return[4] = (mm_distance >> 0) & 0xFF;

  Serial.write(buffer_return, 9);
  Serial.flush();  
  
  return 9;  
}

void set_limit_distance(byte new_distance[4])
{
  EEPROM.write(address_b1, new_distance[0]);
  EEPROM.write(address_b2, new_distance[1]);
  EEPROM.write(address_b3, new_distance[2]);
  EEPROM.write(address_b4, new_distance[3]);  
  EEPROM.commit();
  get_limit_distance();
}

void get_limit_distance()
{
  current_distance_limit = (uint32_t) EEPROM.read(address_b1) << 24;
  current_distance_limit |=  (uint32_t) EEPROM.read(address_b2) << 16;
  current_distance_limit |= (uint32_t) EEPROM.read(address_b3) << 8;
  current_distance_limit |= (uint32_t) EEPROM.read(address_b4); 

  get_current_limit_distance();
}

int get_current_limit_distance()
{
  byte buffer_return[5];
  buffer_return[0] = GET_LIMIT_DISTANCE;
  buffer_return[1] = (current_distance_limit >> 24) & 0xFF;
  buffer_return[2] = (current_distance_limit >> 16) & 0xFF;
  buffer_return[3] = (current_distance_limit >> 8) & 0xFF;
  buffer_return[4] = (current_distance_limit >> 0) & 0xFF;
  
  Serial.write(buffer_return, 5);
  Serial.flush();  
  
  return 5;  
}

int send_text_serial_port(String text)
{  
    int buffer_return_size = 2 + text.length();

    int buffer_string_size = text.length() + 1;
    
    byte buffer_return[buffer_return_size];

    byte buffer_string[buffer_string_size];
    
    text.getBytes(buffer_string, buffer_string_size);
    
    buffer_return[0] = SEND_TEXT;

    for(int i = 0; i < buffer_string_size ; i++)
       buffer_return[i + 1] = buffer_string[i];

    Serial.write(buffer_return, buffer_return_size);
    Serial.flush();  
    return buffer_return_size;
}
