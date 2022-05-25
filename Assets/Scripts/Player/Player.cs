using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 25;
    [SerializeField] private float _jumpForce = 237;
    [SerializeField] private int _health = 100;

    private bool _isDie = false;

    public float Speed => _speed;
    public float JumpForce => _jumpForce;
    public int Health => _health;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.TryGetComponent<Cleaner>(out Cleaner cleaner) || collision.gameObject.TryGetComponent<DamageBox>(out DamageBox damageBox) || collision.gameObject.GetComponent<Bullet>())
            Dying();

    }

    public void Dying()
    {
        _isDie = true;
        Debug.Log("Главный герой умер");
    }
}