using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private GameObject _settingPannel;
    [SerializeField] private GameObject _shopPannel;
    [SerializeField] private GameObject _menuPannel;
    [SerializeField] private GameObject _leaderPannel;
    [SerializeField] private GameObject _namePannel;
    [SerializeField] private GameObject _keyPannel;
    [SerializeField] private AudioSource _menuSound;
    [SerializeField] private Slider _slider;
    [SerializeField] private Image _back;
    [SerializeField] private TMP_InputField _text;
    [SerializeField] private TMP_Text _placeholder;

    private float value = 0.005f;
    private Coroutine _coroutine;

    private void Start()
    {
        if(_placeholder != null)
        _placeholder.text = ResoursesWallet.Name;

        if (_slider != null)
            _slider.value = AudioListener.volume;
    }

    public void OpenSetting()
    {
        _namePannel.SetActive(false);
        _settingPannel.SetActive(true);
        _menuPannel.SetActive(false);
        _menuSound.Play();
    }

    public void OpenLeaderboard()
    {
        _namePannel.SetActive(false);
        _menuPannel.SetActive(false);
        _leaderPannel.SetActive(true);
        _menuSound.Play();
    }

    public void CloseLeaderbord()
    {
        _namePannel.SetActive(true);
        _menuPannel.SetActive(true);
        _leaderPannel.SetActive(false);
        _menuSound.Play();
    }

    public void ChangeName(string name)
    {
        ResoursesWallet.Name = name;
        _text.text = name;
        _placeholder.text = ResoursesWallet.Name;
    }

    public void OnSelect()
    {
        _menuPannel.SetActive(false);
        _keyPannel.SetActive(true);
    }

    public void Ok()
    {
        _menuPannel.SetActive(true);
        _keyPannel.SetActive(false);
    }

    public void ChangeVolume(float volume)
    {
        AudioListener.volume = volume;
    }

    public void ExitSetting()
    {
        _namePannel.SetActive(true);
        _settingPannel.SetActive(false);
        _menuPannel.SetActive(true);
        _menuSound.Play();
    }

    public void OpenShop()
    {
        _namePannel.SetActive(false);
        _shopPannel.SetActive(true);
        _menuPannel.SetActive(false);
        _menuSound.Play();
    }

    public void ExitShop()
    {
        _namePannel.SetActive(true);
        _shopPannel.SetActive(false);
        _menuPannel.SetActive(true);
        _menuSound.Play();
    }

    public void LoadMenu()
    {
        _menuSound.Play();
        SceneManager.LoadScene("Menu");
    }

    public void LoadLevel()
    {
        _back.raycastTarget = true;
        _menuSound.Play();
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
