using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private EnemySpawner _spawner;
    [SerializeField] private Car _car;
    [SerializeField] private Transform _teleportTarget;

    private static string _strCountLevel = "CountLevel";
    public static int CountLevel { get; private set; } = 1;

    private int _count = 0;
    private float _value;

    private void OnEnable()
    {
        CountLevel = PlayerPrefs.GetInt(_strCountLevel);
        
        if (_spawner != null )
            _spawner.ChanceUp(CountLevel);
    }

    public static void SetLevelOne()
    {
        CountLevel = 1;
        PlayerPrefs.SetInt(_strCountLevel, CountLevel);
    }

    public void StartTeleport(Transform target)
    {
        if (_count < CountLevel)
        {
            _value = target.transform.position.x - _teleportTarget.transform.position.x;
            _car.Teleport(_value);
            _spawner.Teleport(_value);
            _count++;
        }
    }

    public void LevelUp()
    {
        CountLevel++;
        PlayerPrefs.SetInt(_strCountLevel, CountLevel);
    }
}
