using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Highscore;

    public Animator ScoreAnimation;

    public AudioSource audioSource;
    public int score;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = score.ToString();
        audioSource.Play();

    }

    void Update()
    {
        audioSource.volume = StaticSettings.MusicSound / 2;
    }

    public void updateScore()
    {
        score++;
        scoreText.text = score.ToString();
        ScoreAnimation.SetTrigger("Scoreup");
        StaticSettings.CurrentScore = score;


        if (score > StaticSettings.MaxScore)
        {
            StaticSettings.MaxScore = score;
        }

    }

    public void restartGame()
    {
        StaticSettings.isGameFreezed = true;
        SceneManager.LoadScene("SampleScene");
    }





}
