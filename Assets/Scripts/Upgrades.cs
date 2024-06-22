
public class Upgrades 
{
    private const float COOLDOWN_DECREASE = 0.1f;
    private readonly Coins _coins;
    private readonly ClickCooldown _clickCooldown;

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
        _clickCooldown.CooldownTime -= COOLDOWN_DECREASE;
    }
}
