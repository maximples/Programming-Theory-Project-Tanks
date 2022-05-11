using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_L : EnemyController
{
    public GameObject bullet;
    public GameObject GunFire;
    private Vector3 targetEnemy;
    // Start is called before the first frame update
    void Start()
    {
        tipe = Tipe.Tank_M;
        m_State = State.IDLE;
        playerAudio = GetComponent<AudioSource>();
        Speed = 4.0f;
        coldoown = 1.6f;
        detectionRadius = 70.0f;
        AttackingStandRadius = 20.0f;
        AttackingRadius = 45.0f;
        HP = 120;
        target = GameObject.FindWithTag("Player");
        targetEnemy = target.transform.position;
        m_Agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
        m_Agent.speed = Speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0 && live)
        {
            DeathUnit(tipe);
        }
        if (live)
        {
            targetEnemy = target.transform.position;
            PathWay(targetEnemy, detectionRadius, AttackingStandRadius, AttackingRadius);
        }
        if (canAttack && !reloadGun)
        { Fire(); }
    }
    public void Fire()
    {
        playerAudio.PlayOneShot(fireAudio, 1.0f);
        Instantiate(bullet, GunFire.transform.position, gun.transform.rotation);
        reloadGun = true;
        StartCoroutine(ReloadGun_1());
    }


}