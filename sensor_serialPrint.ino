// Serial Print Format
// Temperature(float), Humidity(float), Light(%)(float), Aircontroller(bool), Humidifier(bool), LED(bool)

#include <dht.h>

dht DHT;

#define DHT11_PIN 7

void setup(){
  Serial.begin(9600);
  pinMode(A0, INPUT); //light_sensor
}

void loop(){
  bool airCon, humFier, led;
  float light = float(1023 - analogRead(A0))/1023*100;
  int chk = DHT.read11(DHT11_PIN);
  
  if (light < 20){led = true;}
  else{led = false;}
  if (DHT.temperature > 28){airCon = true;}
  else{airCon = false;}
  if (DHT.humidity > 50){humFier = true;}
  else{humFier = false;}
  
  String sensors = String(DHT.temperature)+","+String(DHT.humidity)+","+String(light);
  String actuators = String(airCon)+","+String(humFier)+","+String(led);
  String str_print = sensors+","+actuators;
  Serial.println(str_print);
  delay(1000);
}
