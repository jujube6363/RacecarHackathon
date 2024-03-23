using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMScript : MonoBehaviour
{
    [SerializeField] private AudioClip MMsound;
    private AudioSource audioSource;
    private bool flag = false;
    public ManeuverObstacleScript obstacle;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < obstacle.edge && flag == false){
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = MMsound;
            audioSource.Play();
            flag = true;
            
        }

    }
}
