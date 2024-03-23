using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxScript : MonoBehaviour
{
        public CarScript carscript;
        public LogicScript logic;   
        public RoadScript roadscript;

    // Start is called before the first frame update
    void Start()
    {
                logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision){
    
   logic.gameOver();
      //carscript.carIsAlive = false;
      carscript.myRigidBody.velocity = new Vector3(0, 0, 0);
      roadscript.myRigidBody.velocity = new Vector3(0, 0, 0);
    }
}
