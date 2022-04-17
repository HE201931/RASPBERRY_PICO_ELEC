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

const byte PIN_SEGMENT_A = 22;
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

  digitalWrite(PIN_SEGMENT_A, !bitRead(segments, 0));
  digitalWrite(PIN_SEGMENT_B, !bitRead(segments, 1));
  digitalWrite(PIN_SEGMENT_C, !bitRead(segments, 2));
  digitalWrite(PIN_SEGMENT_D, !bitRead(segments, 3));
  digitalWrite(PIN_SEGMENT_E, !bitRead(segments, 4));
  digitalWrite(PIN_SEGMENT_F, !bitRead(segments, 5));
  digitalWrite(PIN_SEGMENT_G, !bitRead(segments, 6));
  digitalWrite(PIN_SEGMENT_DP, !dp);
}

/** Fonction setup() */
void setup()
{
 
  /* Initialise le port série */
  Serial.begin(115200);
  
  pinMode(PIN_SEGMENT_A, OUTPUT);
  digitalWrite(PIN_SEGMENT_A, LOW);
  pinMode(PIN_SEGMENT_B, OUTPUT);
  digitalWrite(PIN_SEGMENT_B, LOW);
  pinMode(PIN_SEGMENT_C, OUTPUT);
  digitalWrite(PIN_SEGMENT_C, LOW);
  pinMode(PIN_SEGMENT_D, OUTPUT);
  digitalWrite(PIN_SEGMENT_D, LOW);
  pinMode(PIN_SEGMENT_E, OUTPUT);
  digitalWrite(PIN_SEGMENT_E, LOW);
  pinMode(PIN_SEGMENT_F, OUTPUT);
  digitalWrite(PIN_SEGMENT_F, LOW);
  pinMode(PIN_SEGMENT_G, OUTPUT);
  digitalWrite(PIN_SEGMENT_G, LOW);
  pinMode(PIN_SEGMENT_DP, OUTPUT);
  digitalWrite(PIN_SEGMENT_DP, LOW);

  /* Initialise les broches */
  pinMode(TRIGGER_PIN, OUTPUT);
  digitalWrite(TRIGGER_PIN, LOW); // La broche TRIGGER doit être à LOW au repos
  pinMode(ECHO_PIN, INPUT);
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
  Serial.print(F("Distance: "));
  Serial.print(distance_mm);
  Serial.print(F("mm ("));
  Serial.print(distance_mm / 10.0, 2);
  Serial.print(F("cm, "));
  Serial.print(distance_mm / 1000.0, 2);
  Serial.println(F("m)"));
   
  Serial.println(distance_mm);

  if(distance_mm >= 4)
  {
      digitalWrite(10, HIGH);    
  }

  //https://forum.arduino.cc/t/convert-a-float-to-a-series-of-bytes/176165/2
  byte chiffre = ((int)(((int)distance_mm & 0XFF))) /10;
  static byte etat_dp = 0;

  affiche_chiffre_7seg(chiffre, etat_dp);

  etat_dp = !etat_dp;

  delay(2000);
}