using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class LogicNode : MiddleNode
{
    private int input1, input2;
    [HideInInspector] public int output;
    private Transform connectedNode1, connectedNode2;

    [SerializeField] private LogicOperation _operation = LogicOperation.And;
    [SerializeField] private Transform receiver1, receiver2, transmitter;
    [SerializeField] private Transform input1Label, input2Label, outputLabel;
    [SerializeField] private TextMeshPro operationType;

    public override event NodeAction OnValueChanged;

    // Start is called before the first frame update
    void Start()
    {
        UpdateInput1(input1);
        UpdateInput2(input2);

        ChangeLabel();
        Calculate();
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
        input1Label.GetComponent<TextMeshPro>().text = Convert.ToBoolean(input1).ToString();
        Calculate();
    }

    public void UpdateInput2(int value)
    {
        input2 = value;
        input2Label.GetComponent<TextMeshPro>().text = Convert.ToBoolean(input2).ToString();
        Calculate();
    }


    private void ChangeLabel()
    {
        switch (_operation.ToString())
        {
            case "And":
                operationType.text = "AND";
                break;
            case "Or":
                operationType.text = "OR";
                break;
            default:
                break;
        }
    }


    private void Calculate()
    {
        var bool1 = Convert.ToBoolean(input1);
        var bool2 = Convert.ToBoolean(input2);
        var bool3 = false;
        switch (_operation.ToString())
        {
            case "And":
                bool3 = bool1 && bool2;
                break;
            case "Or":
                bool3 = bool1 || bool2;
                break;
            default:
                break;
        }

        output = Convert.ToInt32(bool3);
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
