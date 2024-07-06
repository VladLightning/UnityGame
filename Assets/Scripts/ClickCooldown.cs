using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ClickCooldown : MonoBehaviour
{
    public const float FILL_AMOUNT = 0.025f;
    public const float DELAY_MODIFIER = 40;

    [SerializeField] private float _cooldownTime;

    private Button _button;
    private Image _image;

    public float CooldownTime { set { _cooldownTime = value; } get { return _cooldownTime; }  }

    private void Start()
    {
        _button = GetComponent<Button>();
        _image = _button.GetComponent<Image>();
    }

    public void StartCooldown()
    {
        if (_cooldownTime > 0.1f)
        {
            StartCoroutine(Cooldown());
        }
    }

    private IEnumerator Cooldown()
    {
        _button.interactable = false;
        _image.fillAmount = 0;
        while (_image.fillAmount < 1)
        {
            _image.fillAmount += FILL_AMOUNT;
            yield return new WaitForSeconds(_cooldownTime/DELAY_MODIFIER);
        }

        _button.interactable = true;
    }
}
