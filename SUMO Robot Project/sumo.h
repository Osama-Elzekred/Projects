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
