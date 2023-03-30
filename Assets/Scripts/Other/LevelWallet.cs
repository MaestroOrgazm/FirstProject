using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelWallet : MonoBehaviour
{
    private int _deltaMoney = 15;
    public static int Money { get; private set; }

    public static event UnityAction<int> MoneyChanged;

    private void Awake()
    {
        Money = _deltaMoney;
        Debug.Log(Money);
    }

    public static void ChangeMoney(int money)
    {
        Money += money;
        MoneyChanged?.Invoke(Money);
    }
}
