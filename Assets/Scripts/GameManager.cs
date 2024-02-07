using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button restartButton;
    public Button titleButton;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public bool gameOver;
    public float score;
    void Start()
    {
        gameOverText.enabled = false;
        restartButton.gameObject.SetActive(false);
        titleButton.gameObject.SetActive(false);
        gameOver = false;
        score = 0;
    }

    private void Update()
    {
        if (gameOver == false)
        {
            score += Time.deltaTime * 10;
            scoreText.text = "Score: " + (int)score;
        }
    }

    public void GameOver()
    {
        gameOverText.enabled = true;
        restartButton.gameObject.SetActive(true);
        titleButton.gameObject.SetActive(true);

        gameOver = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
    public void ToTitle()
    {
        SceneManager.LoadScene(0);
    }
  
    
}
