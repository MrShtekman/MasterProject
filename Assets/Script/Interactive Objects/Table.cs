using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Table : BaseNode
{

    public int value = 0;

    public override event BaseNode.NodeAction OnValueChanged;

 

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collectable")
        {
            value++;
            ValueChangeEvent();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Collectable")
        {
            value--;
            ValueChangeEvent();
        }
    }

    public override void ValueChangeEvent()
    {
        OnValueChanged?.Invoke(value);

    }

    public override void UpdateDisplay()
    {
        
    }

    public override int GetValue()
    {
        return value;
    }


}
