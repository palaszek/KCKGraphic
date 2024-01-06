using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    [SerializeField] private Animator transitionAnim;
    [SerializeField] private GameObject canvas;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
    public void NextLevel()
    {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        canvas.SetActive(true);
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        transitionAnim.SetTrigger("start");
        yield return new WaitForSeconds(1);
        canvas.SetActive(false);
    }

    IEnumerator LoadLevel(string sceneName)
    {
        canvas.SetActive(true);
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(sceneName);
        transitionAnim.SetTrigger("start");
        yield return new WaitForSeconds(1);
        canvas.SetActive(false);
    }

    public void LoadLevelByName(string  sceneName)
    {
        StartCoroutine(LoadLevel(sceneName));
    }
}
