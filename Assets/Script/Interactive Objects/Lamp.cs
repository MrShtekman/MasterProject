using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : InteractiveObject
{
    private Light light;
    private bool lightsOn;
    private Transform connectedNode;


    public override void Connect(Transform otherNode, Transform _receiver, int initialValue)
    {
        connectedNode = otherNode;
        connectedNode.GetComponent<BaseNode>().OnValueChanged += DoAction;
        
    }

    public override void DoAction(int value)
    {
        light.enabled = lightsOn;

    }

    
}
