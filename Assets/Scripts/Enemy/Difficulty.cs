using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty : MonoBehaviour
{
    [SerializeField] private Transform _respawnLocation;
    [SerializeField] private GameObject[] _hard;
    [SerializeField] private float _time=30f;

    private void Start()
    {
        StartCoroutine(SpawnSmallPlane());
    }

    IEnumerator SpawnSmallPlane()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(_time,_time * 1.5f));
            int _randomPrefab = Random.Range(0, _hard.Length);
            Instantiate(_hard[_randomPrefab], _respawnLocation.position, Quaternion.identity);
        }
    }
}
