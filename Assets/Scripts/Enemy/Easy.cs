using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Easy : MonoBehaviour
{
    [SerializeField] private Transform[] _respawnLocations;
    [SerializeField] private GameObject[] _planeEasy;
    [SerializeField] private float _time=3f;

    private void Start()
    {
        StartCoroutine(SpawnSmallPlane());
    }

    IEnumerator SpawnSmallPlane()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(_time, _time * 1.5f));
            int _randomPrefab = Random.Range(0, _planeEasy.Length);
            int _randomLoc = Random.Range(0, _respawnLocations.Length);
            Instantiate(_planeEasy[_randomPrefab], _respawnLocations[_randomLoc].position, Quaternion.identity);
        }
    }
}
