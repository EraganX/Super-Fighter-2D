using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 3.5f;

    private float _verticalInput, _horizontalInput;
    private Vector3 _tempPosition;

    private Animator _animator;

    public bool _isDead = false;
    public bool _isGrounded = false;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_isDead)
        {
            if (_isGrounded)
            {
                _animator.SetTrigger(TagsManager.PLAYER_DESTROY_ANIMETION_PARAM);

            }
            else
            {
                _animator.SetBool("isDead",true);
                _rb.gravityScale = 1f;
                transform.localEulerAngles = new Vector3(0,0,-40);
            }
        }
        else
        {
            PlaneMove();
            PlaneRotation();

            if (Input.GetButtonDown("Fire1"))
            {
                _animator.SetTrigger(TagsManager.PLAYER_SHOOT_ANIMETION_PARAM);
            }
            else
            {
                _animator.SetTrigger(TagsManager.PLAYER_FLY_ANIMETION_PARAM);
            }
        }

    }

    private void PlaneRotation()
    {
        if (_verticalInput < 0)
        {
            transform.localEulerAngles = new Vector3(0, 0, 30 * _verticalInput);
        }
        if (_verticalInput > 0)
        {
            transform.localEulerAngles = new Vector3(0, 0, 30 * _verticalInput);
        }
        if (_verticalInput == 0)
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
    }

    private void PlaneMove()
    {
        _verticalInput = Input.GetAxis(TagsManager.VERTICAL_INPUT);
        _horizontalInput = Input.GetAxis(TagsManager.HORIZONTAL_INPUT);
        transform.position = _tempPosition;
        _tempPosition.y += _verticalInput * _moveSpeed * Time.deltaTime;
        _tempPosition.x += _horizontalInput * _moveSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag=="Ground" && _isDead)
        {
            _isGrounded = true;
        }
    }
}
