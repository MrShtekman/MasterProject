using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BooleanNode : BaseNode
{
    [SerializeField] private bool value;
    [SerializeField] private GameObject display;


    
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
        display.GetComponent<TextMeshPro>().text = Convert.ToString(value);
    }

    public override int GetValue()
    {
        return Convert.ToInt32(value);
    }

    public void OnButtonPressed()
    {
        value = true;
        ValueChangeEvent();
    }

    public void OnButtonReleased()
    {
        value = false;
        ValueChangeEvent();
    }

    public void Toggle()
    {
        value = !value;
        ValueChangeEvent();
        UpdateDisplay();
    }
}
