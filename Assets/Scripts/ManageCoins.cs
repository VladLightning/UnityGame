using System.Collections;
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
        StartCoroutine(CheckAvailableUpgrades());
    }

    public void DecreaseAmount(int amount)
    {
        _coins.Purchase(amount);
        _coinsDisplay.text = _coins.Amount.ToString();
        StartCoroutine(CheckAvailableUpgrades());
    }

    private IEnumerator CheckAvailableUpgrades()
    {
        yield return new WaitForEndOfFrame();
        for(int i = 0; i < _upgradeButtons.Length; i++)
        {
            var upgradeInfo = _upgradeButtons[i].GetComponent<UpgradeInfo>();

            if (upgradeInfo.Price <= _coins.Amount)
            {
                _upgradeButtons[i].interactable = true;
            }
            else if(upgradeInfo.Price > _coins.Amount && _upgradeButtons[i].interactable == true)
            {
                _upgradeButtons[i].interactable = false;
            }
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
