void initFile(){

};

void setup(){
  pinMode(LED_BUILTIN, OUTPUT);
}

void loop(){
  digitalWrite(LED_BUILTIN, HIGH);
  delay(getRandom());
  digitalWrite(LED_BUILTIN, LOW);
  delay(300);
}

int getRandom(){
  return random(10, 2000);
}
