using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    float nextLevelDelay = 3f;


    public void LoadNextLevel()
    {
        StartCoroutine(DelayLevel(SceneManager.GetActiveScene().buildIndex + 1, nextLevelDelay));
        WaveSpawner wp = FindObjectOfType<WaveSpawner>();
        if(wp != null) { wp.countdown = 5f; }
    }

    IEnumerator DelayLevel(int whatLevel,float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(whatLevel);
    }

    public void ReloadCurrentLevel()
    {
        StartCoroutine(DelayLevel(SceneManager.GetActiveScene().buildIndex,nextLevelDelay));
    }

    public void LoadStartMenu()
    {
        StartCoroutine(DelayLevel(0, nextLevelDelay));
        FindObjectOfType<MusicPlayer>().GetComponent<AudioSource>().Play();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
