using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotTank : MonoBehaviour
{
    public GameObject Explosion;
    public float speed = 40;
    // Start is called before the first frame update
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")|| other.gameObject.CompareTag("Ground"))
        {
            Instantiate(Explosion, transform.position, Explosion.transform.transform.rotation);
            Destroy(gameObject);
        }

    }
}