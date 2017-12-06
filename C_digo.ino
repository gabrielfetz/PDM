#define ledLuminosidade 13
#define ledTemperatura 12

#define luminosidade A0
#define temperatura A1

void setup() {
  // put your setup code here, to run once:
  pinMode(ledLuminosidade, OUTPUT);
  pinMode(ledTemperatura, OUTPUT);
    
  Serial.begin(9600);
}

void loop() {
  // put your main code here, to run repeatedly:
  String entrada = "";
  char c = "";
  if (analogRead(luminosidade) < 100) {
    digitalWrite(ledLuminosidade, HIGH);
  } else {
    digitalWrite (ledLuminosidade, LOW);
  }
  
  if ((analogRead((temperatura)) * 0.4887585532 > 23)) {
    digitalWrite(ledTemperatura, HIGH);
  } 
  else {
    digitalWrite(ledTemperatura, LOW);
  }

  while (Serial.available()) {
    c = Serial.read();
    entrada.concat(c);
  }

  if (entrada != "") {
    if (entrada == "t") {
      Serial.print("Temperatura: ");
      Serial.print((analogRead(temperatura)) * 0.4887585532);
      Serial.println(" C");
    } 
    else if (entrada == "l") {
      Serial.print("Luminosidade: ");
      Serial.println(analogRead(luminosidade));    
    } 
  }
     delay(50);
}
