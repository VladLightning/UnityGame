using TMPro;
using UnityEngine;

public class ManageCoins : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinsDisplay;
    private Coins _coins;

    private void Start()
    {
        _coins = new Coins(0,1);
    }

    public void IncreaseAmount()
    {
        _coins.AddCoins();
        _coinsDisplay.text = _coins.Amount.ToString();
    }

    public void DecreaseAmount(int amount)
    {
        _coins.Purchase(amount);
        _coinsDisplay.text = _coins.Amount.ToString();
    }

    public Coins Coins
    {
        get 
        { 
            return _coins;
        }
    }
}
