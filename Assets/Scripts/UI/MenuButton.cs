using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private GameObject _SettingPannel;
    [SerializeField] private GameObject _ShopPannel;
    [SerializeField] private GameObject _MenuPannel;

    public void OpenSetting()
    {
        _SettingPannel.SetActive(true);
        _MenuPannel.SetActive(false);
    }

    public void ExitSetting()
    {
        _SettingPannel.SetActive(false);
        _MenuPannel.SetActive(true);
    }

    public void OpenShop()
    {
        _ShopPannel.SetActive(true);
        _MenuPannel.SetActive(false);
    }

    public void ExitShop()
    {
        _ShopPannel.SetActive(false);
        _MenuPannel.SetActive(true);
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("Level");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
