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

    private void Start()
    {
        _tmpText.text = _unit.Card.Price.ToString();

        if (Wallet.IsUpgrade)
            _upgrade.SetActive(true);
    }


    public void Spawn()
    {
        if (Wallet.Money >= _unit.Card.Price)
        {
            int countPoint = 6;

            if (Wallet.IsUpgrade)
                countPoint = 9;

            Transform point = GetPoint(countPoint);

            if (point != null)
            {
                Unit unit = null;
                unit = Instantiate(_unit, point);
                unit.SetSpawner(_spawner);
                Wallet.ChangeMoney(-_unit.Card.Price);
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
