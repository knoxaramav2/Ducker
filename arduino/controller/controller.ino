/*
#include "headers/audio.h"
#include "headers/file.h"
#include "headers/motor.h"
#include "headers/comm.h"
*/

void setup(){
  Serial.begin(9600);
  pinMode(13,OUTPUT);
  pinMode(8,OUTPUT);
  setupStreamService(250);
}

void loop(){
  digitalWrite(13,HIGH);
  digitalWrite(8,LOW);
  writeSerial();
  delay(200);
  digitalWrite(13,LOW);
  digitalWrite(8,HIGH);
  delay(200);
}
