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
    [SerializeField] private GameObject _LeaderPannel;
    [SerializeField] private GameObject _NamePannel;
    [SerializeField] private GameObject _keyPannel;
    [SerializeField] private AudioSource _MenuSound;
    [SerializeField] private Slider _slider;
    [SerializeField] private Image _back;
    [SerializeField] private TMP_InputField _text;
    [SerializeField] private TMP_Text _placeholder;

    private float value = 0.005f;
    private Coroutine _coroutine;

    private void Start()
    {
        if(_placeholder != null)
        _placeholder.text = Wallet.Name;

        if (_slider != null)
            _slider.value = AudioListener.volume;
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
        _placeholder.text = Wallet.Name;
    }

    public void OnSelect()
    {
        _MenuPannel.SetActive(false);
        _keyPannel.SetActive(true);
    }

    public void Ok()
    {
        _MenuPannel.SetActive(true);
        _keyPannel.SetActive(false);
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
