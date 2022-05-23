using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collider) 
    {
        if(collider.gameObject.TryGetComponent<Player>(out Player player))
        {
            gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
           gameObject.transform.GetComponent<Rigidbody2D>().gravityScale = 5;
        }
    }
}
