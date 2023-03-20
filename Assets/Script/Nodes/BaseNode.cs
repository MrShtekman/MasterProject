using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseNode : MonoBehaviour
{
    public abstract int GetValue();
    public delegate void NodeAction(int value);
    public abstract event  NodeAction OnValueChanged;
    public abstract void ValueChangeEvent();
    public abstract void UpdateDisplay();
}
