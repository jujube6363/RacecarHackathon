using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;

public class CarScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float angle;
    public float motorIn;
    public RoadScript roadscript;
    public LogicScript logic;   
    public BoxCollider boxcollider;
    public SerialPort data_stream = new SerialPort("COM5", 9600);
    public string receivedstring;

    // Start is called before the first frame update
    void Start()
    {
        //transform.Rotate(new Vector3(0, 0, 90));
        myRigidBody = GetComponent<Rigidbody2D>();
        boxcollider = GetComponent<BoxCollider>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        data_stream.Open();
        
    }

    void OnTriggerEnter(Collider oname){
        Debug.Log("entered collision with: something");
        myRigidBody.isKinematic = false;
        boxcollider.isTrigger = false;
    }

    void OnTriggerEnterStay(Collider oname){
        Debug.Log("entered collision with: something");
    }
    void OnTriggerEnterExit(Collider oname){
        Debug.Log("entered collision with: something");

    }


    // Update is called once per frame
    void Update()
    {  
        try {
            receivedstring = data_stream.ReadLine();
            string[] recData = receivedstring.Split(':', 2);
            // (float)int.Parse(data_stream.ReadLine());

            motorIn = (float)(int.Parse(recData[0]) * 1.4);
            motorIn *= (float)((150.0 - roadscript.roadXCoord + 150) / 150);
            float dialIn = int.Parse(recData[1]);
            Debug.Log(dialIn);
            angle = myRigidBody.transform.rotation.eulerAngles.z;
            
            double xVel = Math.Cos(angle*Math.PI/180);
            double yVel = Math.Sin(angle*Math.PI/180);
            Vector3 velocitys = new Vector3((float)xVel * 0, (float)yVel, 0);

            velocitys *= motorIn;
            
            myRigidBody.velocity = velocitys;


            dialIn /= 67;
            dialIn -= 5;
            dialIn *= 18;
            //transform.Rotate(new Vector3(0, 0, dialIn));
            if (!(dialIn + 90 < 2)) transform.rotation = Quaternion.Euler(0, 0, (float)dialIn);
        } catch (Exception e) {
            Debug.Log(e);
        }
       
    

    }
    // private void OnCollisionEnter2D(Collision2D collision){
    //     if (collision.gameObject.CompareTag("Obstacle")) {
    //         carIsAlive = false;
    //         Debug.Log("triggered by: " + collision);
    //         logic.gameOver();
    //     }
            
    // }
}
