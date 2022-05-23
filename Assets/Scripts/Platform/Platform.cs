using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collider) 
    {
        if(collider.gameObject.TryGetComponent<Cleaner>(out Cleaner cleaner))
            Destroy(gameObject);
    }
}