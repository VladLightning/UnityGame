using TMPro;
using UnityEngine;

public class ChangeResolution : MonoBehaviour
{
    [SerializeField] private Resolution[] _resolutions;

    [SerializeField] private TMP_Dropdown _resolutionsDropdown;

    [SerializeField] private FortuneButtonController _fortuneButtonController;

    private void Awake()
    {
        SortMaxRefreshRate();
        _resolutionsDropdown.value = PlayerPrefs.GetInt("Screen resolution");
    }

    public void OnChangeResolution(int index)
    {
        Screen.SetResolution(_resolutions[index].width, _resolutions[index].height, PlayerPrefs.GetInt("Is fullscreen") == 1);
        PlayerPrefs.SetInt("Screen resolution", index);
        _fortuneButtonController.SetScreenBorders();
    }

    private void SortMaxRefreshRate()
    {
        int newResolutionsLength = 0;
        for (int i = 0; i < Screen.resolutions.Length; i++)
        {
            if (Screen.resolutions[i].refreshRateRatio.value == Screen.currentResolution.refreshRateRatio.value)
            {
                newResolutionsLength++;
            }
        }

        _resolutions = new Resolution[newResolutionsLength];
        int index = 0;
        _resolutionsDropdown.options.Clear();
        for (int i = 0; i < Screen.resolutions.Length; i++)
        {
            if (Screen.resolutions[i].refreshRateRatio.value == Screen.currentResolution.refreshRateRatio.value)
            {
                _resolutions[index] = Screen.resolutions[i];

                string option = $"{_resolutions[i].width}x{_resolutions[i].height}";

                _resolutionsDropdown.options.Add(new TMP_Dropdown.OptionData(option));

                index++;
            }
        }
    }
}
