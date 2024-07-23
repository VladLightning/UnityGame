using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;
    [SerializeField] private PlaySound _playSound;

    public void OnClick()
    {
        _playSound.StartPlayClip(_clip);
    }
}
