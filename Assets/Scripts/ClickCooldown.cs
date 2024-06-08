using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ClickCooldown : MonoBehaviour
{
    [SerializeField] private float _cooldownTime;

    private Button _button;
    private Image _image;

    private void Start()
    {
        _button = GetComponent<Button>();
        _image = _button.GetComponent<Image>();
    }

    public void StartCooldown()
    {
        StartCoroutine(Cooldown());
    }

    private IEnumerator Cooldown()
    {
        if (_cooldownTime < 0.1f)
        {
            yield break; 
        }

        _button.interactable = false;
        _image.fillAmount = 0;

        while(_image.fillAmount < 1)
        {
            _image.fillAmount += 0.025f;
            yield return new WaitForSeconds(_cooldownTime/40);
        }

        _button.interactable = true;
    }
}
