using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private ParticleSystem _system;
    private float _speed;
    private float _damage;
    private Coroutine _coroutine;
    private EnemySpawner _spawner;

    private void OnDisable()
    {
        if( _coroutine != null )
            StopCoroutine( _coroutine );
    }

    public void SetValue(float damage, float speed, ParticleSystem system, EnemySpawner spawner)
    {
        _damage = damage;
        _speed = speed;
        _spawner = spawner;
        _system = system;
        Instantiate(_system,transform);
        _system.Play();
        StartCoroutine();
    }

    private void StartCoroutine()
    {
        _coroutine = StartCoroutine(StartMove());
    }

    private IEnumerator StartMove()
    {
        while (transform.position != _spawner.EnemyList[0].transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, _spawner.EnemyList[0].transform.position, _speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        _spawner.EnemyList[0].TakeDamage(_damage);
        Destroy(gameObject);
    }
}
