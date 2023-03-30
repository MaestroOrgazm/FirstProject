using TMPro;
using UnityEngine;

public class GoldPannel : MonoBehaviour
{
    [SerializeField] private TMP_Text _tmpText;

    private void OnEnable()
    {
        _tmpText.text = LevelWallet.Money.ToString();
        LevelWallet.MoneyChanged += GoldChange;
    }

    private void OnDisable()
    {
        LevelWallet.MoneyChanged -= GoldChange;
    }

    private void GoldChange(int gold)
    {
        _tmpText.text = $"{gold}";
    }
}
