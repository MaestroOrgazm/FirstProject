using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 6;
    [SerializeField] private float _health = 100;
    [SerializeField] private int _revard = 2;
    [SerializeField] private Transform _targetBullet;
    [SerializeField] private AudioSource _audioSource;

    private Animator _animator;
    private Transform _target;
    private Coroutine _coroutine;
    private EnemySpawner _spawner;
    private float _deley = 1;
    private bool _isMoving = true;

    public Transform TargetBullet => _targetBullet;

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
        _audioSource.Play();
        _isMoving = false;
        Wallet.ChangeMoney(_revard);
        _animator.SetTrigger("Die");
        _spawner.DeleteEnemy(this);
        Destroy(this.gameObject, _deley);
    }

    private IEnumerator MoveToHome()
    {
        while (transform.position != _target.position && _isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
}
