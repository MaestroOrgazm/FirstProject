using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 6;
    [SerializeField] private float _health = 100;
    [SerializeField] private int _revard = 2;

    private Animator _animator;
    private Transform _target;
    private Coroutine _coroutine;
    private EnemySpawner _spawner;

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    public void SetPath(Transform target, EnemySpawner enemySpawner)
    {
        _target = target;
        _coroutine = StartCoroutine(MoveToHome());
        _animator = GetComponent<Animator>();
        _animator.SetTrigger("Run");
        _spawner = enemySpawner;
    }

    public void TakeDamage (float damage)
    {
        if (Wallet.AttackBonus)
            _health -= damage*Wallet.Percent;
        else
            _health -= damage;

        if (_health <= 0)
            Die();
    }

    private void Die()
    {
        Wallet.ChangeMoney(_revard);
        _animator.SetTrigger("Die");
        _spawner.DeleteEnemy(this);
    }

    private IEnumerator MoveToHome()
    {
        while (transform.position != _target.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
}
