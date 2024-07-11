using TMPro;
using UnityEngine;

public class DoTweenAnimateText : MonoBehaviour
{
    [SerializeField] private float _animationTime;

    [SerializeField] private TMP_Text _text;

    private Vector3 _defaultPosition;

    private DoTweenUIAnimation _doTweenUIAnimation;

    private void Start()
    {
        _defaultPosition = _text.transform.position;

        _doTweenUIAnimation = new DoTweenUIAnimation();
    }

    public void Animate()
    {
        _doTweenUIAnimation.StartAnimateText(_text, _defaultPosition, _animationTime);
    }

    private void OnDisable()
    {
        _doTweenUIAnimation.KillTween(_text);
    }
}
