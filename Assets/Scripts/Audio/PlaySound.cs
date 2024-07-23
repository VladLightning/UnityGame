using System.Collections;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    private const float DELAY = 0.05f;

    private AudioSource _source;

    private bool _isPlaying;

    private void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    public void StartPlayClip(AudioClip clip)
    {
        if(!_isPlaying)
        {
            StartCoroutine(PlayClip(clip));
        }
    }

    private IEnumerator PlayClip(AudioClip clip)
    {
        _isPlaying = true;

        _source.PlayOneShot(clip);
        yield return new WaitForSeconds(DELAY);

        _isPlaying = false;
    }

}
