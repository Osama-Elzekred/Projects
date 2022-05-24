#include<TimeLib.h>
int flag=0;
void delay_rain();
/*********sensors pin************/
#define rain_pin       10        //digital pin
#define moisture_pin   A0        //analog pin
#define LDR_pin        A1        //analog pin
#define temp_pin       A2        //analog pin
#define led_pin        13        //digital pin
#define pump_pin       12        //digital pin
/**************readings of sensors**********/
int moisture_reading;
int rain_reading;
int LDR_reading;
int temp_reading;

/**********private read for each sensor**********/
#define No_rain_state   1
#define raining_state    0
#define max_moisture    9
#define min_moisture    90
#define high_light      8
#define low_light        4
#define normal_temp     30

/********times for irrigation**********/
#define first_time  5
#define second_time 11
#define third_time  17



void setup() {
  // put your setup code here, to run once:
  pinMode(rain_pin,INPUT);
  pinMode(LDR_pin,INPUT);
  pinMode(moisture_pin,INPUT);
  pinMode(temp_pin,INPUT);
  pinMode(pump_pin,OUTPUT);
  pinMode(led_pin,OUTPUT);
}

void loop() {
  // put your main code here, to run repeatedly:
  rain_reading     = digitalRead(rain_pin);
  moisture_reading = analogRead(moisture_pin);
  LDR_reading      = analogRead(LDR_pin);
  temp_reading     = analogRead(temp_pin);
  /*********start timer*************/
  int hours=hour();
  int seconds=second();
  /***********Irrigation according to moisture reading************/
  if(moisture_reading <=min_moisture)
  {
    delay_rain(); 
  }
  /***********led (ON/OFF) according to ldr reading************/
  if(LDR_reading<=low_light)
  {
    digitalWrite(led_pin,HIGH);
  }
  else
  {
    digitalWrite(led_pin,LOW);
  }
  /***********set flag on to cancle next time for irrigation************/
  if(rain_reading==raining_state)
  {
    flag=1;
  }

  /*******irrigation according to temp reading*************/
  if(temp_reading>normal_temp)
  {
    //check if it's the time for irrigation 
    if(((hours==first_time)||(hours==third_time)||(hours == second_time))&&(moisture_reading<=max_moisture)&&(seconds<=30))
    { 
      if(flag==1)
      {
        flag=0;
        digitalWrite(pump_pin,LOW);
      }else
      {
        digitalWrite(pump_pin,HIGH);
      }
    }
    else
    {
      digitalWrite(pump_pin,LOW);
    }
  }
  else
  {
    if(((hours==first_time)||(hours==third_time))&&(moisture_reading<=max_moisture)&&(seconds<=30))
    {
      if(flag==1)
      {
        flag=0;
        digitalWrite(pump_pin,LOW);
      }else
      {
        digitalWrite(pump_pin,HIGH);
      }
    }else
    {
      digitalWrite(pump_pin,LOW);
    }
  }
}

/*******to turn on pump if (there is no rain)******/
void delay_rain()
{
  long t=millis();
  while(millis-t<30*1000)
  {
    digitalWrite(pump_pin,HIGH);
    if(rain_reading==raining_state)
    {
      digitalWrite(pump_pin,LOW);
      break;
    }
  }
}
