using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : InteractiveObject
{
    

    public override void DoAction(int value)
    {
        GetComponent<Rigidbody>().isKinematic = Convert.ToBoolean(value);
    }

    public void ToggleFloat()
    {
        var floating = GetComponent<Rigidbody>().isKinematic;
        GetComponent<Rigidbody>().isKinematic = !floating;
    }

   
}
