using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class CalculationNode : MonoBehaviour
{
    private int input1, input2; 
    public int output;
    private Transform numberNode1, numberNode2;
    [SerializeField] private Transform receiver1, receiver2, transmitter;
    //[SerializeField] private MathOperation _operator = MathOperation.Multiplication;
    [SerializeField] private Transform input1Label, input2Label, outputLabel;

    // Start is called before the first frame update
    void Start()
    {
        input1Label.GetComponent<TextMeshPro>().text = input1.ToString();
        input2Label.GetComponent<TextMeshPro>().text = input2.ToString();
        Calculate();
    }


    public void ConnectNode(Transform otherNode, Transform _receiver, int initialValue)
    {
        if (_receiver == receiver1)
        {
            numberNode1 = otherNode;
            numberNode1.GetComponent<NumberNode>().OnNumberChanged += UpdateInput1;
            UpdateInput1(initialValue);
        }
        else if (_receiver == receiver2)
        {
            numberNode2 = otherNode;

            numberNode2.GetComponent<NumberNode>().OnNumberChanged += UpdateInput2;
            UpdateInput2(initialValue);
        }
    }

    public void DisconnectNode(Transform otherNode, Transform _receiver, int value)
    {
        if (numberNode1 == otherNode)
        {           
            numberNode1.GetComponent<NumberNode>().OnNumberChanged -= UpdateInput1;
            UpdateInput1(value);
        }
        else if (numberNode2 == otherNode)
        {       
            numberNode2.GetComponent<NumberNode>().OnNumberChanged -= UpdateInput2;
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
        outputLabel.GetComponent<TextMeshPro>().text = output.ToString();

    }
}
