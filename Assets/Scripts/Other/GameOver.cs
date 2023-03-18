using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            Agava.YandexGames.VideoAd.Show(GameOff, GameOn);
            SceneManager.LoadScene("Over");
        }
    }

    private void GameOff()
    {
        AudioListener.volume = 0;
        Time.timeScale = 0;
    }

    private void GameOn()
    {
        AudioListener.volume = 1;
        Time.timeScale = 1;
    }
}
