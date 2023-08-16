using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _bullets;
    [SerializeField] private float
        _moveSpeed = 3.5f,
        _minBoundaryX = -12f,
        _maxBoundaryX = 12f, 
        _minBoundaryY = -6.10f, 
        _maxBoundaryY = 5f;

    private float _verticalInput, _horizontalInput;
    private Vector3 _tempPosition;
    private Rigidbody2D _rb;
    private Animator _animator;

    public bool _isDead = false;
    public bool _isGrounded = false;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _tempPosition= new Vector3(-12,0,0);

    }//awake

    private void Update()
    {
        if (_isDead)
        {
            if (_isGrounded)
            {
                _animator.SetTrigger(TagsManager.PLAYER_DESTROY_ANIMETION_PARAM); //player destroy animation

            }
            else
            {
                _animator.SetBool(TagsManager.PLAYER_DEAD_ANIMETION_PARAM, true); //player hit  animation
                _rb.gravityScale = 1f;
                transform.localEulerAngles = new Vector3(0,0,-40);
            }
        }//player dead
        else
        {
            PlaneMove();
            PlaneRotation();

            if (Input.GetButtonDown(TagsManager.FIRE_INPUT) || Input.GetKeyDown(KeyCode.Space))
            {
                _animator.SetTrigger(TagsManager.PLAYER_SHOOT_ANIMETION_PARAM); //player shoot animation
                Instantiate(_bullets,_tempPosition,Quaternion.identity);
            }

            _animator.SetTrigger(TagsManager.PLAYER_FLY_ANIMETION_PARAM); //player fly animation

        }

    }//update

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
    }//rotate the plane

    private void PlaneMove()
    {
        _verticalInput = Input.GetAxis(TagsManager.VERTICAL_INPUT);
        _horizontalInput = Input.GetAxis(TagsManager.HORIZONTAL_INPUT);

        _tempPosition.y += _verticalInput * _moveSpeed * Time.deltaTime;
        _tempPosition.x += _horizontalInput * _moveSpeed * Time.deltaTime;

        transform.position = _tempPosition;

        PlayerBoundaries();
    }//Movement of the player

    private void PlayerBoundaries()
    {
        if (_tempPosition.x <= _minBoundaryX)
        {
            _tempPosition.x = _minBoundaryX;
        }

        if (_tempPosition.x >= _maxBoundaryX)
        {
            _tempPosition.x = _maxBoundaryX;
        }

        if (_tempPosition.y <= _minBoundaryY)
        {
            _tempPosition.y = _minBoundaryY;
        }

        if (_tempPosition.y >= _maxBoundaryY)
        {
            _tempPosition.y = _maxBoundaryY;
        }
    }//limit the player movement

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag==TagsManager.GROUND_TAG && _isDead)
        {
            _isGrounded = true;
        }//Destroy player when hit the ground
    }//collition enter

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == TagsManager.ENEMY_TAG || 
            collision.transform.CompareTag(TagsManager.ENEMY_MISSILE_TAG))
        {
            if (collision.transform.CompareTag(TagsManager.ENEMY_MISSILE_TAG))
            {
                Destroy(collision.gameObject);
            }
            _isDead = true;
        }//Missile or Enemy plane hit
    }//trigger enter
}
