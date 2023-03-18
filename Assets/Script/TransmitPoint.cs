using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransmitPoint : MonoBehaviour
{
    [SerializeField] private Transform line;
    private Transform parentNode;
    private Transform originalPos;
    private int number;
    private bool boolean;

    void Start()
    {
        originalPos = transform.parent;
        parentNode = originalPos.parent;

        //GetValueFromParent();
    }



    private void OnTriggerStay(Collider other)
    {
        var targetReceiver = other.transform;
        if (CheckReceiverTag(targetReceiver))
        {
            transform.parent = targetReceiver;
            transform.position = targetReceiver.position;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var targetReceiver = other.transform;
        if (CheckReceiverTag(targetReceiver))
        {
            CalculationNode cn = other.transform.parent.parent.GetComponent<CalculationNode>();
            GetValueFromParent();
            cn.ConnectNode(parentNode, other.transform, number);
            ChangeLineColor(targetReceiver);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var targetReceiver = other.transform;
        if (CheckReceiverTag(targetReceiver))
        {
            CalculationNode cn = other.transform.parent.parent.GetComponent<CalculationNode>();
            cn.DisconnectNode(parentNode, other.transform, 0);
            ChangeLineColor(targetReceiver);
        }
        transform.parent = originalPos;
    }

    //Check if it is a receiver;
    private bool CheckReceiverTag(Transform otherReceiver)
    {
        if (otherReceiver.CompareTag("Number") || otherReceiver.CompareTag("Boolean"))
            return true;
        return false;
    }

    //Change the lines color when the datatype of transmitter and receiver doesnt match
    private void ChangeLineColor(Transform otherReceiver)
    {
        if (otherReceiver.tag == gameObject.tag)
            line?.GetComponent<Line>().SwitchColor();
    }

    private void GetValueFromParent()
    {
        switch (parentNode.tag)
        {
            case "NumberNode":
                number = parentNode.GetComponent<NumberNode>().value;
                break;
            case "CalculationNode":
                number = parentNode.GetComponent<CalculationNode>().output;
                break;
                /* case "BooleanNode":
                     number = parentNode.GetComponent<NumberNode>().value;*/
                //break;
                /*case "LogicNode":
                    number = parentNode.GetComponent<NumberNode>().value;*/
                break;
            default:
                break;
        }


    }
}
