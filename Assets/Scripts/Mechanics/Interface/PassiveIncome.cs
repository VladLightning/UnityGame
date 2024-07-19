using System.Collections;
using UnityEngine;

public class PassiveIncome : MonoBehaviour
{
    private const float INCOME_INTERVAL = 1;

    [SerializeField] private ManageCoins _manageCoins;

    public void StartIncome()
    {
        StartCoroutine(Income());
    }

    private IEnumerator Income()
    {
        while (true)
        {
            _manageCoins.IncreaseAmount();
            yield return new WaitForSeconds(INCOME_INTERVAL);
        }
    }
}
