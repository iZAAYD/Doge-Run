using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public AudioClip
        catDeath,
        pointsClip;
    
    [HideInInspector] public AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
}
