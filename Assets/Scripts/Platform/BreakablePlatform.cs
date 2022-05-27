using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class BreakablePlatform : MonoBehaviour
{
    [SerializeField] private int _collisionRate;
    [SerializeField] private Sprite _damagedSprite;

    private Rigidbody2D _rigidbody;
    private int _gravityAfterDeath = 5;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void TryDestroy ()
    {
        if (_collisionRate > 1)
            gameObject.transform.GetComponent<SpriteRenderer>().sprite = _damagedSprite;
        else
        {
            _rigidbody.bodyType = RigidbodyType2D.Dynamic;
            _rigidbody.gravityScale = _gravityAfterDeath;
        }
    }

    private void OnTriggerStay2D(Collider2D collider) 
    {
        if(collider.gameObject.TryGetComponent<DamageBox>(out DamageBox damageBox))
        {
            TryDestroy();
            _collisionRate --;
        }
    }
}