using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private ParticleSystem _system;
    private float _speed;
    private float _damage;
    private float _distance = 1f;
    private Coroutine _coroutine;
    private Enemy _target;

    public void SetValue(float damage, float speed, ParticleSystem system, Enemy enemy)
    {
        _damage = damage;
        _speed = speed;
        _system = system;
        _target = enemy;
        Instantiate(_system, transform);
        _system.Play();
        _coroutine = StartCoroutine(StartMove());
    }

    private IEnumerator StartMove()
    {
        while (_target != null)
        {
            if(Vector3.Distance(transform.position, _target.TargetBullet.position) < _distance)
            {
                break; 
            }

            transform.position = Vector3.MoveTowards(transform.position, _target.TargetBullet.position, _speed * Time.deltaTime);
            yield return null;
        }

        if (_target != null)
        {
            _target.TakeDamage(_damage);
        }
        Destroy(gameObject);
    }
}
