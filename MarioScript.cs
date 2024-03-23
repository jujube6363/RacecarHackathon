using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioScript : MonoBehaviour
{
    [SerializeField] private AudioClip Mariosound;
    private AudioSource audioSource;
    private bool flag = false;
    public ManeuverObstacleScript obstacle;
    // Start is called before the first frame update
    void Start()
    {
        // audioSource = GetComponent<AudioSource>();
        // audioSource.clip = MMsound;
        // audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < obstacle.edge && flag == false){
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = Mariosound;
            audioSource.Play();
            flag = true;
        }

    }
}
