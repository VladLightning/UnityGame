using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class DoTweenUIAnimation
{
    private const int ANIMATION_TIME_MODIFIER = 1000;

    private bool _isAnimationPlaying;

    public void StartAnimateText(Graphic objectToAnimate, Vector3 defaultPosition, float animationTime)
    {       
        if (!_isAnimationPlaying)
        {
            AnimateText(objectToAnimate, defaultPosition, animationTime);
        }
    }

    private async void AnimateText(Graphic objectToAnimate, Vector3 defaultPosition, float animationTime)
    {
        _isAnimationPlaying = true;
        objectToAnimate.transform.DOMove(defaultPosition + Vector3.up, animationTime);

        await Task.Delay((int)(animationTime * ANIMATION_TIME_MODIFIER));

        objectToAnimate.transform.DOMove(defaultPosition, animationTime);
        _isAnimationPlaying = false;
    }

    public void StartAnimateButton(Graphic objectToAnimate, float defaultScale, float targetScale, float animationTime)
    {
        if (!_isAnimationPlaying)
        {
            AnimateButton(objectToAnimate, defaultScale, targetScale, animationTime);
        }
    }

    private async void AnimateButton(Graphic objectToAnimate, float defaultScale, float targetScale, float animationTime)
    {
        _isAnimationPlaying = true;
        objectToAnimate.transform.DOScale(targetScale, animationTime);

        await Task.Delay((int)(animationTime * ANIMATION_TIME_MODIFIER));

        objectToAnimate.transform.DOScale(defaultScale, animationTime);
        _isAnimationPlaying = false;
    }

    public void StartFade(Graphic objectToAnimate, float minValue, float maxValue, float animationTime)
    {
        Fade(objectToAnimate, minValue, maxValue, animationTime);
    }

    private async void Fade(Graphic objectToAnimate, float minValue, float maxValue, float animationTime)
    {
        while (true)
        {
            objectToAnimate.DOFade(minValue, animationTime);
            await Task.Delay((int)(animationTime * ANIMATION_TIME_MODIFIER));
            objectToAnimate.DOFade(maxValue, animationTime);
            await Task.Delay((int)(animationTime * ANIMATION_TIME_MODIFIER));
        }
    }

    public void KillTween(Graphic objectToAnimate)
    {
        DOTween.Kill(objectToAnimate);
    }
}
