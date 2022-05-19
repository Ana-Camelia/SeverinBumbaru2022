using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public bool isGameOver = false;
    bool audioPlayed = false;
    public GameObject GOPanel;
    GameManager gm;

    [SerializeField] AudioClip gameOverSound;
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver) return;
        GameOver();
    }

    private void GameOver()
    {
        if(!audioPlayed)
        {
            AudioSource.PlayClipAtPoint(gameOverSound, Camera.main.transform.position, 0.75f);
            audioPlayed = true;
            GOPanel.SetActive(true);
            FindObjectOfType<MusicPlayer>().GetComponent<AudioSource>().Stop();
            gm.LoadStartMenu();
        }
    }
}
