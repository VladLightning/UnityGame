using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private Slider _slider;

    private void Start()
    {
        _gameObject.transform.DOMove(transform.position + Vector3.up * 20, 50);
        DOTween.Kill(_gameObject.transform);
    }
}
