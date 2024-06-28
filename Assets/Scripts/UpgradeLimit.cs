
public class UpgradeLimit : ButtonClickLimit
{
    private const string MAX_UPGRADE = "Max upgrade reached";
  
    protected override void ReachClickLimit()
    {
        _button.gameObject.SetActive(false);
        _button.GetComponent<UpgradeInfo>().UpdatePriceDisplay(MAX_UPGRADE);
    }
}
