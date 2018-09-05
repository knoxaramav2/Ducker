int audPin = 12;
int ledPin = 13;
int phoPin = A0;

int numTones = 10;
int tones[] = {261, 277, 294, 311, 330, 349, 370, 392, 415, 440};
int photoVal = 0;

bool state = false;

char msgActive[] = "RESPONSE : HIGH\n\0";
char msgInActive[] = "RESPONSE : LOW\n\0";

char argStr [256];
char opCode;

bool dataReceived;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  pinMode(ledPin, OUTPUT);
  pinMode(phoPin, INPUT);
  digitalWrite(ledPin, HIGH);
  Serial.flush();

  memset(argStr, 0, 256);
  opCode = 0;
  dataReceived = false;
}

void receiveData(){
  if (Serial.available() == 0) {return;}

  int idx = 0;
  const char endMarker = '\n';
  char bff;

  opCode = Serial.read();

  while(Serial.available() > 0){
    bff = Serial.read();

    if (bff == endMarker){
      argStr[idx] = 0;
      dataReceived = true;//data not terminated by endMarker is ignored
      break;
    } else {
      argStr[idx++] = bff;
    }
  }
}

void toggleLED(){
  int from, to, delta;

  if (state){
    to = 0;
    from = numTones - 1;
    delta = -1;
  } else {
    to = numTones;
    from = 0;
    delta = 1;
  }
  
  Serial.read();
  noTone(audPin);
  
  state = !state;
  digitalWrite(ledPin, state ? HIGH: LOW);
  Serial.write(state?msgActive:msgInActive);

  for (int i = from; i != to; i += delta)
  {
   tone(audPin, tones[i]);
   delay(100);
  }

  noTone(audPin);
}

void processData(){

  switch(opCode){
    
    case 0: return;
    case 'T':
      Serial.println("Test Received\n");
    break;
    case 'L':
      toggleLED();
    break;
  }

    dataReceived = false;
    argStr[0] = 0;
    opCode = 0;
}

void loop() {  
  receiveData();
  processData();
}
