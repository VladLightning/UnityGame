using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FortuneButtonController : MonoBehaviour
{
    private const float X_RESTRICTION = 100;
    private const float Y_RESTRICTION = 200;

    private const float INCREASE_MULTIPLIER = 0.25f;
    private const float INCREASE_DURATION = 0.1f;

    [SerializeField] private GameObject _fortuneButton;
    [SerializeField] private ManageCoins _manageCoins;
    [SerializeField] private Camera _camera;

    [SerializeField] private float _activationDelay;
    [SerializeField] private float _deactivationDelay;

    [SerializeField] private float _incrementMultiplier;
    [SerializeField] private float _multiplierDuration;

    private IEnumerator _activate;
    private IEnumerator _deactivate;

    private void Start()
    {
        _activate = ActivateTimer();
        _deactivate = DeactivateTimer();
        StartCoroutine(_activate);
    }

    public void IncreaseMultiplier()
    {
        _incrementMultiplier += INCREASE_MULTIPLIER;
    }

    public void IncreaseDuration()
    {
        _multiplierDuration += _multiplierDuration * INCREASE_DURATION;
    }

    public void OnClick()
    {
        StartCoroutine(ActivateIncrementMultiplier());
        Deactivate();
    }

    private void RandomizePosition()
    {
        _fortuneButton.transform.position = (Vector2)_camera.ScreenToWorldPoint(
        new Vector2(Random.Range(X_RESTRICTION, Screen.currentResolution.width - X_RESTRICTION), 
                    Random.Range(Y_RESTRICTION, Screen.currentResolution.height - Y_RESTRICTION)));
    }

    private void Activate()
    {
        RandomizePosition();

        _fortuneButton.SetActive(true);
        StartCoroutine(_deactivate);

        _activate = ActivateTimer();
    }

    private void Deactivate()
    {
        StopCoroutine(_deactivate);

        _fortuneButton.SetActive(false);
        StartCoroutine(_activate);

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

    private IEnumerator ActivateIncrementMultiplier()
    {
        _manageCoins.Coins.IncrementMultiplier = _incrementMultiplier;
        yield return new WaitForSeconds(_multiplierDuration);
        _manageCoins.Coins.IncrementMultiplier = 1;
    }
}
