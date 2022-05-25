using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyButterfly : MonoBehaviour
{
    private GameObject _player;
    private float _speed;
    private bool _isLive = true;
    private void Start() 
    {
        _speed = GetComponent<Enemy>().Speed;
        _player = GameObject.Find("Player");
    }

    private void Update() 
    {
        TryMove();
    }

    private void OnTriggerStay2D(Collider2D collider) 
    {
        if(collider.gameObject.TryGetComponent<DamageBox>(out DamageBox damageBox))
        {
            transform.Find("DamageBox").gameObject.SetActive(false);
            _isLive = false;
            gameObject.transform.GetComponent<Rigidbody2D>().gravityScale = 5;
        }
    }

    private void TryMove ()
    {
        if(_isLive == true)
            transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);
    }
}