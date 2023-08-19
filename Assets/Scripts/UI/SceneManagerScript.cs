using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    [SerializeField] AudioClip audioClip;
    [SerializeField] AudioSource audioSource,_bgAudio;

    

    public void MainMenu()
    {
        Time.timeScale = 1f;
        audioSource.PlayOneShot(audioClip);
        Invoke("ActiveMainMenu", 0.1f);
    }

    public void MissionFailed()
    {
        Time.timeScale = 1f;
        audioSource.PlayOneShot(audioClip);
        Invoke("ActiveMissionFailed", 0.1f);
    }

    public void GameQuit()
    {
        Time.timeScale = 1f;
        audioSource.PlayOneShot(audioClip);
        Invoke("GameExitScene", 0.1f);
    }


    public void Level1()
    {
        _bgAudio.Play();
        Time.timeScale = 1f;
        audioSource.PlayOneShot(audioClip);
        Invoke("LevelScene1", 0.1f);
    }

    public void Level2()
    {
        _bgAudio.Play();
        Time.timeScale = 1f;
        audioSource.PlayOneShot(audioClip);
        Invoke("LevelScene2", 0.1f);
    }

    public void Level3()
    {
        _bgAudio.Play();
        Time.timeScale = 1f;
        audioSource.PlayOneShot(audioClip);
        Invoke("LevelScene3", 0.1f);
    }

    public void FinalLevel()
    {
        _bgAudio.Play();
        Time.timeScale = 1f;
        audioSource.PlayOneShot(audioClip);
        Invoke("LevelSceneFinal", 0.1f);
    }

    public void PlayIntro()
    {
        Time.timeScale = 1f;
        audioSource.PlayOneShot(audioClip);
        Invoke("PlayIntroVideo", 0.1f);
    }

    private void PlayIntroVideo()
    {
        SceneManager.LoadScene("Intro");
    }



    private void ActiveMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void GameExitScene()
    {
        Application.Quit();
    }

    private void ActiveMissionFailed(){
        SceneManager.LoadScene("Mission_Failed");
    }

    private void LevelScene1()
    {
        SceneManager.LoadScene("Level_01");
    }

    private void LevelScene2()
    {
        SceneManager.LoadScene("Level_02");
    }

    private void LevelScene3()
    {
        SceneManager.LoadScene("Level_03");
    }
    
    private void LevelSceneFinal()
    {
        SceneManager.LoadScene("Level_Final");
    }
}
