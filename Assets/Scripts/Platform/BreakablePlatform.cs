using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class BreakablePlatform : MonoBehaviour
{
    [SerializeField] private int _collisionRate;
    [SerializeField] Sprite _damagedSprite;
    
    private int _gravityAfterDeath = 5;

    private void TryDestroy ()
    {
        if (_collisionRate > 1)
            gameObject.transform.GetComponent<SpriteRenderer>().sprite = _damagedSprite;
        else
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            GetComponent<Rigidbody2D>().gravityScale = _gravityAfterDeath;
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