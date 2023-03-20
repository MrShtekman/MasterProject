using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseClass : MonoBehaviour
{
    public virtual void TheFunc()
    {
        Debug.Log("calling from base class");
    }
    
}
