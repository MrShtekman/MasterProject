using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransmitPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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

            Debug.Log("trigger!");
        }
    }
}
