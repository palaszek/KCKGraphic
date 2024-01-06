using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelMenu : MonoBehaviour
{

    [SerializeField] private Button[] buttons;
    [SerializeField] private TextMeshProUGUI[] highscores;

    private void Awake()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        for(int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
            highscores[i].gameObject.SetActive(false);
        }
        for(int i = 0;i < unlockedLevel; i++)
        {
            buttons[i].interactable = true;
            highscores[i].gameObject.SetActive(true);
            highscores[i].text = "Najwyzszy wynik: " + PlayerPrefs.GetInt($"highscore{i+1}",0).ToString();
        }
    }
    public void LoadLevel(int levelIndex)
    {
        string level = "Level" + levelIndex;

        SceneController.instance.LoadLevelByName(level);
    }
}
