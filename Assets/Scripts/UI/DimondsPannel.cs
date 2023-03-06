using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DimondsPannel : MonoBehaviour
{
    [SerializeField] private TMP_Text _tmpText;

    private void OnEnable()
    {
        _tmpText.text = $"{Wallet.Dimonds}";
        Wallet.DimondsChanged += DimondsChange;
    }

    private void OnDisable()
    {
        Wallet.DimondsChanged -= DimondsChange;
    }

    private void DimondsChange(int dimonds)
    {
        _tmpText.text = $"{dimonds}";
    }
}
