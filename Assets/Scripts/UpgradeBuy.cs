using UnityEngine;

public class UpgradeBuy : MonoBehaviour
{
    [SerializeField] private FortuneButtonController _fortuneButtonController;
    private ManageCoins _manageCoins;
    private ClickCooldown _clickCooldown;
    private Upgrades _upgrades;

    private void Start()
    {
        _manageCoins = GetComponent<ManageCoins>();
        _clickCooldown = GetComponent<ClickCooldown>();

        _upgrades = new Upgrades(_manageCoins.Coins, _clickCooldown, _fortuneButtonController);
    }
    
    public void Buy(int price, UpgradeNamesEnum.UpgradeNames name, UpgradeInfo upgradeInfo)
    {
        if(price > _manageCoins.Coins.Amount)
        {
            return;
        }

        upgradeInfo.IncreasePrice();
        _manageCoins.DecreaseAmount(price);
        
        switch (name)
        {
            case UpgradeNamesEnum.UpgradeNames.Increment: _upgrades.UpgradeCoinsIncrement(); break;

            case UpgradeNamesEnum.UpgradeNames.Cooldown: _upgrades.UpgradeClickCooldown(); break;

            case UpgradeNamesEnum.UpgradeNames.Fortune: _upgrades.UpgradeFortune(); break;

            case UpgradeNamesEnum.UpgradeNames.Misfortune: break;
        }
    }
}
