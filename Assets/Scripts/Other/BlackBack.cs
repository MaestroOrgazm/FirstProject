using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackBack : MonoBehaviour
{
    [SerializeField] private Image _back;

    private float value = 0.001f;

    private void Update()
    {
        Color backColor = _back.color;
        backColor.a -= value;
        _back.color = backColor;
    }
}
