using TMPro;
using UnityEngine;

public class ChangeResolution : MonoBehaviour
{
    private readonly int[,] _resolution = 
    { 
        {3840,2160}, 
        {1920,1080}, 
        {1600,900 },
        {1440,900 },
        {1366,768 } 
    };

    [SerializeField] private TMP_Dropdown _resolutionsDropdown;

    private void Awake()
    {      
        OnChangeResolution(_resolutionsDropdown.value = PlayerPrefs.GetInt("Screen resolution"));
    }

    public void OnChangeResolution(int index)
    {
        Screen.SetResolution(_resolution[index, 0], _resolution[index, 1], PlayerPrefs.GetInt("Is fullscreen") == 1);
        PlayerPrefs.SetInt("Screen resolution", index);
    }
}
