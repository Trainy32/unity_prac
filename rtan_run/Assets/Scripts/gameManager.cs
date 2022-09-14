using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public static gameManager I;

    void Awake()
    {
        I = this;
    }
    
    public GameObject rain;
    public Text scoreText;
    public Text timeText;
    public GameObject pannel;

    int totalScore = 0;
    float limit = 10.0f;

    void initGame()
    {
        Time.timeScale = 1.0f;
        totalScore = 0;
        limit = 10.0f;
    }

    public void addScore(int score)
    {
        totalScore += score;
        scoreText.text = totalScore.ToString();
    }

    public void retry()
    {
        SceneManager.LoadScene("MainScene");
    }


    void makeRain()
    {
        // 복사한다(이프리팹을)
        Instantiate(rain);
    }

    // Start is called before the first frame update
    void Start()
    {
        // 실행할 함수, 시작전 딜레이, 인터벌
        InvokeRepeating("makeRain", 0, 0.5f);
        initGame();
    }

    // Update is called once per frame
    void Update()
    {
        limit -= Time.deltaTime;

        if (limit < 0)
        {
            limit = 0.0f;
            pannel.SetActive(true);
            Time.timeScale = 0.0f;
        }

        timeText.text = limit.ToString("N2");
    }
}