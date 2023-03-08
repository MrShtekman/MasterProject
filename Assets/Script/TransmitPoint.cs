using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransmitPoint : MonoBehaviour
{
    private Transform originalOwner;
    // Start is called before the first frame update
    void Start()
    {
        originalOwner = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Receiver"))
        {
            transform.position = other.transform.position;
            transform.parent = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        transform.parent = originalOwner;
    }
}
