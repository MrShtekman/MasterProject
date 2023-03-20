using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DerivedClass1 : BaseClass
{
    public override void TheFunc()
    {
        Debug.Log("CAlling from second derivedClass");
    }
}
