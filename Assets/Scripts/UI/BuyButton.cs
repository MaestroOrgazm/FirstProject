using Agava.YandexGames;
using TMPro;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _price = null;

    private int _intPrice;
    private int _videoReward = 5;

    public void BuyCells()
    {
        if (BuyItem())
        {
            Wallet.SetUpgrade();
            gameObject.SetActive(false);
        }
    }
    public void BuyAttack()
    {
        if (BuyItem())
        {
            Wallet.SetAttackBonus();
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
            if (_intPrice <= Wallet.Dimonds)
            {
                Wallet.ChangeDimonds(-_intPrice);
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
        AudioListener.volume = 0;
        Time.timeScale = 0;
    }
    private void GameOn()
    {
            AudioListener.volume = 1;
            Time.timeScale = 1;
    }

    private void Reward()
    {
        Wallet.ChangeDimonds(_videoReward);
    }
}
