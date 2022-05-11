using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyController : MonoBehaviour
{
    public static EnemyController Instance;
    public enum State
    {
        IDLE,
        MOVE,
        MOVEToPlayer,
        ATTACKINGMOVE,
        ATTACKINGSTAND,
    }
    public enum Tipe
    {
        Tank_M,
        Car,
        
    }
    public float Speed = 6.0f;
    public float coldoown = 2.0f;
    public float detectionRadius = 80.0f;
    public float AttackingStandRadius = 35.0f;
    public float AttackingRadius = 50.0f;
    public float HP = 40;
    public float m_PursuitTimer;
    public State m_State = State.IDLE;
    public UnityEngine.AI.NavMeshAgent m_Agent;
    public GameObject gun;
    public GameObject target;
    public GameObject turrent;
    public GameObject turrentLook;
    public GameObject boom;
    public Tipe tipe;
    public bool reloadGun=false ;
    public bool live = true;
    public bool canAttack = false;
    public ParticleSystem gunFire;
    public AudioSource playerAudio;
    public AudioClip fireAudio;
    public GameObject SpeedUp;
    public GameObject MaxHpUp;
    public GameObject RepirUp;

    // Update is called once per frame

    public void DeathUnit(Tipe tipeDeth)
    {
        int iTipe=0;
        if(tipeDeth== Tipe.Tank_M) { iTipe = 8; }
        if (tipeDeth == Tipe.Car) { iTipe = 16; }
        live = false;
        m_Agent.isStopped = true;
        Instantiate(boom, transform.position, boom.transform.rotation);
        Destroy(gameObject, 0.5f);
        LootSpawn(iTipe);
    }
    public void PathWay(Vector3 target,float detectionRadiusPathWay, float attackingStandRadiusRadiusPathWay, float AttackingRadiusPathWay)
    {
        switch (m_State)
        {

            case State.IDLE:
                {
                    if (Vector3.SqrMagnitude(target - transform.position) < detectionRadiusPathWay * detectionRadiusPathWay)
                    {

                        m_State = State.ATTACKINGMOVE;
                        m_Agent.isStopped = false;
                    }
                }
                break;
            case State.ATTACKINGMOVE:
                {

                    turrent.transform.LookAt(target);
                    canAttack = true;
                    if (Vector3.SqrMagnitude(target - transform.position) > detectionRadiusPathWay * detectionRadiusPathWay)
                    {
                        m_State = State.IDLE;
                        canAttack = false;
                        m_Agent.isStopped = true;

                    }
                    if (Vector3.SqrMagnitude(target- transform.position) < attackingStandRadiusRadiusPathWay * attackingStandRadiusRadiusPathWay)
                    {
                        m_State = State.ATTACKINGSTAND;
                        m_Agent.ResetPath();
                        m_Agent.velocity = Vector3.zero;
                        m_Agent.isStopped = true;

                    }
                  
                    m_Agent.destination = target;
                }
                break;
            case State.ATTACKINGSTAND:
                {

                    turrent.transform.LookAt(target);
                    canAttack = true;
                    if (Vector3.SqrMagnitude(target - transform.position) > AttackingRadiusPathWay * AttackingRadiusPathWay)
                    {

                        m_State = State.ATTACKINGMOVE;
                        m_Agent.isStopped = false;
                        canAttack = false;

                    }
                  
                }
                break;
            case State.MOVEToPlayer:
                {

                    m_Agent.destination = target;
                    if (Vector3.SqrMagnitude(target - transform.position) < detectionRadiusPathWay * detectionRadiusPathWay)
                    {
                        m_State = State.ATTACKINGMOVE;
                    }

                }
                break;
               
        }
    }
    public IEnumerator ReloadGun_1()
    {
        yield return new WaitForSeconds(coldoown);
        reloadGun = false;
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayarGun_1"))
        {
            HP = HP - PlayerController.attack/ SaveData.Instance.difficultyLevel;
        }
        if (other.gameObject.CompareTag("MissilePlayer"))
        {
            HP = HP - 30/ SaveData.Instance.difficultyLevel;
        }

    }
    public void LootSpawn(int ClassEnemy)
    {
        Vector3 offset= new Vector3(0,1,0);
        int randomItem= Random.Range(0, ClassEnemy); 
        if (randomItem==1)
        { Instantiate(SpeedUp, transform.position, SpeedUp.transform.rotation); }
        if (randomItem > 1&&randomItem<=3)
        { Instantiate(MaxHpUp, transform.position+offset, MaxHpUp.transform.rotation); }
        if (randomItem > 3 && randomItem <= 6)
        { Instantiate(RepirUp, transform.position+offset, RepirUp.transform.rotation); }
    }
}
