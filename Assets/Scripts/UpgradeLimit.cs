using UnityEngine;

public class UpgradeLimit : ButtonClickLimit
{
    public const string MAX_UPGRADE = "Max upgrade reached";
  
    public override void IncreaseClicksAmount()
    {
        _clicksAmount++;
        if (_clicksAmount >= _clickLimit)
        {
            _button.gameObject.SetActive(false);
            _button.GetComponent<UpgradeInfo>().UpdatePriceDisplay(MAX_UPGRADE);
        }
    }
}
