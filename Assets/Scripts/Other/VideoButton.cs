using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoButton : MonoBehaviour
{
    public void OnClick()
    {
        Agava.YandexGames.InterstitialAd.Show(GameOff, GameOn);
        this.gameObject.SetActive(false);
    }

    private void GameOff()
    {
        AudioListener.volume = 0;
        Time.timeScale = 0;
    }

    private void GameOn(bool isbool)
    {
        AudioListener.volume = 1;
        Time.timeScale = 1;
    }
}
