using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public bool IsEmployed { get; private set; } = false;

    public void ChangeValue()
    {
        IsEmployed = !IsEmployed;
    }
}
