using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Unit))]

public class UnitLevel : MonoBehaviour
{
    [SerializeField] private TMP_Text _tmpText;

    private UnitCard _unitCard;

    private void Start()
    {
        _unitCard = GetComponent<Unit>().Card;

        if (gameObject.GetComponentInParent<SpawnPoint>())
            _tmpText.text += _unitCard.Grade.ToString();
        else
            _tmpText.text = null;
    }
}
