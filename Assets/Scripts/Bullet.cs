using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _delayDelete = 5;
    private Vector3 _target;

    private void Start()
    {
        _target = GameObject.Find("Player").transform.position;
        StartCoroutine(destroyAfterDelay(_delayDelete));
    }

    private void Update() 
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator destroyAfterDelay (float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
