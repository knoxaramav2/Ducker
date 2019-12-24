#include <string.h>

byte * cache;
unsigned short cacheSize;

void setupStreamService(unsigned short size){
  cacheSize = size;
  cache = new byte[cacheSize];
}

void writeSerial(){
  Serial.write("XXX");
  Serial.flush();
}
