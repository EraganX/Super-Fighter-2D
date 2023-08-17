using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    [SerializeField] AudioClip audioClip;
    [SerializeField] AudioSource audioSource;

   public void GameStart()
    {
        audioSource.PlayOneShot(audioClip);
        Invoke("GameplaySceneLoad",0.1f);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        audioSource.PlayOneShot(audioClip);
        Invoke("ActiveMainMenu", 0.1f);
    }

    public void GameQuit()
    {
        audioSource.PlayOneShot(audioClip);
        Invoke("GameExitScene",0.1f);
    }


    private void GameplaySceneLoad()
    {
        SceneManager.LoadScene("GamePlay");
    }
    
    private void ActiveMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void GameExitScene()
    {
        Application.Quit();
    }

}
