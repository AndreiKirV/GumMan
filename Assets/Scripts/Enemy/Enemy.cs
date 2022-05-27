using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private Player _player;
    private Spawner  _spawner;
    
    public float Speed => _speed;
    public Player Target => _player;

    private void Awake()
    {
        _spawner = transform.parent.GetComponent<Spawner>();
        _player = _spawner.Target;
    }

    private void OnTriggerStay2D(Collider2D collider) 
    {
        if(collider.gameObject.TryGetComponent<Cleaner>(out Cleaner cleaner))
            Destroy(gameObject);
    }
}