using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("GamePlay");
    }

    IEnumerator GamePlay()
    {
        yield return new WaitForSeconds(35f);
        SceneManager.LoadScene("Level_01");
    }
}
