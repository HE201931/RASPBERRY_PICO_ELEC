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
    Serial.write(data, 4096);
    Serial.flush();
  }
  delay(10);
}
