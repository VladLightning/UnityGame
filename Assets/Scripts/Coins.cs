using UnityEngine;

public class Coins : MonoBehaviour
{
    private int _amount;
    private int _coinsIncrease;

    public Coins(int amount, int coinsIncrease)
    {
        _amount = amount;
        _coinsIncrease = coinsIncrease;
    }

    public void AddCoins()
    {
        _amount += _coinsIncrease;
    }

    public void AddIncrease()
    {
        _coinsIncrease++;
    }
    
    public void RemoveCoins()
    {
        _amount = 0;
    }

    public int Amount
    {
        get 
        { 
            return _amount; 
        }
    }
}
