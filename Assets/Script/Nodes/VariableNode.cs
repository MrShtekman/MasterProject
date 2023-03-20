using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using System;

public class VariableNode : MiddleNode
{
    private int value;
    private Transform connectedNode;
    [SerializeField] private Transform receiver, transmitter;
    [SerializeField] private Transform variableLabel;
    [SerializeField] private bool isBoolean;

    public override event NodeAction OnValueChanged;

    // Start is called before the first frame update
    void Start()
    {
        UpdateDisplay();      
    }


    public override void ConnectNode(Transform otherNode, Transform _receiver, int initialValue)
    {
            connectedNode = otherNode;
            connectedNode.GetComponent<BaseNode>().OnValueChanged += UpdateValue;
            UpdateValue(initialValue);
    
    }

    public override void DisconnectNode(Transform otherNode, Transform _receiver, int value)
    {
            connectedNode.GetComponent<BaseNode>().OnValueChanged -= UpdateValue;
            UpdateValue(value);             
    }

    public void UpdateValue(int value)
    {
        var input = true;
        if (isBoolean)
           input = Convert.ToBoolean(value);

    }

    public override void ValueChangeEvent()
    {
        OnValueChanged?.Invoke(value);
    }

    public override void UpdateDisplay()
    {
        if (isBoolean)
            variableLabel.GetComponent<TextMeshPro>().text = Convert.ToBoolean(value).ToString();
        else
            variableLabel.GetComponent<TextMeshPro>().text = value.ToString();
    }

    public override int GetValue()
    {
        return value;
    }
}

