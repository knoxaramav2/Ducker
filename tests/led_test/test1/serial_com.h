#ifndef SERIAL_COM
#define SERIAL_COM

//#include <Serial.h>

#include "quackcom.h"

#define COMM_BUFFER_SIZE 128
#define META_WIDTH 4

#define COM_STATE_IDLE          0
#define COM_STATE_LISTEN_BURST  1
#define COM_STATE_LISTEN_STREAM 2
#define COM_STATE_TALKING       3

#define COM_ERR_SERIAL_UNAVAILABLE    -10
#define COM_ERR_SERIAL_EMPTY          -11

const char END_STREAM_SEQ [] = "\n\n\n";

void initComms();

//checks for available communication
//returns 0 if serial buffer is empty
//return the first byte and saves up to next three otherwise
//metadata and op code are reset with each call
byte checkSerial();
bool isInReadState();
bool startListenMode(short mode, short expectedStreamSize);
bool isTaskCompleted();
void sendBuffered();
int readNext();

void endListenMode();
void clearListenMode();

#endif
