using System.Collections;
using UnityEngine;

public class AudioSystem : MonoBehaviour
{
    public static AudioSystem instance;

    private AudioSource source;

    [SerializeField] private AudioClip ballKickSound = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
        source = GetComponent<AudioSource>();
    }

    public void PlayBallKickSound()
    {
        source.PlayOneShot(ballKickSound);
    }
}
