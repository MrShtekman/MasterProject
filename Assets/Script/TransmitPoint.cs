using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransmitPoint : MonoBehaviour
{
    private Transform originalOwner;
    private int number;
    private string character;
    private bool boolean;
    
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
        if (other.gameObject.CompareTag("ReceiveNumber") || other.gameObject.CompareTag("ReceiveCharacter") || other.gameObject.CompareTag("ReceiveBool"))
        {
            transform.parent = other.transform;
            transform.position = other.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        transform.parent = originalOwner;
    }
}
