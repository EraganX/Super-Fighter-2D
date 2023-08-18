using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;

    private Animator _animator;
    private Vector3 _tempPosition;
    private LevelUp _levelUp; 

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _tempPosition = transform.position;
        _levelUp = FindObjectOfType<LevelUp>();
    }

    private void Update()
    {
        _tempPosition.x += _speed * Time.deltaTime;
        transform.position = _tempPosition;
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag(TagsManager.BOMB_TAG))
        {
            _animator.SetTrigger(TagsManager.ENEMY_DESTROY_TANK_ANIMATION);
            gameObject.SetActive(false);
            Destroy(gameObject, 1f);

            // Increment the tankDestroyed count in the LevelUp script
            _levelUp.tankDestroyed++;
        }

        if (target.gameObject.CompareTag(TagsManager.TANK_RICH_MARK_TAG))
        {
            Destroy(target.gameObject);
        }
    }
}
