using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;

public class RoadScript : MonoBehaviour
{
    public string receivedstring;
    public CarScript carscript;
    public Rigidbody2D myRigidBody;
    public float roadXCoord;
    public LogicScript logicscript;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        try {

            // (float)int.Parse(data_stream.ReadLine());
            float motorIn = carscript.motorIn;
            //Debug.Log(motorIn);

            float angle = carscript.angle;
            
            double xVel = Math.Cos(angle*Math.PI/180);
            double yVel = Math.Sin(angle*Math.PI/180);
            Vector3 velocitys = new Vector3(-1 * (float)xVel, 0, 0);

            velocitys *= motorIn;
            if (!logicscript.carIsAlive) velocitys = new Vector3(0,0,0);
            myRigidBody.velocity = velocitys;
            Vector3 roadPos = new Vector3(GetComponent<Rigidbody2D>().position.x,0,0);
            GetComponent<Rigidbody2D>().position = roadPos;
            roadXCoord = GetComponent<Rigidbody2D>().position.x;

        } catch (Exception e) {
            Debug.Log(e);
        }
    }
}
