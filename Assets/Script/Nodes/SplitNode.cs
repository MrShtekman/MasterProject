using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SplitNode : MiddleNode
{
    private int input;
    private Transform connectedNode;

    [SerializeField] private Transform inputLabel, outputLabel1, outputLabel2;
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
            taken = true;

    }

    public override void DisconnectNode(Transform otherNode, Transform _receiver, int value)
    {
 
            connectedNode.GetComponent<BaseNode>().OnValueChanged -= UpdateInput;
            UpdateInput(value);
            taken = false;
   }

    public void UpdateInput(int value)
    {
        input = value;
        UpdateDisplay();
        ValueChangeEvent();
    }



    public override void UpdateDisplay()
    {
        var value = Convert.ToBoolean(input);
        inputLabel.GetComponent<TextMeshPro>().text = value.ToString();
        outputLabel1.GetComponent<TextMeshPro>().text = value.ToString();
        outputLabel2.GetComponent<TextMeshPro>().text = value.ToString();
    }

    public override int GetValue()
    {
        return input;
    }

    public override void ValueChangeEvent()
    {
        OnValueChanged?.Invoke(input);
    }

}
