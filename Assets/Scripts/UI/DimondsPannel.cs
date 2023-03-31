using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DimondsPannel : MonoBehaviour
{
    [SerializeField] private TMP_Text _tmpText;

    private void OnEnable()
    {
        _tmpText.text = Store.Dimonds.ToString();
        Store.DimondsChanged += DimondsChange;
    }

    private void OnDisable()
    {
        Store.DimondsChanged -= DimondsChange;
    }

    private void DimondsChange(int dimonds)
    {
        _tmpText.text = $"{dimonds}";
    }
}
