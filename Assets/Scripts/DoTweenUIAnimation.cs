using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class DoTweenUIAnimation
{
    private const int DELAY = 100;
    private const float ANIMATION_TIME = 0.1f;

    private readonly Vector3 _defaultDisplayPosition;
    private readonly Graphic _objectToAnimate;

    private readonly float _defaultScale;
    private readonly float _targetScale;

    private bool _isAnimationPlaying;

    public DoTweenUIAnimation(Graphic objectToAnimate)
    {
        _defaultDisplayPosition = objectToAnimate.transform.position;
        _objectToAnimate = objectToAnimate;
    }

    public DoTweenUIAnimation(Graphic objectToAnimate, float targetScale)
    {
        _objectToAnimate = objectToAnimate;
        _defaultScale = objectToAnimate.transform.localScale.x;
        _targetScale = targetScale;
    }

    public void StartAnimateText()
    {       
        if (!_isAnimationPlaying)
        {
            AnimateText();
        }
    }

    private async void AnimateText()
    {
        _isAnimationPlaying = true;
        _objectToAnimate.transform.DOMove(_defaultDisplayPosition + Vector3.up, ANIMATION_TIME);

        await Task.Delay(DELAY);

        _objectToAnimate.transform.DOMove(_defaultDisplayPosition, ANIMATION_TIME);
        _isAnimationPlaying = false;
    }

    public void StartAnimateButton()
    {
        if (!_isAnimationPlaying)
        {
            AnimateButton();
        }
    }

    private async void AnimateButton()
    {
        _isAnimationPlaying = true;
        _objectToAnimate.transform.DOScale(_targetScale, ANIMATION_TIME);

        await Task.Delay(DELAY);

        _objectToAnimate.transform.DOScale(_defaultScale, ANIMATION_TIME);
        _isAnimationPlaying = false;
    }

    public void KillTween()
    {
        DOTween.Kill(_objectToAnimate.transform);
    }
}
