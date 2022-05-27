using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Enemy))]
public class EnemyButterfly : MonoBehaviour
{
    [SerializeField] private GameObject _damageBox;

    private Player _player;
    private float _speed;
    private bool _isLive = true;
    private int _gravityAfterDeath = 5;
    
    private void Start() 
    {
        _speed = GetComponent<Enemy>().Speed;
        _player = GetComponent<Enemy>().Target;
    }

    private void Update() 
    {
        TryMove();
    }

    private void OnTriggerStay2D(Collider2D collider) 
    {
        if(collider.gameObject.TryGetComponent<DamageBox>(out DamageBox damageBox))
        {
            _damageBox.SetActive(false);
            _isLive = false;
            gameObject.transform.GetComponent<Rigidbody2D>().gravityScale = _gravityAfterDeath;
        }
    }

    private void TryMove ()
    {
        if(_isLive == true)
            transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);
    }
}