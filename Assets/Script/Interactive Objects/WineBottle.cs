using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WineBottle : InteractiveObject
{
    private float increaseFactor;
    public override void DoAction(int value)
    {
        increaseFactor = value * 0.1f;
        transform.localScale = Vector3.one + new Vector3(increaseFactor, increaseFactor, increaseFactor); ;
    }

   
}
