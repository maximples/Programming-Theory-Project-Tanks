using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject tank;
    public Vector3 offset = new Vector3(25, 38, 0);
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
       transform.position = tank.transform.position + offset;
    }
}