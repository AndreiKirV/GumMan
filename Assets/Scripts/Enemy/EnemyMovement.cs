using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private int _minPosition = -10;
    [SerializeField] private int _maxPosition = 10;
    [SerializeField] private GameObject _damageBox;
    
    private float _speed;
    private int _direction;
    private int _gravityAfterDeath = 5;
    private bool _isFacingRight = true;
    private bool _isDying = false;

    private void Start() 
    {
        _speed = GetComponent<Enemy>().Speed;
        _direction = Random.Range(-1, 1);

        if (_direction == 0)
            _direction = 1;
        
        if(_direction == -1)
            Flip();
    }

    private void Update() 
    {
        transform.Translate(_speed*Time.deltaTime*_direction, 0, 0);

        if (transform.position.x > _maxPosition || transform.position.x < _minPosition)
        {
            _direction *= -1;
            Flip();
        }
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
        if(collider.gameObject.TryGetComponent<DamageBox>(out DamageBox damageBox))
        {
            _damageBox.SetActive(false);
            gameObject.transform.GetComponent<Rigidbody2D>().gravityScale = _gravityAfterDeath;
        }
    }
}