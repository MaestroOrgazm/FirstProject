using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseAndPlay : MonoBehaviour
{
    [SerializeField] private GameObject _pause;
    [SerializeField] private GameObject _add;
    [SerializeField] private GameObject _pannel;

    private string _menu = "Menu";

    public void Pause()
    {
        Time.timeScale = 0;
        _pause.SetActive(false);
        _add.SetActive(false);
        _pannel.SetActive(true);
    }

    public void Play()
    {
        Time.timeScale = 1;
        _pause.SetActive(true);
        _add.SetActive(true);
        _pannel.SetActive(false);
    }

    public void Menu()
    {
        SceneManager.LoadScene(_menu);
    }
}
