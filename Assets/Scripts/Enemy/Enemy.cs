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
    [SerializeField] private ParticleSystem _system;

    private Animator _animator;
    private Transform _target;
    private Coroutine _coroutine;
    private EnemySpawner _spawner;
    private float _deley = 1;
    private bool _isMoving = true;
    private bool _isDie;

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
        _system.Play();
        if (Store.AttackBonus)
            _health -= damage*Store.AttackPercent;
        else
            _health -= damage;

        if (_health <= 0 && !_isDie)
            Die();
    }

    private void Die()
    {
        _isDie = true;
        _audioSource.Play();
        _isMoving = false;
        LevelWallet.ChangeMoney(_revard);
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
