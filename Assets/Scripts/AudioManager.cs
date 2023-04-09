using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioClip MergeClip;
    public AudioClip CollideClip;
    public AudioSource AudioSource;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayMergeClip()
    {
        AudioSource.PlayOneShot(MergeClip);
    }

    public void PlayCollideClip()
    {
        AudioSource.PlayOneShot(CollideClip);
    }
}
