using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumberNode : BaseNode
{
    public int value, upperLimit, lowerLimit = 0;
    [SerializeField] private GameObject display;
    [SerializeField] private GameObject transmitter;


    public override event BaseNode.NodeAction OnValueChanged;

    public void Start()
    {
        display.GetComponent<TextMeshPro>().text = value.ToString();
    }

    //Change the value and invoke the event
    public void ChangeNumber(int addNumber)
    {
        if ((value < upperLimit && addNumber > 0) || (value > lowerLimit && addNumber < 0))
        {
            value += addNumber;
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
        display.GetComponent<TextMeshPro>().text = value.ToString();
    }

    public override int GetValue()
    {
        return value;
    }
}
