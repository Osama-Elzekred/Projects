package com.example.blutoothproj;

import android.annotation.SuppressLint;
import android.app.Activity;
import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.bluetooth.BluetoothSocket;
import android.content.Intent;
import android.os.Bundle;
import android.view.MotionEvent;
import android.view.View;
import android.widget.Button;
import android.widget.Toast;
import android.widget.TextView;
import androidx.appcompat.app.AppCompatActivity;

import java.io.IOException;
import java.io.OutputStream;
import java.util.Set;
import java.util.UUID;

public class MainActivity extends Activity {
    private final String DEVICE_ADDRESS = "00:21:07:00:29:FB"; //MAC Address of Bluetooth Module
    private final UUID PORT_UUID = UUID.fromString("00001101-0000-1000-8000-00805f9b34fb");

    private BluetoothDevice device;
    private BluetoothSocket socket;
    private OutputStream outputStream;
    Button left_speed_up;
    Button left_speed_down;
    Button right_speed_up;
    Button right_speed_down;
    TextView left_speed ;
    TextView right_speed ;
    Button forward_btn, forward_left_btn, forward_right_btn, reverse_btn, bluetooth_connect_btn,exit;

    char command = 'F'; //string variable that will store value to be transmitted to the bluetooth module
    int l_speed=100,R_speed=100;
    @SuppressLint({"ClickableViewAccessibility", "MissingPermission"})
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        BluetoothAdapter btAdapter = BluetoothAdapter.getDefaultAdapter();
        //declaration of button variables
        forward_btn = (Button) findViewById(R.id.forward_btn);
        forward_left_btn = (Button) findViewById(R.id.forward_left_btn);
        forward_right_btn = (Button) findViewById(R.id.forward_right_btn);
        reverse_btn = (Button) findViewById(R.id.reverse_btn);
        bluetooth_connect_btn = (Button) findViewById(R.id.bluetooth_connect_btn);
        left_speed_up = (Button)findViewById(R.id.left_speed_up);
        left_speed_down = (Button)findViewById(R.id.left_speed_down);
        right_speed_up = (Button)findViewById(R.id.right_speed_up);
        right_speed_down = (Button)findViewById(R.id.right_speed_down);
        exit = (Button)findViewById(R.id.exit);

        left_speed = (TextView) findViewById(R.id.left_speed);
        right_speed = (TextView) findViewById(R.id.right_speed);


        System.out.println(btAdapter.getBondedDevices());

        //OnTouchListener code for the forward button (button long press)
        forward_btn.setOnTouchListener(new View.OnTouchListener() {
            @SuppressLint("ClickableViewAccessibility")
            @Override
            public boolean onTouch(View v, MotionEvent event) {

                if (event.getAction() == MotionEvent.ACTION_DOWN) //MotionEvent.ACTION_DOWN is when you hold a button down
                {
                    command = 'F';

                    try
                    {
                        outputStream.write(command); //transmits the value of command to the bluetooth module
                    }
                    catch (IOException e)
                    {
                        e.printStackTrace();
                    }
                }
                else if(event.getAction() == MotionEvent.ACTION_UP) //MotionEvent.ACTION_UP is when you release a button
                {
                    command = 'S';
                    try
                    {
                        outputStream.write(command);
                    }
                    catch(IOException e)
                    {
                        e.printStackTrace();
                    }

                }

                return false;
            }

        });

        //OnTouchListener code for the reverse button (button long press)
        reverse_btn.setOnTouchListener(new View.OnTouchListener(){
            @Override
            public boolean onTouch(View v, MotionEvent event)
            {
                if(event.getAction() == MotionEvent.ACTION_DOWN)
                {
                    command ='B';

                    try
                    {
                        outputStream.write(command);
                    }
                    catch (IOException e)
                    {
                        e.printStackTrace();
                    }
                }
                else if(event.getAction() == MotionEvent.ACTION_UP)
                {
                    command = 'S';
                    try
                    {
                        outputStream.write(command);
                    }
                    catch(IOException e)
                    {
                        e.printStackTrace();
                    }
                }
                return false;
            }
        });

        //OnTouchListener code for the forward left button (button long press)
        forward_left_btn.setOnTouchListener(new View.OnTouchListener(){
            @Override
            public boolean onTouch(View v, MotionEvent event)
            {
                if(event.getAction() == MotionEvent.ACTION_DOWN)
                {
                    command = 'L';

                    try
                    {
                        outputStream.write(command);
                    }
                    catch (IOException e)
                    {
                        e.printStackTrace();
                    }
                }
                else if(event.getAction() == MotionEvent.ACTION_UP)
                {
                    command = 'S';
                    try
                    {
                        outputStream.write(command);
                    }
                    catch(IOException e)
                    {
                        e.printStackTrace();
                    }

                }
                return false;
            }
        });

        //OnTouchListener code for the forward right button (button long press)
        forward_right_btn.setOnTouchListener(new View.OnTouchListener(){
            @Override
            public boolean onTouch(View v, MotionEvent event)
            {
                if(event.getAction() == MotionEvent.ACTION_DOWN)
                {
                    command = 'R';

                    try
                    {
                        outputStream.write(command);
                    }
                    catch (IOException e)
                    {
                        e.printStackTrace();
                    }
                }
                else if(event.getAction() == MotionEvent.ACTION_UP)
                {
                    command = 'S';
                    try
                    {
                        outputStream.write( command);
                    }
                    catch(IOException e)
                    {
                        e.printStackTrace();
                    }

                }
                return false;
            }
        });

        left_speed_up.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                l_speed+=5;
                left_speed.setText("left speed is \n : "+String.valueOf(l_speed));
                command = '1';
                try
                {
                    outputStream.write(command);
                }
                catch(IOException e)
                {
                    e.printStackTrace();
                }

            }
        });
        left_speed_down.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                l_speed-=5;
                left_speed.setText("left speed is \n : "+String.valueOf(l_speed));
                command = '2';
                try
                {
                    outputStream.write(command);
                }
                catch(IOException e)
                {
                    e.printStackTrace();
                }

            }
        });
        right_speed_up.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                R_speed+=5;
                right_speed.setText("left speed is \n : "+String.valueOf(R_speed));
                command = '3';
                try
                {
                    outputStream.write(command);
                }
                catch(IOException e)
                {
                    e.printStackTrace();
                }

            }
        });
        right_speed_down.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                R_speed-=5;
                right_speed.setText("Right speed is \n : "+String.valueOf(R_speed));
                command = '4';
                try
                {
                    outputStream.write(command);
                }
                catch(IOException e)
                {
                    e.printStackTrace();
                }

            }
        });

        //Button that connects the device to the bluetooth module when pressed
        bluetooth_connect_btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                if(BTinit())
                {
                    BTconnect();
                }

            }
        });


        exit.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                finish();

            }
        });

    }

    //Initializes bluetooth module
    @SuppressLint("MissingPermission")
    public boolean BTinit()
    {
        boolean found = false;

        BluetoothAdapter bluetoothAdapter = BluetoothAdapter.getDefaultAdapter();

        if(bluetoothAdapter == null) //Checks if the device supports bluetooth
        {
            Toast.makeText(getApplicationContext(), "Device doesn't support bluetooth", Toast.LENGTH_SHORT).show();
        }

        if(!bluetoothAdapter.isEnabled()) //Checks if bluetooth is enabled. If not, the program will ask permission from the user to enable it
        {
            Intent enableAdapter = new Intent(BluetoothAdapter.ACTION_REQUEST_ENABLE);
            startActivityForResult(enableAdapter,0);

            try
            {
                Thread.sleep(1000);
            }
            catch(InterruptedException e)
            {
                e.printStackTrace();
            }
        }

        Set<BluetoothDevice> bondedDevices = bluetoothAdapter.getBondedDevices();

        if(bondedDevices.isEmpty()) //Checks for paired bluetooth devices
        {
            Toast.makeText(getApplicationContext(), "Please pair the device first", Toast.LENGTH_SHORT).show();
        }
        else
        {
            for(BluetoothDevice iterator : bondedDevices)
            {
                if(iterator.getAddress().equals(DEVICE_ADDRESS))
                {
                    device = iterator;
                    found = true;
                    break;
                }
            }
        }

        return found;
    }

    @SuppressLint("MissingPermission")
    public boolean BTconnect()
    {
        boolean connected = true;

        try
        {
            socket = device.createRfcommSocketToServiceRecord(PORT_UUID); //Creates a socket to handle the outgoing connection
            socket.connect();

            Toast.makeText(getApplicationContext(),
                    "Connection to bluetooth device successful", Toast.LENGTH_LONG).show();
        }
        catch(IOException e)
        {
            e.printStackTrace();
            connected = false;
        }

        if(connected)
        {
            try
            {
                outputStream = socket.getOutputStream(); //gets the output stream of the socket
            }
            catch(IOException e)
            {
                e.printStackTrace();
            }
        }

        return connected;
    }

    @Override
    protected void onStart()
    {
        super.onStart();
    }

}
