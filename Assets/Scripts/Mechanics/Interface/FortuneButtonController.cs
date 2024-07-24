using System.Collections;
using UnityEngine;

public class FortuneButtonController : MonoBehaviour
{
    private const float BORDER_PERCENTAGE = 0.1f;

    private const float INCREASE_MULTIPLIER = 0.25f;
    private const float INCREASE_DURATION = 0.1f;

    [SerializeField] private GameObject _fortuneButton;
    [SerializeField] private ManageCoins _manageCoins;
    [SerializeField] private Camera _camera;

    [SerializeField] private float _activationDelay;
    [SerializeField] private float _deactivationDelay;

    [SerializeField] private float _incrementMultiplier;
    [SerializeField] private float _multiplierDuration;

    private float _borderRestrictionX;
    private float _borderRestrictionY;

    private IEnumerator _deactivate;

    private void Start()
    {
        _deactivate = DeactivateTimer();
        StartCoroutine(ActivateTimer());
    }

    private void RandomizePosition()
    {
        _fortuneButton.transform.position = (Vector2)_camera.ScreenToWorldPoint(
        new Vector2(Random.Range(_borderRestrictionX, Screen.currentResolution.width - _borderRestrictionX), 
                    Random.Range(_borderRestrictionY, Screen.currentResolution.height - _borderRestrictionY)));
    }

    private void Activate()
    {
        RandomizePosition();

        _fortuneButton.SetActive(true);
        StartCoroutine(_deactivate);
    }

    private void Deactivate()
    {
        StopCoroutine(_deactivate);

        _fortuneButton.SetActive(false);
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

    private IEnumerator ActivateIncrementMultiplier()
    {
        _manageCoins.Coins.IncrementMultiplier = _incrementMultiplier;
        yield return new WaitForSeconds(_multiplierDuration);
        _manageCoins.Coins.IncrementMultiplier = 1;
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

    public void SetScreenBorders()
    {
        _borderRestrictionX = Screen.currentResolution.width * BORDER_PERCENTAGE;
        _borderRestrictionY = Screen.currentResolution.height * BORDER_PERCENTAGE;
    }
}
