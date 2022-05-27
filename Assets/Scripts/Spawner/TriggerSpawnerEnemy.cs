using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpawnerEnemy : MonoBehaviour
{
    [SerializeField] private Transform _spawner;

    private int _stepPosition = 75;
    
    private void Update()
    {
        if (_spawner.transform.position.y >= transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y+_stepPosition, transform.position.z);
        }
    }
}