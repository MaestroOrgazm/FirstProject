using Agava.YandexGames;
using TMPro;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _price = null;

    private int _intPrice;
    private int _videoReward = 5;
    private float _volume = 5;

    public void BuyCells()
    {
        if (BuyItem())
        {
            Store.SetUpgrade();
            gameObject.SetActive(false);
        }
    }
    public void BuyAttack()
    {
        if (BuyItem())
        {
            Store.SetAttackBonus();
            gameObject.SetActive(false);
        }
    }

    public void FreeVideo()
    {
        Agava.YandexGames.VideoAd.Show(GameOff,Reward, GameOn);
    }

    private bool BuyItem()
    {
        if(int.TryParse(_price.text, out _intPrice))
        {
            if (_intPrice <= Store.Dimonds)
            {
                Store.ChangeDimonds(-_intPrice);
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    private void GameOff()
    {
        _volume = AudioListener.volume;
        AudioListener.volume = 0;
        Time.timeScale = 0;
    }
    private void GameOn()
    {
            AudioListener.volume = _volume;
            Time.timeScale = 1;
    }

    private void Reward()
    {
        Store.ChangeDimonds(_videoReward);
    }
}
