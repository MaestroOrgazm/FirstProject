using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPannel : MonoBehaviour
{
    [SerializeField] private GameObject _pause;
    [SerializeField] private GameObject _add;
    [SerializeField] private GameObject _gold;
    [SerializeField] private GameObject _firstSlide;
    [SerializeField] private GameObject _secondSlide;

    private void Start()
    {
        if(Level.CountLevel == 1)
        {
            Time.timeScale = 0;
            _pause.SetActive(false);
            _add.SetActive(false);
            _gold.SetActive(false);
            _firstSlide.SetActive(true);
        }
    }

    public void NextSlide()
    {
        _firstSlide.SetActive(false);
        _secondSlide.SetActive(true);
    }

    public void TutorialOk()
    {
        Time.timeScale = 1;
        _pause.SetActive(true);
        _add.SetActive(true);
        _gold.SetActive(true);
        _secondSlide.SetActive(false);
    }
}
