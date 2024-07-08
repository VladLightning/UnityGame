using System.Collections;
using UnityEngine;

public class MisfortuneButtonController : MonoBehaviour
{
    private const float DELAY_INCREASE = 5;
    private const float COEFFICIENT_DECREASE = 0.2f;

    [SerializeField] private GameObject _misfortuneButton;
    [SerializeField] private ManageCoins _manageCoins;

    [SerializeField] private float _activationDelay;
    [SerializeField] private float _deactivationDelay;

    [SerializeField] private float _coefficientOfCoinsLost;

    private IEnumerator _deactivate;

    private void Start()
    {
        _deactivate = DeactivateTimer();
        StartCoroutine(ActivateTimer());
    }

    public void IncreaseActivationDelay()
    {
        _activationDelay += DELAY_INCREASE;
    }

    public void DecreaseCoinsLost()
    {
        _coefficientOfCoinsLost -= COEFFICIENT_DECREASE;
        if(_coefficientOfCoinsLost < 0.2f)
        {
            StopAllCoroutines();
            Destroy(gameObject);
        }
    }

    public void OnClick()
    {
        LoseCoins();
        Deactivate();
    }

    private void Activate()
    {
        _misfortuneButton.SetActive(true);
        StartCoroutine(_deactivate);
    }

    private void Deactivate()
    {
        StopCoroutine(_deactivate);

        _misfortuneButton.SetActive(false);
        StartCoroutine(ActivateTimer());

        _deactivate = DeactivateTimer();
    }

    private IEnumerator ActivateTimer()
    {
        yield return new WaitForSeconds(_activationDelay);
        Activate();
    }

    private IEnumerator DeactivateTimer()
    {
        yield return new WaitForSeconds(_deactivationDelay);
        Deactivate();
    }

    private void LoseCoins()
    {
        _manageCoins.DecreaseAmount((int)(_manageCoins.Coins.Amount * _coefficientOfCoinsLost));
    }
}