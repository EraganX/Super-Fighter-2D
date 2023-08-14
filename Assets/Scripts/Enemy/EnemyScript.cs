using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private float speed = 3.5f;
    [SerializeField] private float _stopPositionX = 12f;
    [SerializeField] GameObject _missile;

    private Vector3 _tempPosition;
    private bool _isLaunchedMissile = false;

    private Animator _animator;

    private void Start()
    {
        _tempPosition = transform.position;
        _animator = GetComponent<Animator>();   
    }
    private void Update()
    {
        if (_tempPosition.x > _stopPositionX)
        {
            _tempPosition.x -= speed * Time.deltaTime;
            transform.position = _tempPosition;
        }
        else
        {
            if ((_missile != null) && (!_isLaunchedMissile))
            {
                Instantiate(_missile, _tempPosition, Quaternion.identity);
                _isLaunchedMissile = true;
            }
            StartCoroutine(WaitForShoot());
        }
    }

    IEnumerator WaitForShoot()
    {
        yield return new WaitForSeconds(5f);
        _tempPosition.x += -speed * Time.deltaTime;
        transform.position = _tempPosition;
    }


    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }

        if((target.gameObject.CompareTag("Bullet")) || (target.gameObject.CompareTag("Player")))
        {
            _animator.SetTrigger("destroy");
            Destroy(gameObject,1f);
        }
    }
}
