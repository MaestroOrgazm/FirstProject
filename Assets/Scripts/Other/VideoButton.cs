using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoButton : MonoBehaviour
{
    private float _volume;

    public void OnClick()
    {
        Agava.YandexGames.InterstitialAd.Show(GameOff, GameOn);
        this.gameObject.SetActive(false);
    }

    private void GameOff()
    {
        _volume = AudioListener.volume;
        AudioListener.volume = 0;
        Time.timeScale = 0;
    }

    private void GameOn(bool isbool)
    {
        AudioListener.volume = _volume;
        Time.timeScale = 1;
    }
}
