using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBullet : MonoBehaviour
{
    private AudioSource playerAudio;
    public AudioClip boom;
    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        playerAudio.PlayOneShot(boom, 1.0f);
        Destroy(gameObject,1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
