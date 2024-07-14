using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    [SerializeField] private GameObject _menu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _menu.SetActive(!_menu.activeSelf);
        }
    }
}
