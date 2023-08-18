using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelUp : MonoBehaviour
{
    public int level;
    public int tankDestroyed=0;

    [SerializeField] AudioClip _Win,_missionCompleted;
    [SerializeField] AudioSource _Winsrc;
    [SerializeField] TMP_Text _count;
    [SerializeField] GameObject _player, _nextLevel,_gamePlaymenu,_pauseMenu, _mark, _PauseSc;

    private string _remainTanks;
    private PauseMenu _pauseScript;

    private void Awake()
    {
        _count.text = "0";
        _pauseScript = _PauseSc.GetComponent<PauseMenu>();
        _pauseScript._isPlaying = true;
    }

    private void Update()
    {
        if (_player!=null && _mark != null)
        {
            if (level > tankDestroyed)
            {
                _remainTanks = (level - tankDestroyed).ToString();
                _count.text = _remainTanks;
            }
            else
            {
                Rigidbody2D _playerRD = _player.GetComponent<Rigidbody2D>();
                _playerRD.isKinematic = true;
                _player.transform.localScale = new Vector3(0, 0, 0);

                _gamePlaymenu.SetActive(false);
                _pauseMenu.SetActive(false);
                _nextLevel.SetActive(true);
            }

            _remainTanks = (level - tankDestroyed).ToString();
            _count.text = _remainTanks;

            if (_nextLevel.active == true)
            {
                Time.timeScale = 0.1f;
            }
            else
            {
                Time.timeScale = 1f;
            }


            if (!(_pauseScript._isPlaying))
            {
                Time.timeScale = 0.1f;
            }
            else
            {
                Time.timeScale = 1f;
            }
            
        }
        else
        {
            SceneManager.LoadScene("Mission_Failed");
        }
    }
}
