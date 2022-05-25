/* This code is Written by Rahul Bhatia
 * 
 */  

int LmotorUp = 7; //initialising Arduino port 10 be be called as LmotorUp
int LmotorDn = 6; //initialising Arduino port 11 be be called as LmotorDn
int RmotorUp = 8;  //initialising Arduino port 8 be be called as RmotorUp
int RmotorDn = 9;  //initialising Arduino port 9 be be called as RmotorDn
int left = 5;
int right = 10;

int L_speed=100;
int R_speed=100;
//#define motor1_1 8
//#define motor1_2 9
//#define motor1_pwm 10 //right
//#define motor2_1 7
//#define motor2_2 6
//#define motor2_pwm 5

void setup()
{
  Serial.begin(9600);
  // Setting ports as OUTPUTS as they supply signal values to motor driver
  pinMode(LmotorUp,OUTPUT); 
  pinMode(LmotorDn,OUTPUT);
  pinMode(RmotorUp,OUTPUT);
  pinMode(RmotorDn,OUTPUT);
  pinMode(left,OUTPUT);
  pinMode(right,OUTPUT);
  // Begining statement because i can :P add your robot name in the print statement
  Serial.println("Lotfy Welcomes you!"); 
  // A delay of 1 second for user 
  delay(1000);
} 
  

void loop()
{ 
  // Checking is Serial data available
  if(Serial.available()>0)
  {
    // Storing value of read data into variable assigned
    char input = Serial.read(); 
     
    Serial.println(input);
    switch(input)
    {
      // Calling respective functions if mathced with case label 
     case 'F' : MoveF(L_speed,R_speed); 
     break;
     // Here is it important to use '' as that stores the ASCII value is the letter in the variable you can add CAPITAL letters 
     case 'B' : MoveB(L_speed,R_speed); 
     break;
     case 'L' : MoveL(L_speed,R_speed); 
     break;
     case 'R' : MoveR(L_speed,R_speed);
     break;
     case 'S'  : Stop();
     break;
      case '1'  : L_speed+=5;
     break;
     case '2'  : L_speed-=5;
     break;
     case '3'  : R_speed+=5;
     break;
     case '4'  : R_speed-=5;
     break;
     default : break;
    }
  } 
  delay(50);
}

void MoveF(int L_speed,int R_speed)
{
  // Telling user that the robot will move forward
  Serial.println("Lotfy Forward");
  
  // We are writing a Digital HIGH to the upper left pin of the motor driver for postive polarity of 5V
  digitalWrite(LmotorUp,HIGH); 
  // We are writing a Digital LOW to the lower left pin of the motor driver for negative polarity of 0V
  digitalWrite(LmotorDn,LOW);
  // We are writing a Digital HIGH to the upper right pin of the motor driver for postive polarity of 5V
  digitalWrite(RmotorUp,HIGH); 
  // We are writing a Digital HIGH to the lower right pin of the motor driver for negative polarity of 0V
  digitalWrite(RmotorDn,LOW);
  // For entering speed to the pins
  analogWrite(left, L_speed);
  // We are writing a Digital LOW to the lower right pin of the motor driver
  analogWrite(right, R_speed);
  
  // As a result the robot will move forward
}

void MoveB(int L_speed,int R_speed)
{
  // Telling user that the robot will move backward
  Serial.println("Lotfy Backward");
  
  // Reversing the Digital HIGH/LOW for all the pins of the moto driver exact opposite of the forward function MoveF
  digitalWrite(LmotorUp,LOW); 
  digitalWrite(LmotorDn,HIGH);
  analogWrite(left, L_speed);
  digitalWrite(RmotorUp,LOW);
  digitalWrite(RmotorDn,HIGH);
  analogWrite(right, R_speed);
  
}



void MoveL(int L_speed,int R_speed)
{
  analogWrite(left,L_speed);
  analogWrite(right,R_speed);
  digitalWrite(RmotorUp,1);
  digitalWrite(RmotorDn,0);
  digitalWrite(LmotorUp,0);
  digitalWrite(LmotorDn,1);
}
void MoveR(int L_speed,int R_speed)
{
  analogWrite(left,L_speed);
  analogWrite(right,R_speed);
  digitalWrite(RmotorUp,0);
  digitalWrite(RmotorDn,1);
  digitalWrite(LmotorUp,1);
  digitalWrite(LmotorDn,0);
}



void Stop()
{
  // Telling user that the robot will move right
  Serial.println("Lotfy Stop!!");
  
  //Writing a digital LOW to all pins associated with movement of motor driver causes all motors to stop
  digitalWrite(LmotorUp,LOW);
  digitalWrite(LmotorDn,LOW);
  digitalWrite(RmotorUp,LOW);
  digitalWrite(RmotorDn,LOW);
  digitalWrite(right, 00);
  digitalWrite(left, 00);
  
  // Result robot will not move anywhere
}
