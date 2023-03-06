using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    [SerializeField] private int _dimondReward = 20;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Car>(out Car car))
        {
            Wallet.ChangeDimonds(_dimondReward);
            car.gameObject.GetComponent<Level>().LevelUp();
            SceneManager.LoadSceneAsync("Victory");
        }
    }
}
