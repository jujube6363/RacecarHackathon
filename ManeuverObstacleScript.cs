using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;

public class ManeuverObstacleScript : MonoBehaviour
{
    [SerializeField] private AudioClip MMsound;
    private AudioSource audioSource;
    public string receivedstring;
    public CarScript carscript;
    public Rigidbody2D myRigidBody;
    public float edge = 35;
    public LogicScript logicscript;


    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        //audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        try {
            // (float)int.Parse(data_stream.ReadLine());
            //audioSource.clip = MMsound;
            //audioSource.Play();
            float motorIn = carscript.motorIn;

            float angle = carscript.angle;
            
            double xVel = Math.Cos(angle*Math.PI/180);
            double yVel = Math.Sin(angle*Math.PI/180);
            Vector3 velocitys = new Vector3(-1 * (float)xVel, (float)yVel * 0, 0);

            velocitys *= motorIn;
            if(!logicscript.carIsAlive) velocitys = new Vector3(0,0,0);
            myRigidBody.velocity = velocitys;



        } catch (Exception e) {
            Debug.Log(e);
        }
    }
}
