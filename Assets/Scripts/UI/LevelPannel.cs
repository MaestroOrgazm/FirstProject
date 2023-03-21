using TMPro;
using UnityEngine;

public class LevelPannel : MonoBehaviour
{
    [SerializeField] private TMP_Text _count;

    private void OnEnable()
    {
        _count.text = Level.CountLevel.ToString();
    }
}
