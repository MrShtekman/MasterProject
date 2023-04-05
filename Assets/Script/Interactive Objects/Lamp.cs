using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : InteractiveObject
{
    [SerializeField] private Light lightSource;
   

    public override void DoAction(int value)
    {

        lightSource.enabled = Convert.ToBoolean(value);

    }

    
}
