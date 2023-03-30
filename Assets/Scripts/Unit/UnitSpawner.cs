using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    [SerializeField] private TMP_Text _tmpText;
    [SerializeField] private Unit _unit;
    [SerializeField] private SpawnPoint[] _spawnPoints;
    [SerializeField] private GameObject _upgrade;
    [SerializeField] private EnemySpawner _spawner;

    private int _price = 0;
    private int _priceUp = 5;
    private int _minCells = 6;
    private int _maxCells = 9;

    private void Start()
    {
        _tmpText.text = _price.ToString();

        if (ResoursesWallet.IsUpgrade)
            _upgrade.SetActive(true);
    }


    public void Spawn()
    {
        if (LevelWallet.Money >= _price)
        {
            int countPoint = _minCells;

            if (ResoursesWallet.IsUpgrade)
                countPoint = _maxCells;

            Transform point = GetPoint(countPoint);

            if (point != null)
            {
                Unit unit = null;
                unit = Instantiate(_unit, point);
                unit.SetSpawner(_spawner);
                LevelWallet.ChangeMoney(-_price);
                _price += _priceUp;
                _tmpText.text = _price.ToString();
            }
        }
    }

    private Transform GetPoint(int countpoint)
    {
        for (int i = 0; i < countpoint; i++)
        {
            if (_spawnPoints[i].IsEmployed == false)
            {
                _spawnPoints[i].ChangeValue();
                return _spawnPoints[i].transform;
            }
        }

        return null;
    }
}
