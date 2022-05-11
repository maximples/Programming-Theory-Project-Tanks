using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileEnemy : MonoBehaviour
{
    public GameObject ExplosionMissile;
    public float speed = 25;
    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Ground"))
        {
            Instantiate(ExplosionMissile, transform.position, ExplosionMissile.transform.transform.rotation);
            Destroy(gameObject);
        }
    }

}
