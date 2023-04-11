using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class CalculationNode : MiddleNode
{
    private int input1, input2; 
    [HideInInspector] public int output;
    private Transform connectedNode1, connectedNode2;

    [SerializeField] private int calculationIndex;
    [SerializeField] private Transform receiver1, receiver2;
    [SerializeField] private Transform input1Label, input2Label, outputLabel;
    [SerializeField] private TextMeshPro operationType, operationSymbol;


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
            connectedNode1 = null;
            UpdateInput1(value);
        }
        else if (connectedNode2 == otherNode)
        {       
            connectedNode2.GetComponent<BaseNode>().OnValueChanged -= UpdateInput2;
            connectedNode1 = null;
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

    public void ChangeCalculation()
    {
        if (calculationIndex < 3)
            calculationIndex++;
        else
            calculationIndex = 0;

        ChangeLabel();

        Calculate();
    }

    private void ChangeLabel()
    {
        switch (calculationIndex)
        {
            case 0:
                operationType.text = "Multiply";
                operationSymbol.text = "×";
                break;
            case 1:
                operationType.text = "Divide";
                operationSymbol.text = "/";
                break;
            case 2:
                operationType.text = "Add";
                operationSymbol.text = "+";
                break;
            case 3:
                operationType.text = "Subtract";
                operationSymbol.text = "–";
                break;
            default:
                break;
        }
    }


    private void Calculate()
    {
        switch (calculationIndex)
        {
            case 0:
                output = input2 * input1;
                break;
            case 1:
                if (input1 == 0)
                    return;
                else
                    output = (int)Mathf.Round((float)input2 / (float)input1);
                break;
            case 2:
                output = input2 + input1;
                break;
            case 3:
                output = input2 - input1;
                break;
            default:
                break;
        }
        
        UpdateDisplay();
        ValueChangeEvent();
    }

    public override void UpdateDisplay()
    {
        
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
