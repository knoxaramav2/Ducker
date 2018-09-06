#include <Stepper.h>

#include "motor.h"
#include "audio.h"
#include "serial_com.h"

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
  pinMode(ledPin, OUTPUT);
  pinMode(phoPin, INPUT);
  digitalWrite(ledPin, HIGH);

  memset(argStr, 0, 256);
  opCode = 0;
  dataReceived = false;

  initMotor();
  initAudio();
  initComms();
  setDirection(true);
}

void handleStream(){
  byte c = checkSerial();
  
  if (isInReadState()){
    //read from stream until end marker detected
    //Serial.write("In read state\n");
  } else if (c != 0 && c != '\n') {
    //test byte against command codes
    //Serial.write("Checking command\n");
    bool test = true;

    toggleLED();
    
    switch(c){
    case 'T':
      //Serial.write("Signal Received\n");
    break;
    case START_STREAM:
      test = startListenMode(COM_STATE_LISTEN_STREAM, -1);
    break;
    case YELL_COM:
      test = startListenMode(COM_STATE_LISTEN_BURST, 4);//[OP][META][META][META]
    break;
    case YELL_8:
      test = startListenMode(COM_STATE_LISTEN_BURST, 8);
    break;
    case YELL_32:
      test = startListenMode(COM_STATE_LISTEN_BURST, 32);
    break;
    case YELL_64:
      test = startListenMode(COM_STATE_LISTEN_BURST, 64);
    break;
    default:
      test = false;
      break;
    }

    if (test){
      delay(100);
      //Serial.write("Command Accepted\n");
    } else {
      delay(100);
      //Serial.write("Failed to interpret data\n"); 
    }
  }
}

void processData(){
  
}

void loop() {  
  handleStream();
}

void toggleLED(){
  state = !state;
  digitalWrite(ledPin, state ? HIGH: LOW);
  Serial.write(state?msgActive:msgInActive);

  playToneArray(audPin, tones, numTones, 100);
}
