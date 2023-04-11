using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class VariableTransmitPoint : TransmitPoint
{
    private Transform parentNode, originalPos;
    private int value;
    [SerializeReference] Transform theLine;


    void Start()
    {
        originalPos = transform.parent;
        parentNode = originalPos.parent;
        GetValueFromParent();
    }


    //When connected, the transmitpoint will attach to the other nodes receivepoint
    public override void OnTriggerStay(Collider other)
    {
        var targetReceiver = other?.transform;

        if (CheckReceiverTag(targetReceiver))
        {
            transform.parent = targetReceiver;
            transform.position = targetReceiver.position;
        }
    }

    //When first connected, this script will call the other nodes connectNode function and subsribe to our event
    public override void OnTriggerEnter(Collider other)
    {

        var targetReceiver = other?.transform;

        if (CheckReceiverTag(targetReceiver))
        {
            theLine.GetComponent<Line>().SwitchColor();
            var otherNode = targetReceiver.parent.GetComponent<InteractiveObject>();
            GetValueFromParent();
            otherNode.Connect(parentNode, targetReceiver, value);
        }
    }

    //Check if it is a interactiveObject, if so, change the line color
    public override bool CheckReceiverTag(Transform otherReceiver)
    {
        if (otherReceiver.CompareTag("InteractiveObject"))
        {
            return true;
        }
        return false;
    }

    public override void OnTriggerExit(Collider other)
    {
       
    }


    private void GetValueFromParent()
    {
        value = parentNode.GetComponent<BaseNode>().GetValue();
    }
}