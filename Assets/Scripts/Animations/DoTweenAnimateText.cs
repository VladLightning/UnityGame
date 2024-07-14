using UnityEngine;

public class DoTweenAnimateText : Animations
{
    [SerializeField] private float _animationTime;

    public override void Animate()
    {
        _doTweenUIAnimation.StartAnimateText(_objectToAnimate, _animationTime);
    }
}
