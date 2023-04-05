using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using System;

public class VariableNode : MiddleNode
{

    private Transform connectedNode;
    [SerializeField] private int value;
    [SerializeField] private Transform receiver, variableLabel;
    [SerializeField] private bool isBoolean;
    [SerializeField] private int upperLimit, lowerLimit;
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

    public override void DisconnectNode(Transform otherNode, Transform _receiver, int _value)
    {
        connectedNode.GetComponent<BaseNode>().OnValueChanged -= UpdateValue;
        UpdateValue(_value);
    }

    public void UpdateValue(int _value)
    {
        if (_value >= lowerLimit && _value <= upperLimit)
        {
            value = _value;
            UpdateDisplay();
            ValueChangeEvent();

        }
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

