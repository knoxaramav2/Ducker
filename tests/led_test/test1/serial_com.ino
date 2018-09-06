#define META_WIDTH 4

byte _buffer[COMM_BUFFER_SIZE];
byte _meta[META_WIDTH];//opcode meta meta meta
short _comState = COM_STATE_IDLE;
unsigned _expectedStreamSize = 0;//set to -1 for unknown stream size
unsigned _bytesReadCounter = 0;//used to track bytes read in current exchange

void initComms(){
  Serial.begin(9600);
  memset(_buffer, 0, COMM_BUFFER_SIZE);
  memset(_meta, 0, META_WIDTH);
}

void clearMeta(){
  memset(_meta, 0, META_WIDTH);
}

byte checkSerial(){
  if (Serial.available() == 0){
    return 0;
  }

  clearMeta();
  clearListenMode();

  Serial.write("VALUE RECEIVED\n");

  delay(100);

  for (int i = 0; i < COMM_BUFFER_SIZE && Serial.available() > 0; ++i){
    _meta[i] = Serial.read();
    _bytesReadCounter++;

    Serial.write(_meta[i]);

    if (_meta[i] == '\n') {break;}
  }

  Serial.write(_meta, _bytesReadCounter);
  delay(100);

  Serial.write("VALUE SAVED\n");

  return _meta[0]; 
}

bool startListenMode(short mode, short expectedStreamSize){
  if (_comState != COM_STATE_IDLE){
    return false;
  }

  if (mode == COM_STATE_LISTEN_BURST ||
      mode == COM_STATE_LISTEN_STREAM){
        _expectedStreamSize = expectedStreamSize;
        _comState = mode;
        return true;
      }

  return false;
}

//set to idle mode and preserve data buffers
void endListenMode(){
  _comState = COM_STATE_IDLE;
}

//set to idle mode without preserving data buffers
void clearListenMode(){
  endListenMode();
  memset(_buffer, 0, COMM_BUFFER_SIZE);
  memset(_meta, 0, META_WIDTH);

  _expectedStreamSize = 0;
  _bytesReadCounter = 0;
}

bool isInReadState(){
  return (_comState == COM_STATE_LISTEN_BURST ||
      _comState == COM_STATE_LISTEN_STREAM); 
}

short getComState(){
  return _comState;
}

//returns number of bytes read
//automatically reverts to idle when no more data available
//returns error code on failure (err < 0)
int readNext(){

  if (Serial.available() == 0){
    return COM_ERR_SERIAL_EMPTY;
  }

  int bytesRead = 0;

  //switch for future extension
  switch(_comState){
    case COM_STATE_LISTEN_BURST:
    
    break;
    case COM_STATE_LISTEN_STREAM:
      
    break;
  }

  _bytesReadCounter += bytesRead;
  
  return 0;
}

byte getOpCode(){
  return _meta[0];
}

byte * getMetaData(){
  return _meta;
}

int writeNext(){
  
}
