using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpawnerEnemy : MonoBehaviour
{
    [SerializeField] private Transform _spawner;
    
    private void Update()
    {
        if (_spawner.transform.position.y >= transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y+75, transform.position.z);
        }
    }
}
