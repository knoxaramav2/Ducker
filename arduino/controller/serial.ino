#include <string.h>

#define END_TRANSMIT_ASCII 0x04

char * _cache;
char * _safeCache;
unsigned short _cacheSize;
unsigned short _streamIndex; 

void setupStreamService(unsigned short size){
  _cacheSize = size;
  _cache = new char[_cacheSize];
  _safeCache = new char[_cacheSize];
}

char * readFlush(){
  
}
