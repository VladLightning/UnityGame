using UnityEngine;
using UnityEngine.UI;

public class ButtonClickLimit : MonoBehaviour
{

    [SerializeField] protected int _clickLimit;
    protected int _clicksAmount;

    protected Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
    }

    protected virtual void ReachClickLimit()
    {
        _button.interactable = false;
    }

    public void IncreaseClicksAmount()
    {
        _clicksAmount++;
        if( _clicksAmount >= _clickLimit)
        {
            ReachClickLimit();           
        }
    }
}
