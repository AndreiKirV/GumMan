using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpawnerPlatform : MonoBehaviour
{
    [SerializeField] private Transform _spawner;

    private int _stepPosition = 15;

    private void Update() 
    {
        if (_spawner.transform.position.y >= transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y+_stepPosition, transform.position.z);
        }
    }
}