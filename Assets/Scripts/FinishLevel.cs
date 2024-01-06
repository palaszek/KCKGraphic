using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    [SerializeField] private CoinManager coinManager;
    [SerializeField] private TimeManager timeManager;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private TextMeshProUGUI scoreText;
    private int score = 0;
    private int highscore = 0;

    AudioManager audioManager;

    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        highscore = PlayerPrefs.GetInt($"highscore{SceneManager.GetActiveScene().buildIndex}", 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0;

            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;

            score = coinManager.GetCoinsCount() * Mathf.FloorToInt(timeManager.GetLastTime());

            audioManager.PlaySFX(audioManager.win);
            if(score > highscore) 
            {
                PlayerPrefs.SetInt($"highscore{SceneManager.GetActiveScene().buildIndex}", score);
                scoreText.text = "Nowy najwyzszy wynik!\n " + highscore;
            }
            else
            {
                scoreText.text = "Wynik: " + score +"\n Najwyzszy wynik: " + highscore;
            }
            UnlockNewLevel();
            winScreen.gameObject.SetActive(true);
        }
    }

    private void UnlockNewLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }
}
