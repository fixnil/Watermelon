using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioClip MergeClip;
    public AudioClip CollideClip;

    private  AudioSource _audioSource;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _audioSource = this.GetComponent<AudioSource>();
    }

    public void PlayMergeClip()
    {
        _audioSource.PlayOneShot(MergeClip);
    }

    public void PlayCollideClip()
    {
        _audioSource.PlayOneShot(CollideClip);
    }
}
