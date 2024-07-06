using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    [SerializeField] private float _targetScale;

    private DoTweenUIAnimtaion _doTweenUIAnimation;

    private void Start()
    {
        _doTweenUIAnimation = new DoTweenUIAnimtaion(GetComponent<Image>(), _targetScale);
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
