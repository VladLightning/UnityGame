using UnityEngine;
using UnityEngine.UI;

public class ButtonClickLimit : MonoBehaviour
{
    [SerializeField] private int _clickLimit;
    private int _clicksAmount;

    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
    }

    public void IncreaseClicksAmount()
    {
        _clicksAmount++;
        if( _clicksAmount >= _clickLimit)
        {
            _button.interactable = false;
        }
    }
}
