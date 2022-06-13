using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class Serial : MonoBehaviour
{
    SerialPort sp;

    float next_time;

    int ii = 0;

    // Use this for initialization
    void Start()
    {
        string the_com = "COM8";
        next_time = Time.time;

        foreach (string mysps in SerialPort.GetPortNames())
        {
            print (mysps);
            if (mysps != "COM1")
            {
                the_com = mysps;
                break;
            }
        }
        sp = new SerialPort("\\\\.\\" + the_com, 115200);
        if (!sp.IsOpen)
        {
            print("Opening " + the_com + ", baud 115200");
            sp.Open();
            sp.ReadTimeout = 100;
            sp.Handshake = Handshake.None;
            if (sp.IsOpen)
            {
                print("Open");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if (Time.time > next_time)
        // {
        //     if (!sp.IsOpen)
        //     {
        //         sp.Open();
        //         print("opened sp");
        //     }
        //     if (sp.IsOpen)
        //     {
        //         print("Writing " + ii);
        //         sp.Write((ii.ToString()));
        //     }
        //     next_time = Time.time + 5;
        //     if (++ii > 9) ii = 0;
        // }
    }

    public void Vibrate()
    {
        // Write something to the serial port
        if (!sp.IsOpen)
        {
            sp.Open();
            print("opened sp");
        }
        if (sp.IsOpen)
        {
            print("Writing " + ii);
            sp.Write((ii.ToString()));
        }
    }
}
