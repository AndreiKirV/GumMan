using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 25;
    [SerializeField] private float _jumpForce = 225;
    [SerializeField] private int _health = 100;

    private bool _isDie = false;

    public float Speed => _speed;
    public float JumpForce => _jumpForce;
    public int Health => _health;

    private void OnTriggerStay2D(Collider2D collider) 
    {
        if(collider.gameObject.TryGetComponent<Cleaner>(out Cleaner cleaner))
            _isDie = true;
    }
}