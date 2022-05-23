using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    private int _direction;
    private int _minPosition = -11;
    private int _maxPosition = 11;

    private void Start() 
    {
        _direction = Random.Range(-1, 1);

        if (_direction == 0)
        {
            _direction = 1;
        }
    }

    private void Update() 
    {
        transform.Translate(_speed*Time.deltaTime*_direction, 0, 0);

        if (transform.position.x > _maxPosition || transform.position.x < _minPosition)
        {
            _direction *= -1;
        }
    }

    private void Teleport(int targetPosition)
    {
        transform.position = new Vector3(targetPosition, transform.position.y, transform.position.z);
    }
}