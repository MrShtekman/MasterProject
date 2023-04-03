using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class FunctionNode : MiddleNode
{
    private int value;
    [SerializeField] UnityEvent _event;
    public override event NodeAction OnValueChanged;

    // Start is called before the first frame update
    void Start()
    {
        UpdateDisplay();
    }


    public override void ConnectNode(Transform otherNode, Transform _receiver, int initialValue)
    {
        

    }

    public override void DisconnectNode(Transform otherNode, Transform _receiver, int _value)
    {
        
    }

    public void UpdateValue(int _value)
    {
       
    }

    public override void ValueChangeEvent()
    {
        
    }

    public override void UpdateDisplay()
    {
        
    }

    public override int GetValue()
    {
        return value;
    }

    public void Execute()
    {
        _event?.Invoke();
    }

}
