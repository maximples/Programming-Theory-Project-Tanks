using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTower : MonoBehaviour
{
    public float coldoown = 4.0f;
    public float detectionRadius = 75.0f;
    public float HP = 80;
    public GameObject gun;
    public GameObject gun1;
    public GameObject gun2;
    public GameObject target;
    public GameObject turrent;
    public GameObject turrentLook;
    public GameObject missile;
    public GameObject boom;
    public bool reloadGun = false;
    public bool live = true;
    public bool canAttack = false;
    public GameObject MissileAdd;
     // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.SqrMagnitude(target.transform.position - transform.position) < detectionRadius * detectionRadius&& live&& GameManager.Instance.activ)
        {
            turrentLook.transform.LookAt(target.transform.position);
            turrent.transform.eulerAngles = new Vector3(turrent.transform.eulerAngles.x, turrentLook.transform.eulerAngles.y, turrent.transform.eulerAngles.z);
            gun.transform.eulerAngles = new Vector3(turrentLook.transform.eulerAngles.x, gun.transform.eulerAngles.y, gun.transform.eulerAngles.z);
            if(!reloadGun)
            {
                Fire();
            }
        }
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
    public void Fire()
    {
        Instantiate(missile, gun1.transform.position, gun.transform.rotation);
        Instantiate(missile, gun2.transform.position, gun.transform.rotation);
        reloadGun = true;
        StartCoroutine(ReloadGun());
    }
    public IEnumerator ReloadGun()
    {
        yield return new WaitForSeconds(coldoown);
        reloadGun = false;

    }
    public void DeathUnit()
    {
        Vector3 offset = new Vector3(0, 1, 0);
        live = false;
        Instantiate(boom, transform.position, boom.transform.rotation);
        Instantiate(MissileAdd, transform.position + offset, boom.transform.rotation);
        Destroy(gameObject, 0.5f);
       
    }
}
