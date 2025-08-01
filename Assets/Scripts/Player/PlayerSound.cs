using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    [SerializeField] private AudioClip[] _audioClips;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //Only Whistle
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (_audioClips.Length > 0 && !_audioSource.isPlaying)
            {
                _audioSource.clip = _audioClips[0];
                _audioSource.Play();
            }
        }
    }
}
