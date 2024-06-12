using UnityEngine;

public class UpgradePrice : MonoBehaviour
{
    [SerializeField] private int _price;
    [SerializeField] private float _priceIncreaseIndex;

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
