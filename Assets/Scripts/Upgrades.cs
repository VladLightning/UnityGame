
public class Upgrades 
{
    private Coins _coins;
    private ClickCooldown _clickCooldown;

    public Upgrades(Coins coins, ClickCooldown clickCooldown)
    {
        _coins = coins;
        _clickCooldown = clickCooldown;
    }

    public void UpgradeCoinsIncrement()
    {
        _coins.IncreaseIncrement();
    }

    public void UpgradeClickCooldown()
    {
        _clickCooldown.ReduceCooldown();
    }
}
