using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MiddleNode : BaseNode
{
    public abstract void ConnectNode(Transform otherNode, Transform _receiver, int initialValue);
    public abstract void DisconnectNode(Transform otherNode, Transform _receiver, int value);
    public bool taken;
}
