using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallingClass : MonoBehaviour
{
    public GameObject block, block1;
    void Start()
    {
        block.GetComponent<BaseClass>().TheFunc();
        block1.GetComponent<BaseClass>().TheFunc();
    }

    
}
