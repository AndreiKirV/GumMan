using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Player))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int _minPosition = -11;
    [SerializeField] private int _maxPosition = 11;
    [SerializeField] private float _targetScaleValue = 0.5f;
    [SerializeField] private AudioSource _contact;

    private bool _isPlatform = false;
    private bool _isFacingRight = true;
    private Player _player;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private Vector3 _startScale;
    private UnityEvent PlatformChanged;

    private void Start()
    {
        _player = GetComponent<Player>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        MoveXOnGround();
    }

    private void Jump()
    {
        if (_isPlatform)
        {
            _rigidbody.velocity = Vector2.up * _player.JumpForce;
            _isPlatform = false;
            StartCoroutine(ReScale());
        }
    }

    private void MoveXOnGround()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(_player.Speed*Time.deltaTime, 0, 0);
            TurnRight();                     
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-_player.Speed*Time.deltaTime, 0, 0);
            TurnLeft();            
        }

        if (transform.position.x > _maxPosition)
        {
            Teleport(_minPosition);
        }

        if (transform.position.x < _minPosition)
        {
            Teleport(_maxPosition);
        }
    }
    
    private void Teleport(int targetPosition)
    {
        transform.position = new Vector3(targetPosition, transform.position.y, transform.position.z);
    }

    private void TurnLeft ()
    {
        if (_isFacingRight)
        Flip();
    }

    private void TurnRight ()
    {
        if (!_isFacingRight)
        Flip();
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    private void OnTriggerStay2D(Collider2D collider) 
    {
        if(collider.gameObject.TryGetComponent<Platform>(out Platform platform) || collider.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            _isPlatform = true;
            Jump();
            _contact.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collider) 
    {
        if(collider.gameObject.TryGetComponent<Platform>(out Platform platform))
        _isPlatform = false;
    }

    private IEnumerator ReScale ()
    {
        transform.localScale -= new Vector3(0,_targetScaleValue,0);
        yield return new WaitForSeconds(0.2f);
        transform.localScale += new Vector3(0,_targetScaleValue,0);
    }
}