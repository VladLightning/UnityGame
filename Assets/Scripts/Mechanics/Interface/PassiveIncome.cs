using System.Collections;
using UnityEngine;

public class PassiveIncome : MonoBehaviour
{
    private const float INCOME_INTERVAL_DECREASE = 0.1f;

    [SerializeField] private ManageCoins _manageCoins;

    [SerializeField] private float _incomeInterval;

    private bool _incomeEnabled;

    private void DecreaseInterval()
    {
        _incomeInterval -= INCOME_INTERVAL_DECREASE;
    }

    private void StartIncome()
    {
        StartCoroutine(Income());
    }

    private IEnumerator Income()
    {
        while (true)
        {
            _manageCoins.IncreaseAmount();
            yield return new WaitForSeconds(_incomeInterval);
        }
    }

    public void UpgradeIncome()
    {
        if (!_incomeEnabled)
        {
            StartIncome();
            _incomeEnabled = true;
            return;
        }
        DecreaseInterval();
    }
}
