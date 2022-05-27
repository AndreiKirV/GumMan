using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class Shooter : MonoBehaviour
{
    [SerializeField] protected Bullet Bullet;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] float _delay = 1;

    private bool _isShoot = false;

    private void Update() 
    {
        TryShoot();
    }

    public void TryShoot()
    {
        if (_isShoot == false)
        {

            Bullet bullet = Instantiate(Bullet, _shootPoint.position, Quaternion.identity);
            bullet.SetTarget(GetComponent<Enemy>().Target);
            _isShoot = true;
            StartCoroutine(DelayShoot(_delay));
        } 
    }

    private IEnumerator DelayShoot (float delay) 
    {
        yield return new WaitForSeconds(delay);
        _isShoot = false;
    }
}