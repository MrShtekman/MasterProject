using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TransmitPoint : MonoBehaviour
{
    [SerializeField] private Transform line;
    [SerializeField] private bool taken;
    [SerializeField] private Transform connecteNode;
    private Transform parentNode, originalPos;
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

        if (targetReceiver.parent.parent == connecteNode/*CheckReceiverTag(targetReceiver)*/)
        {
            transform.parent = targetReceiver;
            transform.position = targetReceiver.position;
        }
    }

    //When first connected, this script will call the other nodes connectNode function and subsribe to our event
    public virtual void OnTriggerEnter(Collider other)
    {

        var targetReceiver = other?.transform;

        if (CheckReceiverTag(targetReceiver) && !taken)
        {
            var otherNode = targetReceiver.parent.parent.GetComponent<MiddleNode>();
            if (!otherNode.taken)
            {
                GetValueFromParent();
                otherNode.ConnectNode(parentNode, targetReceiver, value);
                ChangeLineColor(targetReceiver);
                connecteNode = targetReceiver.parent.parent;
                taken = true;

            }
        }
    }

    //When disconnected, this script will tell the other node to unsubsribe from our event
    public virtual void OnTriggerExit(Collider other)
    {
        var targetReceiver = other?.transform;

        if (CheckReceiverTag(targetReceiver))
        {
            var otherNode = targetReceiver.parent.parent.GetComponent<MiddleNode>();
            otherNode.DisconnectNode(parentNode, targetReceiver, 0);
            line?.GetComponent<Line>().ErrorColor();
            connecteNode = null;
            taken = false;
        }
        transform.parent = originalPos;
    }

    //Check if it is a receiver;
    public virtual bool CheckReceiverTag(Transform otherReceiver)
    {
        if (otherReceiver.GetComponent<TransmitPoint>() != null)
            return false;
        if (otherReceiver.tag == gameObject.tag)
            return true;
        return false;
    }

    //Change the lines color when the datatype of transmitter and receiver doesnt match
    private void ChangeLineColor(Transform otherReceiver)
    {
        //if (otherReceiver.tag == gameObject.tag)
            line?.GetComponent<Line>().SwitchColor();

    }

    private void GetValueFromParent()
    {

        value = parentNode.GetComponent<BaseNode>().GetValue();

    }
}
