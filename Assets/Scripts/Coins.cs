
public class Coins 
{
    private int _amount;
    private int _coinsIncrement;

    public Coins(int amount, int coinsIncrease)
    {
        _amount = amount;
        _coinsIncrement = coinsIncrease;
    }

    public void AddCoins()
    {
        _amount += _coinsIncrement;
    }

    public void IncreaseIncrement()
    {
        _coinsIncrement += (int)(_coinsIncrement * 0.1f) + 1;
    }
    
    public void Purchase(int price)
    {
        _amount -= price;
    }

    public int Amount
    {
        get 
        { 
            return _amount; 
        }
    }
}
