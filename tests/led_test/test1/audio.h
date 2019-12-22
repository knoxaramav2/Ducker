const unsigned audioStreamSize = 512;

void initAudio(int);

void clearAudioStream();
void playToneArray(int, int[], int, int);
bool appendByteToAudioStream(byte c);
