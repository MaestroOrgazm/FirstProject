using TMPro;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _price = null;

    private int _intPrice;

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
}
