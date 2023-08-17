using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImanager : MonoBehaviour
{
    [SerializeField] GameObject _mainMenu, _credit;
    [SerializeField] AudioClip audioClip;
    [SerializeField] AudioSource audioSource;
    private void Awake()
    {
        _mainMenu.SetActive(true);
        _credit.SetActive(false);
    }

    public void LoadCredits()
    {
        audioSource.PlayOneShot(audioClip);
        Invoke("ActiveCreditWindow",0.1f);
        
    }

    public void MainMenu() {
        audioSource.PlayOneShot(audioClip);
        Invoke("ActiveMainMenu", 0.1f);
    }

    private void ActiveCreditWindow()
    {
        _credit.SetActive(true);
        _mainMenu.SetActive(false);
    }

    private void ActiveMainMenu()
    {
        _credit.SetActive(false);
        _mainMenu.SetActive(true);
    }
}
