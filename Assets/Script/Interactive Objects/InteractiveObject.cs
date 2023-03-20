using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractiveObject : MonoBehaviour
{
    public abstract void DoAction(int value);
    public abstract void Connect(Transform otherNode, Transform _receiver, int initialValue);
}
