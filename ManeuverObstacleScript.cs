using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;

public class ManeuverObstacleScript : MonoBehaviour
{
    public string receivedstring;
    public CarScript carscript;
    public Rigidbody2D myRigidBody;

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
            Debug.Log(motorIn);

            float angle = carscript.angle;
            
            double xVel = Math.Cos(angle*Math.PI/180);
            double yVel = Math.Sin(angle*Math.PI/180);
            Vector3 velocitys = new Vector3(-1 * (float)xVel, (float)yVel * 0, 0);

            velocitys *= motorIn;
            myRigidBody.velocity = velocitys;

        } catch (Exception e) {
            Debug.Log(e);
        }
    }
}
