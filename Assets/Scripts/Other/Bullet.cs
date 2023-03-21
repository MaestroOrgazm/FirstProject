using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private ParticleSystem _system;
    private float _speed = 25;
    private float _damage;
    private Enemy _target;

    public void Initialize(float damage, ParticleSystem system, Enemy enemy)
    {
        _damage = damage;
        _target = enemy;
        _system = system;
        Instantiate(_system, transform);
        _system.Play();
    }

    private void FixedUpdate()
    { 
        if (_target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.TargetBullet.transform.position, _speed*Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Enemy>(out Enemy enemy)) 
        { 
            enemy.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}
