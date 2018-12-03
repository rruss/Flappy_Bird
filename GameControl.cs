using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {
    public static GameControl Instance;

    public float scrollSpeed = -1.5f;
    public bool IsGameOver = false;
    public bool IsWin = false;
    public int score = 0;
    public Text scoretext;
    public GameObject GameOverText;
    public GameObject VictoryText;
	// Use this for initialization
	void Start () {
		if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
	}
	
	// Update is called once per frame
	void Update () {
		if(IsGameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
	}

    public void Score()
    {
        if (IsGameOver)
        {
            return;
        }
        score++;
        scoretext.text = "Score: " + score;
        if(score == 12)
        {
            Victory();
        }
    }
    public void Victory()
    {
        IsWin = true;
        VictoryText.SetActive(true);
    }

    public void Die()
    {
        IsGameOver = true;
        GameOverText.SetActive(true);
    }
}
