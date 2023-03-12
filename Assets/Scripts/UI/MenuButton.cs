using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private GameObject _SettingPannel;
    [SerializeField] private GameObject _ShopPannel;
    [SerializeField] private GameObject _MenuPannel;
    [SerializeField] private AudioSource _MenuSound;

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

    public void LoadLevel()
    {
        _MenuSound.Play();
        SceneManager.LoadScene("Level");
        Time.timeScale = 1;
    }

    public void LoadMenu()
    {
        _MenuSound.Play();
        SceneManager.LoadScene("Menu");
    }

}
