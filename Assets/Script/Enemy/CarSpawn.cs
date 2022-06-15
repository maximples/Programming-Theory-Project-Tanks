using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawn : EnemyController
{
    public GameObject bullet;
    private Vector3 targetEnemy;
    public ParticleSystem gunFire2;
    // Start is called before the first frame update
    void Start()
    {
        m_State = State.MOVEToPlayer;
        tipe = Tipe.Car;
        playerAudio = GetComponent<AudioSource>();
        Speed = 12.0f;
        coldoown = 0.7f;
        detectionRadius = 50.0f;
        AttackingStandRadius = 15.0f;
        AttackingRadius = 20.0f;
        HP = 10;
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
        {
            Fire();
        }
    }
    public void Fire()
    {
        playerAudio.PlayOneShot(fireAudio, 1.0f);
        Instantiate(bullet, gunFire.transform.position, gun.transform.rotation);
        Instantiate(bullet, gunFire2.transform.position, gun.transform.rotation);
        reloadGun = true;
        StartCoroutine(ReloadGun_1());
    }

}
