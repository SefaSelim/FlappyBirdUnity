using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject MusicOff;
    public GameObject MusicOn;
    public int score;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = score.ToString();
        audioSource.Play();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void musicOn()
    {
        MusicOff.SetActive(true);
        MusicOn.SetActive(false);
        audioSource.UnPause();

    }

    public void musicOff()
    {
        MusicOff.SetActive(false);
        MusicOn.SetActive(true);
        audioSource.Pause();

    }




}
