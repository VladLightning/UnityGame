using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManageCoins : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinsDisplay;
    [SerializeField] private Button[] _upgradeButtons;
    private Coins _coins;

    private void Start()
    {
        _coins = new Coins();
    }

    public void IncreaseAmount()
    {
        _coins.AddCoins();
        _coinsDisplay.text = _coins.Amount.ToString();
        CheckAvailableUpgrades();
    }

    public void DecreaseAmount(int amount)
    {
        _coins.Purchase(amount);
        _coinsDisplay.text = _coins.Amount.ToString();
        CheckAvailableUpgrades();
    }

    private void CheckAvailableUpgrades()
    {
        for(int i = 0; i < _upgradeButtons.Length; i++)
        {
            var upgradeInfo = _upgradeButtons[i].GetComponent<UpgradeInfo>();

            _upgradeButtons[i].interactable = upgradeInfo.Price <= _coins.Amount;
        }
    }

    public Coins Coins
    {
        get 
        { 
            return _coins;
        }
    }
}
