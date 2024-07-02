using DG.Tweening;
using System.Collections;
using UnityEngine;

public class DoTweenButtonClick : MonoBehaviour
{
    private const float DELAY = 0.1f;

    [SerializeField] private float _targetScale;
    [SerializeField] private float _defaultScale;

    private IEnumerator _onClick;

    private void Start()
    {
        _onClick = OnClick(); 
    }

    public void CallOnClick()
    {
        if(_onClick != null)
        {
            StartCoroutine(_onClick);
        }
        _onClick = OnClick();
    }

    private IEnumerator OnClick()
    {
        transform.DOScale(_targetScale, DELAY);
        yield return new WaitForSeconds(DELAY);
        transform.DOScale(_defaultScale, DELAY);
    }

    private void OnDisable()
    {
        DOTween.Kill(transform);
    }
}
