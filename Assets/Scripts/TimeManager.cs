using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float timeToPassLevel = 90f;
    [SerializeField] private Image warningSign;
    [SerializeField] private GameObject loseScreen;

    // Update is called once per frame
    private void Start()
    {
        if(warningSign != null)
            warningSign.gameObject.SetActive(false);
    }
    void Update()
    {
        if (timeToPassLevel > 0)
        {
            timeToPassLevel -= Time.deltaTime;
            if (timeToPassLevel < 15 && warningSign != null)
            {
                warningSign.gameObject.SetActive(true);
            }
        }
        else
        {
            timeToPassLevel = 0;
            Time.timeScale = 0;
            loseScreen.SetActive(true);
        }
        int minutes = Mathf.FloorToInt(timeToPassLevel / 60);
        int seconds = Mathf.FloorToInt(timeToPassLevel % 60);
        int milliseconds = Mathf.FloorToInt((timeToPassLevel * 100) % 100);

        timerText.text = string.Format("Pozostaly czas: {0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }

    public float GetLastTime()
    {
        return timeToPassLevel;
    }
}
