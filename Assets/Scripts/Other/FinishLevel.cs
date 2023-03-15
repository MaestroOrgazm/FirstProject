using Agava.YandexGames;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    [SerializeField] private int _dimondReward = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Car>(out Car car))
        {
            Agava.YandexGames.VideoAd.Show(GameOff, GameOn);
            Wallet.ChangeDimonds(_dimondReward);
            car.gameObject.GetComponent<Level>().LevelUp();
            SceneManager.LoadSceneAsync("Victory");
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
