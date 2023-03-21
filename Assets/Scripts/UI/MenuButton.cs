using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private GameObject _SettingPannel;
    [SerializeField] private GameObject _ShopPannel;
    [SerializeField] private GameObject _MenuPannel;
    [SerializeField] private GameObject _okButton;
    [SerializeField] private GameObject _LeaderPannel;
    [SerializeField] private GameObject _NamePannel;
    [SerializeField] private GameObject _keyPannel;
    [SerializeField] private GameObject _okPannel;
    [SerializeField] private AudioSource _MenuSound;
    [SerializeField] private Image _back;
    [SerializeField] private TMP_Text _text;

    private float value = 0.005f;
    private Coroutine _coroutine;

    private void Start()
    {
        if (_text != null)
            _text.text = Wallet.Name;
    }

    public void OpenSetting()
    {
        _NamePannel.SetActive(false);
        _SettingPannel.SetActive(true);
        _MenuPannel.SetActive(false);
        _MenuSound.Play();
    }

    public void OpenLeaderboard()
    {
        _NamePannel.SetActive(false);
        _MenuPannel.SetActive(false);
        _LeaderPannel.SetActive(true);
        _MenuSound.Play();
    }

    public void CloseLeaderbord()
    {
        _NamePannel.SetActive(true);
        _MenuPannel.SetActive(true);
        _LeaderPannel.SetActive(false);
        _MenuSound.Play();
    }

    public void ChangeName(string name)
    {
        Wallet.Name = name;
        _text.text = name;
    }

    public void OnSelect()
    {
        _text.text = "";
        _MenuPannel.SetActive(false);
        _keyPannel.SetActive(true);
        _okPannel.SetActive(true);
    }

    public void Ok()
    {
        _text.text = Wallet.Name;
        _MenuPannel.SetActive(true);
        _keyPannel.SetActive(false);
        _okPannel.SetActive(false);
    }

    public void ChangeVolume(float volume)
    {
        AudioListener.volume = volume;
    }

    public void ExitSetting()
    {
        _NamePannel.SetActive(true);
        _SettingPannel.SetActive(false);
        _MenuPannel.SetActive(true);
        _MenuSound.Play();
    }

    public void OpenShop()
    {
        _NamePannel.SetActive(false);
        _ShopPannel.SetActive(true);
        _MenuPannel.SetActive(false);
        _MenuSound.Play();
    }

    public void ExitShop()
    {
        _NamePannel.SetActive(true);
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
        _back.raycastTarget = true;
        _MenuSound.Play();
        _coroutine = StartCoroutine(StartBlackBack());
    }

    public void LoadLevelAfter()
    {
        SceneManager.LoadScene("Level");
        Time.timeScale = 1;
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
