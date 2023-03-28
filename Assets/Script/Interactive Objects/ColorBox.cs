using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBox : InteractiveObject
{
    [SerializeField] private Material color1, color2;

    public void ChangeColor(int index)
    {
        if(index == 1)
            GetComponent<Renderer>().material = color1;
        else
            GetComponent<Renderer>().material = color2;
        
    }

    public override void DoAction(int value)
    {
        throw new System.NotImplementedException();
    }
}
