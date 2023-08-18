using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _tank;
    [SerializeField] private Transform _responeLocation;
    [SerializeField] private GameObject levelObject;
    private LevelUp levelUp;
    private int _level;

    private void Start()
    {
        levelUp = levelObject.GetComponent<LevelUp>();
        _level = levelUp.level;
        StartCoroutine(TankRespawn());
    }

    IEnumerator TankRespawn()
    {
        while (_level>0)
        {
            Instantiate(_tank, _responeLocation.transform.position, Quaternion.identity);
            _level --;
            yield return new WaitForSeconds(40f);
        }
    }
}
