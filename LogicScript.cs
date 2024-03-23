using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO.Ports;
using System;

public class LogicScript : MonoBehaviour
{
    public GameObject gameOverText;
    public GameObject gameOverButton;
    public CarScript car;
    public bool carIsAlive = true;

    void Start() {
         gameOverText.SetActive(false);
         gameOverButton.SetActive(false);
    }
    public void restartGame(){
        car.data_stream.Write("2");
        car.data_stream.Close();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void gameOver(){
        Debug.Log("gameover called");
        car.data_stream.Write("1");
        carIsAlive = false;
        gameOverText.SetActive(true);
        gameOverButton.SetActive(true);
    }
    // Start is called before the first frame update
}
