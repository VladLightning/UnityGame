using UnityEngine;

public class UpgradeBuy : MonoBehaviour
{
    private Coins _coins;
    private ClickCooldown _clickCooldown;
    private Upgrades _upgrades;

    private void Start()
    {
        _coins = GetComponent<AddCoins>().Coins;
        _clickCooldown = GetComponent<ClickCooldown>();

        _upgrades = new Upgrades(_coins, _clickCooldown);
    }

    public void BuyIncrementIncrease()
    {
        _upgrades.UpgradeCoinsIncrement();
    }

    public void BuyCooldownDecrease()
    {
        _upgrades.UpgradeClickCooldown();
    }
}
