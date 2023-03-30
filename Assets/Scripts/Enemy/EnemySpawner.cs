using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _smallEnemy;
    [SerializeField] private Enemy _mediumEnemy;
    [SerializeField] private Enemy _bigEnemy;
    [SerializeField] private int _countEnemy = 10;
    [SerializeField] private float _spawnTime = 0.2f;
    [SerializeField] private float _randomDistanse = 3;

    private float _chanceMediumEnemy = 20;
    private float _chanceBigEnemy = 9;
    private int _delataMedium = 2;
    private int _deltaBig = 4;
    private Transform _target;
    private int _maxChance = 1;
    private int _maxChanceBig = 2;
    private float _lastTime = 1;
    private float _allCount = 1;
    private int _deltaFlip = 90;
    private Vector3 _randomPosition;

    public  List<Enemy> EnemyList { get; private set; } = new();

    private void FixedUpdate()
    {
        if (_target != null)
            Spawn();
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    public void DeleteEnemy(Enemy enemy)
    {
        EnemyList.Remove(enemy);
    }

    public void ChanceUp(int countLevel)
    {
        if (_chanceMediumEnemy > _maxChance && _chanceBigEnemy > _maxChanceBig)
        {
            _chanceBigEnemy -= countLevel/_deltaBig;
            _chanceMediumEnemy -= countLevel/_delataMedium;
        }
        else
        {
            _chanceBigEnemy = _maxChanceBig;
            _chanceMediumEnemy = _maxChance;
        }
    }

    public void Teleport(float value)
    {
        for (int i = 0; i < EnemyList.Count; i++)
        {

            Vector3 target = new Vector3(EnemyList[i].transform.position.x - value,
            EnemyList[i].transform.position.y, EnemyList[i].transform.position.z);

            EnemyList[i].transform.position = target;
        }
    }

    private void Spawn()
    {
        _randomPosition = new Vector3(0, 0, Random.Range(-_randomDistanse, _randomDistanse));
        Enemy enemy = null;
        _lastTime -= Time.deltaTime;

        if (EnemyList.Count < _countEnemy && _lastTime <= 0)
        {
            Vector3 instPoint = transform.position;
            instPoint += _randomPosition;

            if (_allCount % _chanceMediumEnemy == 0)
                enemy = Instantiate(_bigEnemy, instPoint, Quaternion.identity);
            else if (_allCount % _chanceBigEnemy == 0)
                enemy = Instantiate(_mediumEnemy, instPoint, Quaternion.identity);
            else
                enemy = Instantiate(_smallEnemy, instPoint, Quaternion.identity);

            _allCount++;
            EnemyList.Add(enemy);
            enemy.SetPath(_target, this);
            enemy.transform.eulerAngles = new Vector3(0, _deltaFlip, 0);
            enemy.transform.SetParent(null);
            _lastTime = _spawnTime;
        }
    }
}
