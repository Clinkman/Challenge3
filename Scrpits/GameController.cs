using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public AudioSource musicSource1;
    public AudioClip Victory;
    public AudioSource musicSource2;
    public AudioClip Dead;
    public int number;

    public Text ScoreText;
    public Text RestartText;
    public Text GameOverText;
    public Text winText;
    public Text Timer;
    private bool Gameover;
    private bool Restart;
    private int score;

    void Start()
    {
        Gameover = false;
        Restart = false;
        GameOverText.text = "";
        RestartText.text = "";
        winText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    void Update()
    {
        if (Restart)
        {
            if(Input.GetKeyDown(KeyCode.Z))
            {
                SceneManager.LoadScene("Main");
            }
        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if(Gameover)
            {
                RestartText.text = "Press Z for Restart";
                Restart = true;
                if (Timer.text == "0")
                {
                    GameOverText.text = "Your final score is " + score;
                }
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        ScoreText.text = "Points: " + score;
        if (score >= 100 && number != 5 && number !=3)
        {
            winText.text = "You win! Game Created by Curtis Marcoux";
            Gameover = true;
            Restart = true;
            musicSource1.clip = Victory;
            musicSource1.Play();
        }
        if (score >= 250 && number == 3)
        {
            winText.text = "You win! Game Created by Curtis Marcoux";
            Gameover = true;
            Restart = true;
            musicSource1.clip = Victory;
            musicSource1.Play();
        }
        if (Timer.text == "0")
        {
            Gameover = true;
            Restart = true;
        }
    }

    public void GameOver ()
    {
        GameOverText.text = "Game Over Game Created by Curtis Marcoux";
        Gameover = true;
        musicSource2.clip = Dead;
        musicSource2.Play();
    }
}
