using UnityEngine;
using UnityEngine.UI;

public class DoTweenButtonClick : Animations
{
    [SerializeField] private float _sizeMultiplier;
    [SerializeField] private float _animationTime;

    private Image _buttonImage;

    protected override void Awake()
    {
        _buttonImage = GetComponent<Image>();
        base.Awake();
    }

    public override void Animate()
    {
        _doTweenUIAnimation.StartAnimateButton(_buttonImage, _sizeMultiplier, _animationTime);
    }
}
