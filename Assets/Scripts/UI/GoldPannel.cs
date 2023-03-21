using TMPro;
using UnityEngine;

public class GoldPannel : MonoBehaviour
{
    [SerializeField] private TMP_Text _tmpText;


    private void OnEnable()
    {
        _tmpText.text = $"{Wallet.DeltaMoney}";
        Wallet.MoneyChanged += GoldChange;
    }

    private void OnDisable()
    {
        Wallet.MoneyChanged -= GoldChange;
    }

    private void GoldChange(int gold)
    {
        _tmpText.text = $"{gold}";
    }
}
