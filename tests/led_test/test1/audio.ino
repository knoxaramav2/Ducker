//#include "audio.h"

byte audioStream [audioStreamSize];
int streamIndex;

void initAudio(){
  streamIndex = 0;
  clearAudioStream();
}

void clearAudioStream(){
  memset(audioStream, 0, audioStreamSize);
  streamIndex = 0;
}

void playToneArray(int pin, int toneArray [], int arraySize, int delayMs){
  for (int i = 0; i < arraySize; ++i){
    tone (pin, toneArray[i]);
    delay(delayMs);
  }

  noTone(pin);
}

bool appendByteToAudioStream(byte c){
  if (streamIndex == audioStreamSize){
    return false;
  }

  audioStream[streamIndex++] = c;
}

void playAudioStream(int pin, int delayMs){
  for (int i = 0; i < streamIndex; ++i){
    tone(pin, audioStream[i], delayMs);
  }

  noTone(pin);
  clearAudioStream();
}
