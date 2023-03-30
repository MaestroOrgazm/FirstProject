using Agava.YandexGames;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    [SerializeField] private int _dimondReward = 1;

    private bool _isFinish = false;
    private string _victory = "Victory";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Car>(out Car car) && !_isFinish)
        {
            _isFinish = true;
            ResoursesWallet.ChangeDimonds(_dimondReward);
            car.gameObject.GetComponent<Level>().LevelUp(); 
            SceneManager.LoadSceneAsync(_victory);
        }
    }
}
