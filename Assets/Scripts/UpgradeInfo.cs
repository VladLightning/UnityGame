using TMPro;
using UnityEngine;

public class UpgradeInfo : MonoBehaviour
{
    
    [SerializeField] private int _price;
    [SerializeField] private float _priceIncreaseIndex;

    [SerializeField] private UpgradeBuy _upgradeBuy;
    [SerializeField] private UpgradeNamesEnum.UpgradeNames _upgradeName;

    [SerializeField] private TMP_Text _priceDisplay;

    private void Start()
    {
        UpdatePriceDisplay();
    }

    public void BuyUpgrade()
    {
        _upgradeBuy.Buy(_price, _upgradeName, this);
    }

    public void IncreasePrice()
    {
        _price += (int)(_price * _priceIncreaseIndex);
        UpdatePriceDisplay();
    }

    private void UpdatePriceDisplay()
    {
        _priceDisplay.text = _price.ToString();
    }

    public void UpdatePriceDisplay(string text)
    {
        _priceDisplay.text = text;
    }

    public int Price
    {
        get { return _price; }
    }
}
