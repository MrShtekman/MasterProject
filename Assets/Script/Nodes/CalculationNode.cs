using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class CalculationNode : MiddleNode
{
    private int input1, input2; 
    public int output;
    private Transform connectedNode1, connectedNode2;
    [SerializeField] private Transform receiver1, receiver2, transmitter;
    //[SerializeField] private MathOperation _operator = MathOperation.Multiplication;
    [SerializeField] private Transform input1Label, input2Label, outputLabel;

    public override event NodeAction OnValueChanged;

    // Start is called before the first frame update
    void Start()
    {
        input1Label.GetComponent<TextMeshPro>().text = input1.ToString();
        input2Label.GetComponent<TextMeshPro>().text = input2.ToString();
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
        input1Label.GetComponent<TextMeshPro>().text = input1.ToString();
        Calculate();
    }

    public void UpdateInput2(int value)
    {
        input2 = value;
        input2Label.GetComponent<TextMeshPro>().text = input2.ToString();
        Calculate();
    }

    private void Calculate()
    {
        output = input1 * input2;
        UpdateDisplay();

    }

    public override void UpdateDisplay()
    {
        output = input1 * input2;
        outputLabel.GetComponent<TextMeshPro>().text = output.ToString();
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
