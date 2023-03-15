using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private GameObject _SettingPannel;
    [SerializeField] private GameObject _ShopPannel;
    [SerializeField] private GameObject _MenuPannel;
    [SerializeField] private AudioSource _MenuSound;
    [SerializeField] private Image _back;

    private float value = 0.005f;
    private Coroutine _coroutine;

    public void OpenSetting()
    {
        _SettingPannel.SetActive(true);
        _MenuPannel.SetActive(false);
        _MenuSound.Play();
    }

    public void ChangeVolume(float volume)
    {
        AudioListener.volume = volume;
    }

    public void ExitSetting()
    {
        _SettingPannel.SetActive(false);
        _MenuPannel.SetActive(true);
        _MenuSound.Play();
    }

    public void OpenShop()
    {
        _ShopPannel.SetActive(true);
        _MenuPannel.SetActive(false);
        _MenuSound.Play();
    }

    public void ExitShop()
    {
        _ShopPannel.SetActive(false);
        _MenuPannel.SetActive(true);
        _MenuSound.Play();
    }

    public void LoadMenu()
    {
        _MenuSound.Play();
        SceneManager.LoadScene("Menu");
    }

    public void LoadLevel()
    {
        _MenuSound.Play();
        _back.raycastTarget = true;
        _coroutine = StartCoroutine(StartBlackBack());
    }

    private IEnumerator StartBlackBack()
    {
        while (_back.color.a < 1)
        {
            Color backColor = _back.color;
            backColor.a += value;
            _back.color = backColor;
            yield return new WaitForEndOfFrame();
        }

        SceneManager.LoadScene("Level");
        Time.timeScale = 1;
    }


}
