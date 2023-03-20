using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class VariableTransmitPoint : TransmitPoint
{
    private Transform line, parentNode, originalPos;
    private int value;


    void Start()
    {
        originalPos = transform.parent;
        parentNode = originalPos.parent;
        GetValueFromParent();
    }


    //When connected, the transmitpoint will attach to the other nodes receivepoint
    public override void OnTriggerStay(Collider other)
    {
        var targetReceiver = other.transform;

        if (CheckReceiverTag(targetReceiver))
        {
            transform.parent = targetReceiver;
            transform.position = targetReceiver.position;
        }
    }

    //When first connected, this script will call the other nodes connectNode function and subsribe to our event
    public override void OnTriggerEnter(Collider other)
    {

        var targetReceiver = other.transform;

        if (CheckReceiverTag(targetReceiver))
        {
            var otherNode = other.transform.parent.parent.GetComponent<InteractiveObject>();
            GetValueFromParent();
            otherNode.Connect(parentNode, other.transform, value);
            ChangeLineColor(targetReceiver);
        }
    }

    //Check if it is a receiver;
    public override bool CheckReceiverTag(Transform otherReceiver)
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