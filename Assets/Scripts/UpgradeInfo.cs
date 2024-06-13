using UnityEngine;

public class UpgradeInfo : MonoBehaviour
{
    [SerializeField] private UpgradeBuy _upgradeBuy;

    [SerializeField] private int _price;
    [SerializeField] private float _priceIncreaseIndex;

    [SerializeField] private string _upgradeName;

    public void BuyUpgrade()
    {
        _upgradeBuy.Buy(_price, _upgradeName, this);
    }

    public void IncreasePrice()
    {
        _price += (int)(_price * _priceIncreaseIndex);
    }

    public int Price
    {
        get 
        {
            return _price; 
        }
    }
}
