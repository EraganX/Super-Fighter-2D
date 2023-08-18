using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private Vector3 _tempPosition;
    private Animator _animator;
    

    private void Start()
    {
        _tempPosition = transform.position;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        MissileDirection();
    }

    private void MissileDirection()
    {
        _tempPosition.y -= speed * Time.deltaTime;
        transform.position = _tempPosition;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagsManager.REMOVE_CLONES_TAG))
        {
            _animator.SetTrigger(TagsManager.BOMB_EXPLOTION_ANIMATION);
            Destroy(gameObject,0.5f);
        }
    }
}
