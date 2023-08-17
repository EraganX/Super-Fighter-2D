using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;

    private Animator _animator;
    private Vector3 _tempPosition;

    private void Start()
    {
        _animator = GetComponent<Animator>();  
        _tempPosition = transform.position;
    }

    private void Update()
    {
        _tempPosition.x += _speed * Time.deltaTime;
        transform.position = _tempPosition;
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Bomb"))
        {
            _animator.SetTrigger("Boom");
            transform.position = transform.position;
            Destroy(gameObject,1f);
        }
    }
}
