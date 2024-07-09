using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DoTweenFade : MonoBehaviour
{
    private const float FADE_TIME = 0.25f;
    private const float FADE_MIN_VALUE = 0.2f;
    private const float FADE_MAX_VALUE = 0.6f;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void OnEnable()
    {
        StartCoroutine(Fade());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        DOTween.Kill(_image);
    }

    private IEnumerator Fade()
    {
        while (true)
        {
            _image.DOFade(FADE_MIN_VALUE, FADE_TIME);
            yield return new WaitForSeconds(FADE_TIME);
            _image.DOFade(FADE_MAX_VALUE, FADE_TIME);
            yield return new WaitForSeconds(FADE_TIME);
        }
    }
}
