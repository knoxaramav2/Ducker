#include <Stepper.h>

const int stepsPerRev = 200;

Stepper stepper(stepsPerRev, 4,5,6,7);

const char msgClockwise [] = "Set Clockwise\n\0";
const char msgCounterClockwise [] = "Set CounterClockwise\n\0";

bool direction = true;

void initMotor(){
  stepper.setSpeed(60);
  direction = true;
  
  pinMode(4, OUTPUT);
  pinMode(5, OUTPUT);
  digitalWrite(4, HIGH);
  digitalWrite(5,HIGH);

  Serial.println("asdasdasd");
}

void setDirection(bool dir){

  direction = dir;

  char * msg = 0;
  int multiplier;

  if (dir){
    msg = msgClockwise;
    multiplier = 1;
  } else {
    msg = msgCounterClockwise;
    multiplier = -1;
  }

  stepper.step(stepsPerRev * multiplier);
  
  Serial.println(msg);
}

void toggleDirection(){
  setDirection(!direction);
}

void motorTest(){
  Serial.println("ASDASDASD");
}
