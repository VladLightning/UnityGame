using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManageCoins : MonoBehaviour
{
    private const int COINS_LIMIT = 2000000000;

    [SerializeField] private TMP_Text _coinsDisplay;
    [SerializeField] private Button[] _upgradeButtons;
    private Coins _coins;
    private DoTweenAnimateText _animateText;
    private Win _win;

    public Coins Coins { get { return _coins; }  }

    private void Start()
    {
        _coins = new Coins();

        _animateText = GetComponent<DoTweenAnimateText>();
        _win = GetComponent<Win>();
    }

    public void IncreaseAmount()
    {
        _coins.AddCoins();
        _coinsDisplay.text = _coins.Amount.ToString();
        _animateText.Animate();
        CheckAvailableUpgrades();

        if( _coins.Amount >= COINS_LIMIT ) 
        {
            _win.WinGame();
        }
    }

    public void DecreaseAmount(int amount)
    {
        _coins.Purchase(amount);
        _coinsDisplay.text = _coins.Amount.ToString();
        _animateText.Animate();
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
}
