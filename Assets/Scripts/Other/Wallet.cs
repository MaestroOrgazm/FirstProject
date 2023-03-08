using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{
    private static string _strDimonds = "Dimonds";
    private static string _strIsUpgrade = "IsUpgrade";
    private static string _strAttackBonus = "AttackBonus";
    private static int _boolTrue = 1;

    public static int Money { get; private set; } = 15;
    public static int Dimonds { get; private set; }
    public static bool IsUpgrade { get; private set; }
    public static bool AttackBonus { get; private set; }
    public static float Percent { get; private set; } = 1.1f;


    public static event UnityAction<int> MoneyChanged;
    public static event UnityAction<int> DimondsChanged;

    private void Start()
    {
        ChangeDimonds(PlayerPrefs.GetInt(_strDimonds));

        if (PlayerPrefs.GetInt(_strIsUpgrade) == _boolTrue)
            SetUpgrade();

        if (PlayerPrefs.GetInt(_strAttackBonus) == _boolTrue)
            SetAttackBonus();
    }

    public static void ChangeMoney(int money)
    {
        Money += money;
        MoneyChanged?.Invoke(Money);
    }

    public static void ChangeDimonds(int dimonds)
    {
        Dimonds += dimonds;
        DimondsChanged?.Invoke(Dimonds);
        PlayerPrefs.SetInt(_strDimonds, Dimonds);
    }

    public static void SetUpgrade()
    {
        IsUpgrade = true;
        PlayerPrefs.SetInt(_strIsUpgrade, _boolTrue);
    }

    public static void SetAttackBonus()
    {
        AttackBonus = true;
        PlayerPrefs.SetInt(_strAttackBonus, _boolTrue);
    }
}
