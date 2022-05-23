using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private int _offsetY = 125;
    
    private Vector3 _target;
    private int _minCameraY = -1;
    private float _targetY;
    private Vector3 _offset;

    private void Start() 
    {
        _offset = new Vector3 (0,_offsetY,0);
    }

    private void Update() 
    {
        if(transform.position.y < _player.transform.position.y)
        {
            Vector3 currentPosition = Vector3.Lerp(transform.position, _target - _offset, _speed * Time.deltaTime);
            transform.position = currentPosition;
            _target = new Vector3(transform.position.x, LimitHeight(ref _targetY), transform.position.z);
        }
        
    }

    private float LimitHeight(ref float targetY)
    {
        if (_player.transform.position.y < _minCameraY)
        {
            targetY = _minCameraY;
        }
        else
        {
            targetY =_player.transform.position.y;
        }
        
        return targetY;
    }
}
