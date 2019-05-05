/*center = 8, right = 3, left = a1*/
#include <SoftwareSerial.h>  

int bluetoothTx = 0;  // TX-O pin of bluetooth mate, Arduino D2
int bluetoothRx = 1;  // RX-I pin of bluetooth mate, Arduino D3 //try this 

SoftwareSerial bluetooth(bluetoothTx, bluetoothRx);

const int ledPin =  13;     // LED pin

void setup() {
  Serial.begin(9600); //setup serial monitor, uncomment Serial.print()'s to debug
 

   //Quick Test 1: Check If LED and Motor Can Turn On
    

//  bluetooth.begin(115200);  // The Bluetooth Mate defaults to 115200bps
//  bluetooth.print("$");  // Print three times individually
//  bluetooth.print("$");
//  bluetooth.print("$");  // Enter command mode
//  delay(100);  // Short delay, wait for the Mate to send back CMDly Change the baudrate to 9600, no parity
//  // 115200 can be too fast at times for NewSoftSerial to relay the data reliably
  
  bluetooth.begin(9600);  // Start bluetooth serial at 9600
  pinMode(ledPin, OUTPUT); //visual feedback
  pinMode(3,OUTPUT);
  pinMode(8,OUTPUT);
  pinMode(15,OUTPUT);


}

void loop() {
  if(bluetooth.available())  // If the bluetooth sent any characters
  {

    
    // Send any characters the bluetooth prints to the serial monitor
    Serial.write((char)bluetooth.read());
    bluetooth.println("U,9600,N");  // Temporari
    digitalWrite(ledPin,200);


 
  }
  if(Serial.available())  // If stuff was typed in the serial monitor
  {
    //0= stop,1 = straight  2 = left, 3 = right
    // Send any characters the Serial monitor prints to the bluetooth
   char m = ((char)Serial.read());
   Serial.println(m);
     digitalWrite(13,HIGH);
     delay(2000);
     digitalWrite(13,LOW);
     
    if(m == '3'){ //right
      analogWrite(14,255);
      delay(2000);
      analogWrite(14 ,0);
    }
    if(m=='2'){ //left
      analogWrite(10,255);
      delay(2000);
      analogWrite(10,0);
     
     }
    if(m=='1'){ //center, straight
      analogWrite(12,255);
      delay(2000);
      analogWrite(12,0);
     
     }
    if(m=='0'){ //stop 
      analogWrite(10
      ,255);
      delay(2000);
      analogWrite(10,0);
      delay(1000);
      analogWrite(10,255);
      delay(2000);
      analogWrite(10,0);
     }
   

  }
}
