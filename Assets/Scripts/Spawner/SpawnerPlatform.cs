using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPlatform : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private List<Platform> _platforms = new List<Platform>();
    [SerializeField] private TriggerSpawnerPlatform _trigger;

    private bool _isSpawned = false;
    private int _targetPositionY = 30;

    private int _minPositionX = -9;
    private int _maxPositionX = 10;

    private Transform _tempTransform;

    private void FixedUpdate() 
    {
        transform.position = new Vector3(transform.position.x, _player.transform.position.y + _targetPositionY, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if(collider.gameObject.TryGetComponent<TriggerSpawnerPlatform>(out TriggerSpawnerPlatform component))
        {
            _isSpawned = true;
            Spawn();
        }
    }

    private void Spawn ()
    {
        _tempTransform = transform;
        _tempTransform.position = new Vector3(Random.Range(_minPositionX, _maxPositionX), transform.position.y, transform.position.z);
        
        Instantiate(_platforms[Random.Range(0, _platforms.Count)], _tempTransform.position, transform.rotation);
            _isSpawned = false;
    }
}