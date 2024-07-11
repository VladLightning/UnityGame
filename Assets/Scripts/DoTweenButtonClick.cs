using UnityEngine;
using UnityEngine.UI;

public class DoTweenButtonClick : MonoBehaviour
{
    [SerializeField] private float _defaultScale;
    [SerializeField] private float _targetScale;
    [SerializeField] private float _animationTime;

    private Image _buttonImage;

    private DoTweenUIAnimation _doTweenUIAnimation;

    private void Start()
    {
        _buttonImage = GetComponent<Image>();

        _doTweenUIAnimation = new DoTweenUIAnimation();
    }

    public void OnClick()
    {
        _doTweenUIAnimation.StartAnimateButton(_buttonImage, _defaultScale, _targetScale, _animationTime);
    }

    private void OnDisable()
    {
        _doTweenUIAnimation.KillTween(_buttonImage);
    }
}
