using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private Vector3 _tempPosition;

    private bool _isLaunchedByPlayer;

    private void Start()
    {
        _tempPosition = transform.position;
    }

    private void Update()
    {
        MissileDirection();
    }

    private void MissileDirection()
    {
        if (_isLaunchedByPlayer)
        {
            _tempPosition.x += speed * Time.deltaTime;
            transform.position = _tempPosition;
        }
        else
        {
            _tempPosition.x -= speed * Time.deltaTime;
            transform.position = _tempPosition;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Destroy"))
        {
            Debug.Log("Trigger");
            Destroy(gameObject);
        }
    }
}
