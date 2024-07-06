using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    [SerializeField] private float _targetScale;

    private DoTweenUIAnimation _doTweenUIAnimation;

    private void Start()
    {
        _doTweenUIAnimation = new DoTweenUIAnimation(GetComponent<Image>(), _targetScale);
    }

    public void OnClick()
    {
        _doTweenUIAnimation.StartAnimateButton();
    }

    private void OnDisable()
    {
        _doTweenUIAnimation.KillTween();
    }
}
