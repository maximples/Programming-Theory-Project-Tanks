using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilePlayer : MonoBehaviour
{
    public GameObject ExplosionMissile;
    public float speed = 25;
    void Start()
    {

    }
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag ("Ground"))
        {
            Instantiate(ExplosionMissile, transform.position, ExplosionMissile.transform.transform.rotation);
            Destroy(gameObject);
        }
    }
}
