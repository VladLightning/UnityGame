using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DoTweenFade : MonoBehaviour
{
    [SerializeField] private float _fadeTime;
    [SerializeField] private float _fadeMinValue;
    [SerializeField] private float _fadeMaxValue;

    private Image _image;

    private DoTweenUIAnimation _doTweenUIAnimation;

    private void Awake()
    {
        _image = GetComponent<Image>();

        _doTweenUIAnimation = new DoTweenUIAnimation();
    }

    private void OnEnable()
    {
        _doTweenUIAnimation.StartFade(_image, _fadeMinValue, _fadeMaxValue, _fadeTime);
    }

    private void OnDisable()
    {
        _doTweenUIAnimation.KillTween(_image);
    }
}
