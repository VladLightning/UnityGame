using UnityEngine;
using UnityEngine.UI;

public abstract class Animations : MonoBehaviour
{
    [SerializeField] protected Graphic _objectToAnimate;

    protected DoTweenUIAnimation _doTweenUIAnimation;

    public abstract void Animate();

    protected virtual void Awake()
    {
        _doTweenUIAnimation = new DoTweenUIAnimation();
    }

    protected virtual void OnDisable()
    {
        _doTweenUIAnimation.KillTween(_objectToAnimate);
    }
}
