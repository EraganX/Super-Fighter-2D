using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _bullets;
    [SerializeField] private GameObject _bomb;
    [SerializeField] private AudioClip _explotionAudio,_fireClip, _dropBomb;
    [SerializeField] private AudioSource _destroySC,_shootSC;
    [SerializeField] private float
        _Firerate = 0.1f,
        _bombDPS = 3f,
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

    private float _lastBombDropTime;
    private float _lastfireTime;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _tempPosition= new Vector3(-12,0,0);
        _lastBombDropTime = Time.time;
        _lastfireTime = Time.time;
    }//awake

    private void Update()
    {
        if (_isDead)
        {
            if (_isGrounded)
            {
                _animator.SetTrigger(TagsManager.PLAYER_DESTROY_ANIMETION_PARAM); //_player destroy animation
                Destroy(gameObject,1f);
            }
            else
            {
                _animator.SetBool(TagsManager.PLAYER_DEAD_ANIMETION_PARAM, true); //_player hit  animation
                _rb.gravityScale = 1f;
                transform.localEulerAngles = new Vector3(0,0,-40);
            }
        }//_player dead
        else
        {
            PlaneMove();
            PlaneRotation();
            if (Input.GetButton(TagsManager.FIRE_INPUT) && (Time.time - _lastfireTime)>_Firerate)
            {

                _shootSC.PlayOneShot(_fireClip);
                _animator.SetTrigger(TagsManager.PLAYER_SHOOT_ANIMETION_PARAM); //_player shoot animation
                Instantiate(_bullets,_tempPosition,Quaternion.identity);
                _lastfireTime = Time.time;
            }

            if (Input.GetKeyDown(KeyCode.Space) && (Time.time-_lastBombDropTime)>_bombDPS)
            {
                _shootSC.PlayOneShot(_dropBomb);
                Instantiate(_bomb, _tempPosition, Quaternion.identity);
                _lastBombDropTime = Time.time;
            }

            _animator.SetTrigger(TagsManager.PLAYER_FLY_ANIMETION_PARAM); //_player fly animation
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
    }//Movement of the _player

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
    }//limit the _player movement


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == TagsManager.ENEMY_TAG || 
            collision.transform.CompareTag(TagsManager.ENEMY_MISSILE_TAG))
        {
            if (collision.transform.CompareTag(TagsManager.ENEMY_MISSILE_TAG))
            {
                Destroy(collision.gameObject);
            }
            _destroySC.PlayOneShot(_explotionAudio);
            _isDead = true;

        }//Missile or Enemy plane hit

        if (collision.transform.tag == TagsManager.REMOVE_CLONES_TAG && _isDead)
        {
            _destroySC.PlayOneShot(_explotionAudio);
            _isGrounded = true;
        }//Destroy _player when hit the ground
    }//trigger enter
}
