
public class Upgrades 
{
    private const float COOLDOWN_DECREASE = 0.1f;
    private readonly Coins _coins;
    private readonly ClickCooldown _clickCooldown;
    private readonly FortuneButtonController _fortuneButtonController;

    public Upgrades(Coins coins, ClickCooldown clickCooldown, FortuneButtonController fortuneButtonController)
    {
        _coins = coins;
        _clickCooldown = clickCooldown;
        _fortuneButtonController = fortuneButtonController;
    }

    public void UpgradeCoinsIncrement()
    {
        _coins.IncreaseIncrement();
    }

    public void UpgradeClickCooldown()
    {
        _clickCooldown.CooldownTime -= COOLDOWN_DECREASE;
    }

    public void UpgradeFortune()
    {
        _fortuneButtonController.IncreaseDuration();
        _fortuneButtonController.IncreaseMultiplier();
    }
}
