using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golfball : MonoBehaviour
{
    
    private Vector3 spawn;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spawn = transform.position;
        
    }

    public void Respawn()
    {
        transform.position = spawn;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
