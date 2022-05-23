using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private int _delayDistance = 25;
    [SerializeField] private float _speed = 5f;

    private int _direction = -1;
    private int _minPosition = -20;
    private int _maxPosition = 20;

    private void Update() 
    {
        transform.Translate(_speed*Time.deltaTime*_direction, 0, 0);

        if (transform.position.x > _maxPosition || transform.position.x < _minPosition)
        {
            _direction *= -1;
        }

        if (_player.transform.position.y >= transform.position.y + _delayDistance)
        {
            transform.position = new Vector3(0, transform.position.y + _delayDistance*2, 0);
        }
    }
}
