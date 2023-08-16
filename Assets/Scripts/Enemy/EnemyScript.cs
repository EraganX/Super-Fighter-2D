using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private float speed = 3.5f;
    [SerializeField] private float _maxHealth = 3f;
    [SerializeField] private float _stopPositionX = 12f;
    [SerializeField] private GameObject _missile;
    [SerializeField] private HealthBar _healthBar;


    private Vector3 _tempPosition;
    private bool _isLaunchedMissile = false;
    private Animator _animator;
    private bool _isDead =  false;

    float _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;

        _tempPosition = transform.position;
        _animator = GetComponent<Animator>();   

        _healthBar = GetComponentInChildren<HealthBar>();
        _healthBar.UpdateHealthBar(_maxHealth, _currentHealth);

    }
    private void Update()
    {
        if (!_isDead)
        {
            EnemyMovement();
        }
        else
        {
            _animator.SetTrigger(TagsManager.ENEMY_DESTROY_ANIMATION);
            Destroy(gameObject, 1f);
        }
        
    }

    private void EnemyMovement()
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
        if (!_isDead)
        {
            _tempPosition.x += -speed * Time.deltaTime;
            transform.position = _tempPosition;
        }
        
    }


    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag(TagsManager.REMOVE_CLONES_TAG))
        {
            Destroy(gameObject);
        }

        if ((target.gameObject.CompareTag(TagsManager.PLAYER_TAG)))
        {
            _isDead = true;
        }

        if (target.gameObject.CompareTag(TagsManager.PLAYER_MISSILE_TAG))
        {
            _currentHealth -= 1f;
            _healthBar.UpdateHealthBar(_maxHealth,_currentHealth);

            if (_currentHealth == 0)
            {
                _isDead = true;
                _healthBar.gameObject.SetActive(false); 
            }
            Destroy(target.gameObject);
        }
    }
}
