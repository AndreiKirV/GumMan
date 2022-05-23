using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpawnerPlatform : MonoBehaviour
{
    [SerializeField] private Transform _spawner;

    private void Update() 
    {
        if (_spawner.transform.position.y >= transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y+15, transform.position.z);
        }
    }
}