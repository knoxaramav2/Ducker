const int led = 3;
int state = 0;

void setup() {
  Serial.begin(9600);
  pinMode(led, OUTPUT);
  Serial.write("Started");  
}

void loop()   

{   

    String data = Serial.readString();//Read the serial buffer as a string

        if(data.indexOf("ON")!=-1)//checks if it is "ON"

        {

            digitalWrite(led, HIGH); // Sets the led ON   

            state=0;// Sets the state value to 0

        }

        else if(data.indexOf("OFF")!=-1)//checks if it is "OFF"

        {  

            digitalWrite(led, LOW); //Sets the led OFF   

            state=0;// Sets the state value to 1

        }

        else if(data.indexOf("STATE")!=-1)//checks if it is "STATE"

        {

            Serial.write("state=");//Sends the state

            Serial.println(state);

        }

}   
