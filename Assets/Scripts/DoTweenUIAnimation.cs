using DG.Tweening;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class DoTweenUIAnimation
{
    private const int ANIMATION_TIME_MODIFIER = 1000;
    private const int ANIMATION_TICKS_MODIFIER = 4;

    private bool _isAnimationPlaying;

    public void StartAnimateText(Graphic objectToAnimate, float animationTime)
    {       
        if (!_isAnimationPlaying)
        {
            AnimateText(objectToAnimate, objectToAnimate.transform.position, animationTime);
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

    public void StartAnimateButton(Graphic objectToAnimate, float sizeMultiplier, float animationTime)
    {
        if (!_isAnimationPlaying)
        {
            AnimateButton(objectToAnimate, sizeMultiplier, animationTime);
        }
    }

    private async void AnimateButton(Graphic objectToAnimate, float sizeMultiplier, float animationTime)
    {
        _isAnimationPlaying = true;
        objectToAnimate.transform.DOScale(objectToAnimate.transform.localScale * sizeMultiplier, animationTime);

        await Task.Delay((int)(animationTime * ANIMATION_TIME_MODIFIER));

        objectToAnimate.transform.DOScale(objectToAnimate.transform.localScale / sizeMultiplier, animationTime);
        _isAnimationPlaying = false;
    }

    public void StartFade(Graphic objectToAnimate, float minValue, float maxValue, float animationTime, int animationTicks, MonoBehaviour monoBehaviour)
    {
        if(!_isAnimationPlaying)
        {
            monoBehaviour.StartCoroutine(Fade(objectToAnimate, minValue, maxValue, animationTime, animationTicks));
        }
    }

    private IEnumerator Fade(Graphic objectToAnimate, float minValue, float maxValue, float animationTime, int animationTicks)
    {
        _isAnimationPlaying = true;
        for (int i = 0; i < animationTicks / ANIMATION_TICKS_MODIFIER; i++)
        {
            objectToAnimate.DOFade(minValue, animationTime);
            yield return new WaitForSeconds(animationTime);
            objectToAnimate.DOFade(maxValue, animationTime);
            yield return new WaitForSeconds(animationTime);
        }
        _isAnimationPlaying = false;
    }

    public void KillTween(object objectToAnimate)
    {
        DOTween.Kill(objectToAnimate);
    }
}
