
int gLed = 10;
char val;
float newVal;

void setup() {  
   Serial.begin (9600);  
   pinMode(gLed, OUTPUT);     
   digitalWrite(gLed, LOW);
   Serial.begin(9600);
}

void loop() {
  if (Serial.available()) {
  val = Serial.read();   //data comes in over serial line as char, so need to convert char to float
  newVal = val - '0.000';    // ASCII value converted to numeric value, this is the accelerometer data
  //Serial.println(val);
  if (newVal >= 6){
    digitalWrite(gLed, HIGH);
  }
  else{
    digitalWrite(gLed, LOW);
  }
  
  //newVal = map(newVal, 0, 10, 0, 255);
  //analogWrite(gLed, newVal);
  //delay(200);
  }
}

