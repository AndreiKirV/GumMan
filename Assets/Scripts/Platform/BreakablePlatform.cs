using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakablePlatform : MonoBehaviour
{
    [SerializeField] private int _collisionRate;
    [SerializeField] Sprite _damagedSprite;

    private void Update() 
    {
        if (_collisionRate <= 0)
        gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        gameObject.transform.GetComponent<Rigidbody2D>().gravityScale = 5;

        if (_collisionRate <= 1)
        {
            gameObject.transform.GetComponent<SpriteRenderer>().sprite = _damagedSprite;
        }
    }

    private void OnTriggerStay2D(Collider2D collider) 
    {
        if(collider.gameObject.TryGetComponent<DamageBox>(out DamageBox damageBox))
        {
            _collisionRate --;
        }
    }
}