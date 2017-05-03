using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
    public static SoundManager Instance;

    public AudioSource SFX;

    public AudioClip[] FireEventClips;

    void Awake()
    {
        Instance = this;
    }

    public void OnFireEvent(Vector3 location)
    {
        // Pick a random clip
        AudioClip selectedClip = FireEventClips[Random.Range(0, FireEventClips.Length)];

        SFX.PlayOneShot(selectedClip);
    }
}
