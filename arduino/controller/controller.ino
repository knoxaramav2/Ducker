

char header[]="START\0";
char footer[]="END\0";



void setup(){
  Serial.begin(9600);
  pinMode(13,OUTPUT);
  pinMode(8,OUTPUT);
  setupStreamService(250);
}

void loop(){
  if (Serial.available()){
    
    char * msg = readFlush();
    Serial.println(len(msg));
    Serial.println(msg);
    //writeSerial(header);
    //writeSerial(msg);
    //writeSerial(footer);
  }
}
