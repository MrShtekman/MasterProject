using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BooleanNode : BaseNode
{
    [SerializeField] private bool value;
    [SerializeField] private GameObject display;
    [SerializeField] private GameObject transmitter;

    
    public override event BaseNode.NodeAction OnValueChanged;

    void Start()
    {
        display.GetComponent<TextMeshPro>().text = value.ToString();
    }

    public override void ValueChangeEvent()
    {
        //turning the bool to int
        OnValueChanged?.Invoke(Convert.ToInt32(value));
    }

    public override void UpdateDisplay()
    {
        throw new NotImplementedException();
    }

    public override int GetValue()
    {
        return Convert.ToInt32(value);
    }
}
