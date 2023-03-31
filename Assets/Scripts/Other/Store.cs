using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Store : MonoBehaviour
{
    [SerializeField] private AudioSource _MenuSound = null;

    private static string _strDimonds = "Dimonds";
    private static string _strIsUpgrade = "IsUpgrade";
    private static string _strAttackBonus = "AttackBonus";
    private static int _boolTrue = 1;

    public static string Name = "Anonim";
    public static int Dimonds { get; private set; }
    public static bool IsUpgrade { get; private set; }
    public static bool AttackBonus { get; private set; }
    public static float AttackPercent { get; private set; } = 1.1f;

    public static event UnityAction<int> DimondsChanged;

    private void Start()
    {
        SetDimonds(PlayerPrefs.GetInt(_strDimonds));

        if (PlayerPrefs.GetInt(_strIsUpgrade) == _boolTrue)
            SetUpgrade();

        if (PlayerPrefs.GetInt(_strAttackBonus) == _boolTrue)
            SetAttackBonus();
    }

    public void ZeroProgress()
    {
        _MenuSound.Play();
        Level.SetLevelOne();
        PlayerPrefs.SetInt(_strIsUpgrade, 0);
        PlayerPrefs.SetInt(_strAttackBonus, 0);
        PlayerPrefs.SetInt(_strDimonds, 0);
        SetDimonds(PlayerPrefs.GetInt(_strDimonds));
        SceneManager.LoadScene("Menu");
    }

    public static void ChangeDimonds(int dimonds)
    {
        Dimonds += dimonds;
        DimondsChanged?.Invoke(Dimonds);
        PlayerPrefs.SetInt(_strDimonds, Dimonds);
    }
    public static void SetDimonds(int dimonds)
    {
        Dimonds = dimonds;
        DimondsChanged?.Invoke(Dimonds);
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