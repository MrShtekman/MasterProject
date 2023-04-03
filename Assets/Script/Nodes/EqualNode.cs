using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EqualNode : MiddleNode
{
    private int input1, input2;
    [HideInInspector] public int output;
    private Transform connectedNode1, connectedNode2;

    [SerializeField] private Transform receiver1, receiver2;
    [SerializeField] private Transform input1Label, input2Label, outputLabel;


    public override event NodeAction OnValueChanged;

    // Start is called before the first frame update
    void Start()
    {
        UpdateInput1(input1);
        UpdateInput2(input2);

        Compare();
    }


    public override void ConnectNode(Transform otherNode, Transform _receiver, int initialValue)
    {
        //if the receiver connected is receiver1, connect connectedNode1 to the other node and subsrive to their event and update value1
        if (_receiver == receiver1)
        {
            connectedNode1 = otherNode;
            connectedNode1.GetComponent<BaseNode>().OnValueChanged += UpdateInput1;
            UpdateInput1(initialValue);
        }
        //else if the receiver connected is receiver2, connect connectedNode2 to the other node and subsrive to their event and update value2
        else if (_receiver == receiver2)
        {
            connectedNode2 = otherNode;

            connectedNode2.GetComponent<BaseNode>().OnValueChanged += UpdateInput2;
            UpdateInput2(initialValue);
        }
    }

    public override void DisconnectNode(Transform otherNode, Transform _receiver, int value)
    {
        if (connectedNode1 == otherNode)
        {
            connectedNode1.GetComponent<BaseNode>().OnValueChanged -= UpdateInput1;
            UpdateInput1(value);
        }
        else if (connectedNode2 == otherNode)
        {
            connectedNode2.GetComponent<BaseNode>().OnValueChanged -= UpdateInput2;
            UpdateInput2(value);
        }
    }

    public void UpdateInput1(int value)
    {
        input1 = value;
        input1Label.GetComponent<TextMeshPro>().text = input1.ToString();
        Compare();
    }

    public void UpdateInput2(int value)
    {
        input2 = value;
        input2Label.GetComponent<TextMeshPro>().text = input2.ToString();
        Compare();
    }



    private void Compare()
    {
        output = input1 == input2? 1 : 0;
        UpdateDisplay();
        ValueChangeEvent();
    }

    public override void UpdateDisplay()
    {

        outputLabel.GetComponent<TextMeshPro>().text = Convert.ToBoolean(output).ToString();
    }

    public override int GetValue()
    {
        return output;

    }

    public override void ValueChangeEvent()
    {
        OnValueChanged?.Invoke(output);
    }
}
