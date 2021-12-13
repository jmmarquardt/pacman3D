using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public int p1Score = 0;
    public int p2Score = 0;
    public int highScore = 0;
    public int credits = 3;
    public TextMeshProUGUI player1ScoreText;
    public TextMeshProUGUI player2ScoreText;
    public TextMeshProUGUI HighScoreText;
    public TextMeshProUGUI CreditsText;

    // make this static so it's visible across all instances
	public static ScoreManager instance = null;
	public static int currentLevel = 1;
    // Sound sources
    private AudioSource chompSound;
    private AudioSource deathSound;
    private AudioSource music;
    
    private int numPellets = 142;

    // singleton pattern; make sure only one of these exists at one time, else we will
	// get an additional set of sounds with every scene reload, layering on the music
	// track indefinitely
    void Awake()
    {
        if (instance == null) {
			instance = this;
			DontDestroyOnLoad(gameObject);
		} else if (instance != this) {
			Destroy(gameObject);
		}
        p1Score = 0;
        p2Score = 0;
        highScore = 0;
        credits = 3;
    }

    void Start() 
    {
        chompSound = instance.GetComponents<AudioSource>()[0];
        deathSound = instance.GetComponents<AudioSource>()[1];
        music = instance.GetComponents<AudioSource>()[2];
    }

    // Update is called once per frame
    void Update()
    {
        if (p1Score >= highScore) 
        {
            highScore = p1Score;
        }

        player1ScoreText.text = p1Score.ToString();
        player2ScoreText.text = p2Score.ToString();
        if (highScore == 0) 
        {
            HighScoreText.text = "00000";
        }
        else 
        {
            HighScoreText.text = highScore.ToString();
        }

        if (p1Score >= numPellets * 100) 
        {
            
        }
    }

    public void PelletEat() 
    {
        p1Score += 100;
        chompSound.Play();
    }

    public void PlayerDie()
    {
        if (credits > 0) 
        {
            deathSound.Play();
            credits -= 1;
            SceneManager.LoadScene("Play");
        }
        else
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        // update high score to p1Score, p2Score wwill be updated on later p2 implementation
        if (p1Score > highScore) 
        {
            highScore = p1Score;
        }

        p1Score = 0;
        p2Score = 0;
        credits = 3;
        SceneManager.LoadScene("Game Over");
    }
}
