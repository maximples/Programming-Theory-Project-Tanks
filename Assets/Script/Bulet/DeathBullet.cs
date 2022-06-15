using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBullet : MonoBehaviour
{
    private AudioSource playerAudio;
    public AudioClip boom;
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        playerAudio.PlayOneShot(boom, 1.0f);
        Destroy(gameObject,1);
    }

    void Update()
    {
        
    }
}
