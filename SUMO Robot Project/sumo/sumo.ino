int flag=0;
int ms=1;
//***********motor**********//
#define motor_right_1          11
#define motor_right_2          10
#define motor_right_enable     9
#define motor_left_1           8
#define motor_left_2           7
#define motor_left_enable      6
#define fast                  200
#define slow                  150

//***********IR************//
#define white                  0
#define black                  1

#define ir_br_pin              A0
#define ir_fr_pin              A1
#define ir_fl_pin              A2
#define ir_bl_pin              A3

//********altrasonic**********//
#define echo_r                2
#define trig_r                3
#define echo_l                5
#define trig_l                4
#define echo_fl                A4
#define trig_fl                A5
int  distance_fl;
int  distance_l;
int distance_r;

int ir_fl;
int ir_fr;
int ir_bl;
int ir_br;



void init_motor(void)
{
  pinMode(motor_right_1,OUTPUT);
  pinMode(motor_right_2,OUTPUT);
  pinMode(motor_left_1,OUTPUT);
  pinMode(motor_left_2,OUTPUT);
  pinMode(motor_left_enable,OUTPUT);
  pinMode(motor_right_enable,OUTPUT);
}
void forward(int  speed)
{
  analogWrite(motor_left_enable,speed);
  analogWrite(motor_right_enable,speed);
  digitalWrite(motor_right_1,0);
  digitalWrite(motor_right_2,1);
  digitalWrite(motor_left_1,0);
  digitalWrite(motor_left_2,1);
}
void back(int speed)
{
  analogWrite(motor_left_enable,speed);
  analogWrite(motor_right_enable,speed);
  digitalWrite(motor_right_1,1);
  digitalWrite(motor_right_2,0);
  digitalWrite(motor_left_1,1);
  digitalWrite(motor_left_2,0);
}
void left(int speed)
{
  analogWrite(motor_left_enable,speed);
  analogWrite(motor_right_enable,speed);
  digitalWrite(motor_right_1,1);
  digitalWrite(motor_right_2,0);
  digitalWrite(motor_left_1,0);
  digitalWrite(motor_left_2,1);
}
void right(int speed)
{
  analogWrite(motor_left_enable,speed);
  analogWrite(motor_right_enable,speed);
  digitalWrite(motor_right_1,0);
  digitalWrite(motor_right_2,1);
  digitalWrite(motor_left_1,1);
  digitalWrite(motor_left_2,0);
}
void Stop(void)
{
  digitalWrite(motor_right_1,LOW);
  digitalWrite(motor_right_2,LOW);
  digitalWrite(motor_left_1,LOW);
  digitalWrite(motor_left_2,LOW);
}

void init_ir(void)
{
  pinMode(ir_fl_pin,INPUT);
  pinMode(ir_fr_pin,INPUT);
  pinMode(ir_bl_pin,INPUT);
  pinMode(ir_br_pin,INPUT);
}

void  read_ir()
{
  ir_fl=digitalRead(ir_fl_pin);
  ir_fr=digitalRead(ir_fr_pin);
  ir_bl=digitalRead(ir_bl_pin);
  ir_br=digitalRead(ir_br_pin);
}
void init_altra(void)
{
  pinMode(trig_l,OUTPUT);
  pinMode(trig_fl,OUTPUT);
  pinMode(trig_r,OUTPUT);
  pinMode(echo_l,INPUT);
  pinMode(echo_fl,INPUT);
  pinMode(echo_r,INPUT);

}
void distance (void)
{
    digitalWrite(trig_fl,LOW);
  delayMicroseconds(2);
  digitalWrite(trig_fl,HIGH);
  delayMicroseconds(10);
  digitalWrite(trig_fl,LOW);
      distance_fl=(pulseIn(echo_fl,HIGH))/58.8;
  digitalWrite(trig_r,LOW);
  delayMicroseconds(2);
  digitalWrite(trig_r,HIGH);
  delayMicroseconds(10);
  digitalWrite(trig_r,LOW);
      distance_r=(pulseIn(echo_r,HIGH))/58.8;
  digitalWrite(trig_l,LOW);
  delayMicroseconds(2);
  digitalWrite(trig_l,HIGH);
  delayMicroseconds(10);
  digitalWrite(trig_l,LOW);
    distance_l=(pulseIn(echo_l,HIGH))/58.8;
}


void setup() {
  // put your setup code here, to run once:
  init_motor();
  init_ir();
  init_altra();
  Stop();
  delay(5000);
  Serial.begin(9600);
  
}

void loop() {
  // put your main code here, to run repeatedly:
  read_ir();
  if((ir_fr==white)&&(ir_fl==black)&&(ir_bl==black)&&(ir_br==black))
  {
    back(fast);
    delay(500);
    left(slow);
   // Serial.println("111111111111111");
  }else if((ir_fr==black)&&(ir_fl==white)&&(ir_bl==black)&&(ir_br==black))
  {
    back(fast);
    delay(500);
    right(slow);
   // Serial.println("2222222222222222222222");
  }else if((ir_fr==white)&&(ir_fl==white)&&(ir_bl==black)&&(ir_br==black))
  {
    back(fast);
    delay(500);
    //Serial.println("3333333333333333333");
  }else if((ir_fr==black)&&(ir_fl==black)&&(ir_bl==black)&&(ir_br==white))
  {
    forward(fast);
    delay(500);
    left(slow);
    //Serial.println("44444444444444444");
  }else if((ir_fr==back)&&(ir_fl==white)&&(ir_bl==white)&&(ir_br==black))
  {
    right(slow);
    delay(500);
    forward(fast);
    //Serial.println("55555555555555555");
    
  }
  else if((ir_fr==black)&&(ir_fl==black)&&(ir_bl==white)&&(ir_br==black))
  {
    back(fast);
    delay(500);
    right(slow);
   // Serial.println("666666666666666");
  }
  else if((ir_fr==white)&&(ir_fl==black)&&(ir_bl==black)&&(ir_br==white))
  {
    left(slow);
    delay(500);
    forward(fast);
    //Serial.println("77777777777777777");
    
  }else if((ir_fr==black)&&(ir_fl==black)&&(ir_bl==white)&&(ir_br==white))
  {
    forward(fast);
    delay(500);
    left(slow);
    //Serial.println("888888888888888888");
  }else
  {
   // Serial.println("wait for attack");
  //right(slow);
   distance();
   
  if(distance_fl<=30)
  {
    forward(fast);
    //Serial.println("go forward ");
  }
  else if(distance_r<=30)
  {
    right(fast);
    flag=1;
    //Serial.println("go right");
  }
  else if(distance_l<=30)
  {
    left(fast);
    flag=0;
    //Serial.println("go left");
  }
  else
  {
    flag?right(slow):left(slow);
    //Serial.println("rotate");
  }
 }if((millis()/1000)>ms)
 {Serial.print("distance fl : ");
 Serial.println(distance_fl);
 Serial.print("distance l : ");
 Serial.println(distance_l);
  Serial.print("distance r : ");
 Serial.println(distance_r);
 Serial.print("ir forward left : ");
 Serial.println(ir_fl);
 Serial.print("ir_forward right : ");
 Serial.println(ir_fr);
  Serial.print("ir_back left: ");
 Serial.println(ir_bl);
   Serial.print("ir_back right: ");
 Serial.println(ir_br);
 ms++;}
}
