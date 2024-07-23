using UnityEngine;

public class Win : MonoBehaviour
{
    [SerializeField] private GameObject _winPanel;

    public void WinGame()
    {
        Time.timeScale = 0;
        _winPanel.SetActive(true);
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }
}
