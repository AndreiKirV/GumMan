using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 25;
    [SerializeField] private float _jumpForce = 237;
    [SerializeField] private GameObject _menu;

    public float Speed => _speed;
    public float JumpForce => _jumpForce;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.TryGetComponent<PlayerKiller>(out PlayerKiller playerKiller))
            Dying();

    }

    public void Dying()
    {
        _menu.SetActive(true);
        Time.timeScale = 0;
    }
}