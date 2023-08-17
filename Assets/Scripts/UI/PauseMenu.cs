using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject _pauseMenu, _GamePlay;
    [SerializeField] AudioClip audioClip;
    [SerializeField] AudioSource audioSource;

    private void Awake()
    {
        _GamePlay.SetActive(true);
        _pauseMenu.SetActive(false);
    }

    public void LoadPauseMenu()
    {
        audioSource.PlayOneShot(audioClip);
        Invoke("ActivePauseMenu", 0.1f);

    }

    public void GameWindow()
    {
        audioSource.PlayOneShot(audioClip);
        Time.timeScale = 1f;
        Invoke("ActiveGameWindow", 0.1f);
    }

    private void ActivePauseMenu()
    {
        Time.timeScale = 0f;
        _pauseMenu.SetActive(true);
        _GamePlay.SetActive(false);
    }

    private void ActiveGameWindow()
    {
        _pauseMenu.SetActive(false);
        _GamePlay.SetActive(true);
    }
}
