using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TransmitPoint : MonoBehaviour
{
    [SerializeField] private Transform line;
    private Transform parentNode;
    private Transform originalPos;
    private int value;


    void Start()
    {
        originalPos = transform.parent;
        parentNode = originalPos.parent;
        GetValueFromParent();
    }


    //When connected, the transmitpoint will attach to the other nodes receivepoint
    public virtual void OnTriggerStay(Collider other)
    {
        var targetReceiver = other.transform;

        if (CheckReceiverTag(targetReceiver))
        {
            transform.parent = targetReceiver;
            transform.position = targetReceiver.position;
        }
    }

    //When first connected, this script will call the other nodes connectNode function and subsribe to our event
    public virtual void OnTriggerEnter(Collider other)
    {
        
        var targetReceiver = other.transform;

        if (CheckReceiverTag(targetReceiver))
        {
            var otherNode = other.transform.parent.parent.GetComponent<MiddleNode>();
            GetValueFromParent();
            otherNode.ConnectNode(parentNode, other.transform, value);
            ChangeLineColor(targetReceiver);
        }
    }

    //When disconnected, this script will tell the other node to unsubsribe from our event
    public void OnTriggerExit(Collider other)
    {
        var targetReceiver = other.transform;

        if (CheckReceiverTag(targetReceiver))
        {
            var otherNode = other.transform.parent.parent.GetComponent<MiddleNode>();
            otherNode.DisconnectNode(parentNode, other.transform, 0);
            ChangeLineColor(targetReceiver);
        }
        transform.parent = originalPos;
    }

    //Check if it is a receiver;
    public virtual bool CheckReceiverTag(Transform otherReceiver)
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
        value = parentNode.GetComponent<BaseNode>().GetValue();

    }
}
