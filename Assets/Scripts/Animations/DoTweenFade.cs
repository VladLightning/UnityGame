using UnityEngine;
using UnityEngine.UI;

public class DoTweenFade : Animations
{
    [SerializeField] private float _fadeTime;
    [SerializeField] private float _fadeMinValue;
    [SerializeField] private float _fadeMaxValue;

    [SerializeField] private MisfortuneButtonController _misfortuneButtonController;
    private int _animationTicks;

    protected override void Awake()
    {
        _objectToAnimate = GetComponent<Image>();
        base.Awake();
    }

    public override void Animate()
    {
        _animationTicks = (int)(_misfortuneButtonController.WarningTime / _fadeTime);
        _doTweenUIAnimation.StartFade(_objectToAnimate, _fadeMinValue, _fadeMaxValue, _fadeTime, _animationTicks, this);
    }

    private void OnEnable()
    {       
        Animate();
    }

    protected override void OnDisable()
    {
        StopAllCoroutines();
        base.OnDisable();
    }
}
