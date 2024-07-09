
public class Upgrades 
{
    private const float COOLDOWN_DECREASE = 0.1f;
    private readonly Coins _coins;
    private readonly ClickCooldown _clickCooldown;
    private readonly FortuneButtonController _fortuneButtonController;
    private readonly MisfortuneButtonController _misfortuneButtonController;

    public Upgrades(Coins coins, ClickCooldown clickCooldown, FortuneButtonController fortuneButtonController, MisfortuneButtonController misfortuneButtonController)
    {
        _coins = coins;
        _clickCooldown = clickCooldown;
        _fortuneButtonController = fortuneButtonController;
        _misfortuneButtonController = misfortuneButtonController;
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

    public void UpgradeMisfortune()
    {
        _misfortuneButtonController.IncreaseActivationDelay();
        _misfortuneButtonController.IncreaseWarningTime();
        _misfortuneButtonController.DecreaseCoinsLost();
    }
}
