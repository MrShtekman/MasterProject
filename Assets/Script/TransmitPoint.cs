using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransmitPoint : MonoBehaviour
{
    private Transform parentNode;
    private Transform originalPos;
    private int number;
    private string character;
    private bool boolean;
    
    void Start()
    {
        originalPos = transform.parent;
        parentNode = originalPos.parent;

        if (parentNode.CompareTag("NumberNode"))
            number = parentNode.GetComponent<NumberNode>().value;
    }

   

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("ReceiveNumber") || other.gameObject.CompareTag("ReceiveCharacter") || other.gameObject.CompareTag("ReceiveBool"))
        {
            transform.parent = other.transform;
            transform.position = other.transform.position;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ReceiveNumber") || other.gameObject.CompareTag("ReceiveCharacter") || other.gameObject.CompareTag("ReceiveBool"))
        {
            CalculationNode cn = other.transform.parent.parent.GetComponent<CalculationNode>();

            cn.ConnectNodes(parentNode, other.transform, number);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        transform.parent = originalPos;
        
    }
}
