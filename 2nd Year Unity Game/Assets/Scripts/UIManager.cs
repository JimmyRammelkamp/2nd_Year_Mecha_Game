using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text ammo;

    public TMP_Text health;

    public TMP_Text time;

    public TMP_Text score;

    public GameObject gameover;

    public GameObject finished;
    
    public GameObject player;

    public GameObject gameManager;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ammo.text = "Ammo " + player.GetComponent<PlayerController>().ammo;
        health.text = "Health " + player.GetComponent<PlayerController>().health;
        time.text = "Time " + gameManager.GetComponent<GameManager>().time.ToString("F2");
        score.text = "Score " + gameManager.GetComponent<GameManager>().score;
    }

    public void Gameover()
    {
        gameover.SetActive(true);
    }

    public void Finished()
    {
        finished.SetActive(true);
        gameManager.GetComponent<GameManager>().PauseGame();
    }

   
}
