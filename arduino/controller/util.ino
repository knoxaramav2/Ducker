int len(char*str){
  int i = 0;
  for (;;++i){
    //Serial.println(*str);
    if ((*str++)=='\0')
      break;
  }

  return i;
}
