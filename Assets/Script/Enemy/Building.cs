using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public AudioSource playerAudio;
    public AudioClip BoomAudio;
    public GameObject SpeedUp;
    public GameObject MaxHpUp;
    public GameObject RepirUp;
    public GameObject AtackUp;
    public float HP = 20;
    public int classEnemy;
    public GameObject MissileAdd;
    public GameObject boom;
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayarGun_1"))
        {
            HP = HP - PlayerController.attack / SaveData.Instance.difficultyLevel;
            if (HP <= 0) { DeathUnit(); }
        }
        if (other.gameObject.CompareTag("MissilePlayer"))
        {
            HP = HP - 30 / SaveData.Instance.difficultyLevel;
            if (HP <= 0) { DeathUnit(); }
        }

    }
    public void DeathUnit()
    {
       
        Instantiate(boom, transform.position, boom.transform.rotation);
        LootSpawn();
        playerAudio.PlayOneShot(BoomAudio, 1.0f);
        Destroy(gameObject, 0.5f);

    }
    public void LootSpawn()
    {
        Vector3 offset = new Vector3(0, 1, 0);
        if (classEnemy == 4)
        { Instantiate(AtackUp, transform.position, AtackUp.transform.rotation); }
        if (classEnemy == 5)
        { GameManager.Instance.Win(); }
        if (classEnemy != 4&& classEnemy != 5)
        {
            int randomItem = Random.Range(0, 10);
            if (randomItem >= 0 && randomItem <= 6)
            { Instantiate(MaxHpUp, transform.position + offset, MaxHpUp.transform.rotation); }
            if (randomItem > 6 && randomItem <= 7)
            { Instantiate(RepirUp, transform.position + offset, RepirUp.transform.rotation); }
            if ( randomItem == 8)
            { Instantiate(MissileAdd, transform.position + offset, boom.transform.rotation);  }
            if (randomItem == 9)
            { Instantiate(SpeedUp, transform.position + offset, boom.transform.rotation); }
        }
         
    }
}
