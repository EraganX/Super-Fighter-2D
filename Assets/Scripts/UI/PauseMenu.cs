using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject _pauseMenu, _GamePlay;
    [SerializeField] AudioClip audioClip;
    [SerializeField] AudioSource audioSource;

    public bool _isPlaying;

    private void Awake()
    {
        _GamePlay.SetActive(true);
        _pauseMenu.SetActive(false);
    }

    public void LoadPauseMenu()
    {
        _isPlaying = false;
        audioSource.PlayOneShot(audioClip);
        Invoke("ActivePauseMenu", 0.1f);
    }

    public void GameWindow()
    {
        audioSource.PlayOneShot(audioClip);
        _isPlaying = true;
        Invoke("ActiveGameWindow", 0.1f);
    }

    private void ActivePauseMenu()
    {
        _pauseMenu.SetActive(true);
        _GamePlay.SetActive(false);
    }

    private void ActiveGameWindow()
    {
        _pauseMenu.SetActive(false);
        _GamePlay.SetActive(true);
    }
}
