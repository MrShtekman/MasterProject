using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractiveObject : MonoBehaviour
{
    private Transform connectedNode;
    public abstract void DoAction(int value);

    public virtual void Connect(Transform otherNode, Transform _receiver, int initialValue)
    {
        connectedNode = otherNode;
        connectedNode.GetComponent<BaseNode>().OnValueChanged += DoAction;
        DoAction(initialValue);
    }
}
