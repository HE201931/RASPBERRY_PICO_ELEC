/* 
|| AUTHOR Arsium ||
|| github : https://github.com/arsium       ||
*/

//https://www.arduino.cc/reference/en/language/functions/communication/serial/flush/
//https://www.arduino.cc/en/Reference.StringGetBytes
//https://www.arduino.cc/en/serial/write
//TODO IF TIME : sending size before sending payload
byte data[4096];

enum PAYLOAD_HELPER : byte
{
  GET_DISTANCE_CAPTED =   0,
  SEND_TEXT =             1,
  GET_LIMIT_DISTANCE =    2,
  SET_LIMIT_DISTANCE =    3  
};

void setup() 
{
  Serial.begin(115200);
}

void loop() 
{
  if(Serial.available() > 0)
  {
    int rlen = Serial.readBytes(data, 4096);    

    PAYLOAD_HELPER payload_type = (PAYLOAD_HELPER)data[0];

    switch(payload_type)
    {
      case SEND_TEXT:
        send_text_serial_port("Arduino");      
        break;
    }
    //Serial.write(data, 4096);
    //Serial.flush();
  }
  delay(10);
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
