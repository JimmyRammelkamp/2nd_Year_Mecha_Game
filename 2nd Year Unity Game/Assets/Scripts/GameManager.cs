using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;

    public float time = 60;
    float startTime;

    public int score;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;

        if (time <= 0)
        {
            time = 0;
            GameOver();
        }
    }

    void GameOver()
    {
        GameObject.Find("UIManager").GetComponent<UIManager>().Gameover();
        PauseGame();
    }

    public void AddTime(float t)
    {
        time += t;
    }

    public void AddScore(int s)
    {
        score += s;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
