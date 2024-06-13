using UnityEngine;

public class UpgradeBuy : MonoBehaviour
{
    private ManageCoins _manageCoins;
    private ClickCooldown _clickCooldown;
    private Upgrades _upgrades;

    private void Start()
    {
        _manageCoins = GetComponent<ManageCoins>();
        _clickCooldown = GetComponent<ClickCooldown>();

        _upgrades = new Upgrades(_manageCoins.Coins, _clickCooldown);
    }

    public void Buy(int price, string name, UpgradeInfo upgradeInfo)
    {
        if(price > _manageCoins.Coins.Amount)
        {
            Debug.Log("Not enough money");
            return;
        }
        

        switch (name)
        {
            case "Increment":

                _manageCoins.DecreaseAmount(price);
                _upgrades.UpgradeCoinsIncrement();

                upgradeInfo.IncreasePrice();

                break;

            case "Cooldown":

                _manageCoins.DecreaseAmount(price);
                _upgrades.UpgradeClickCooldown();

                upgradeInfo.IncreasePrice();

                break;
        }
    }
}
