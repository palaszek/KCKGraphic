using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [Header("==========Audio Source==========")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource SFXSource;
    [Header("==========Audio Clip==========")]

    public AudioClip background;
    public AudioClip death;
    public AudioClip wallTouch;
    public AudioClip win;
    public AudioClip coin;
    public AudioClip mainMenu;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneChange;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneChange;
    }


    void OnSceneChange(Scene scene, LoadSceneMode mode)
    {

        if(SceneManager.GetActiveScene().buildIndex == 0) 
        {
            musicSource.clip = mainMenu;
            musicSource.Play();
        }else
        {
            musicSource.clip = background;
            musicSource.Play();
        }
    }

}
