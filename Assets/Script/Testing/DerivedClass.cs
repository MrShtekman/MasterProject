using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DerivedClass : BaseClass
{
    public override void TheFunc()
    {
        Debug.Log("CAlling from derivedClass");
    }
}
