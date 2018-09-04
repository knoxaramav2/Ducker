void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  pinMode(13, OUTPUT);
  digitalWrite(13, HIGH);
}

bool state = false;

void loop() {
  // put your main code here, to run repeatedly:
  if (Serial.available()){
    Serial.read();
    state = !state;
    digitalWrite(13, state ? HIGH: LOW);
    Serial.write("RESPONSE=");
    Serial.write(state?"TRUE":"FALSE");
    Serial.write("\n");
  }
}
