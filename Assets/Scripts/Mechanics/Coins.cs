
public class Coins 
{
    private int _amount;
    private int _coinsIncrement = 1;
    private float _incrementMultiplier = 1;

    public int Amount { get { return _amount; } }

    public float IncrementMultiplier { set { _incrementMultiplier = value; } }

    public void AddCoins()
    {
        _amount += (int)(_coinsIncrement * _incrementMultiplier);
    }

    public void IncreaseIncrement()
    {
        _coinsIncrement += (int)(_coinsIncrement * 0.1f) + 1;
    }

    public void Purchase(int price)
    {
        _amount -= price;
    }
}
