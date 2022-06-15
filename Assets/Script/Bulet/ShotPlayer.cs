using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotPlayer : MonoBehaviour
{
    public GameObject Explosion;
    public float speed = 50;
    public float damage = 10;
    void Start()
    {
        
    }
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(Explosion, transform.position, Explosion.transform.transform.rotation);
        Destroy(gameObject);
    }
}
