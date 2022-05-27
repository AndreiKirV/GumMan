using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private Player _target;
    
    public float Speed => _speed;
    public Player Target => _target;

    public void SetTarget(Player target)
    {
        _target = target;
    }

    private void OnTriggerStay2D(Collider2D collider) 
    {
        if(collider.gameObject.TryGetComponent<Cleaner>(out Cleaner cleaner))
            Destroy(gameObject);
    }
}