using UnityEngine;
using UnityEngine.UI;

public class Animations : MonoBehaviour
{
    [SerializeField] protected Graphic _objectToAnimate;

    protected DoTweenUIAnimation _doTweenUIAnimation;

    protected virtual void Awake()
    {
        _doTweenUIAnimation = new DoTweenUIAnimation();
    }

    public virtual void Animate()
    {

    }

    protected virtual void OnDisable()
    {
        _doTweenUIAnimation.KillTween(_objectToAnimate);
    }
}
