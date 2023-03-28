using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ConditionalNode : MiddleNode
{
    private int input;
    private Transform connectedNode;

    [SerializeField] private Transform inputLabel;
    [SerializeField] private UnityEvent IfTrue, IfFalse;
    public override event NodeAction OnValueChanged;

    // Start is called before the first frame update
    void Start()
    {
        UpdateInput(input);

    }


    public override void ConnectNode(Transform otherNode, Transform _receiver, int initialValue)
    {

        connectedNode = otherNode;
        connectedNode.GetComponent<BaseNode>().OnValueChanged += UpdateInput;
        UpdateInput(initialValue);


    }

    public override void DisconnectNode(Transform otherNode, Transform _receiver, int value)
    {

        connectedNode.GetComponent<BaseNode>().OnValueChanged -= UpdateInput;
        UpdateInput(value);

    }

    public void UpdateInput(int _input)
    {
        input = _input;
        var value = Convert.ToBoolean(input);
        inputLabel.GetComponent<TextMeshPro>().text = value.ToString();

    }



    public override void UpdateDisplay()
    {
        var value = Convert.ToBoolean(input);

        if (value)
            IfTrue?.Invoke();
        else
            IfFalse?.Invoke();
    }

    public override int GetValue()
    {
        return input;
    }

    public override void ValueChangeEvent()
    {

    }
}
