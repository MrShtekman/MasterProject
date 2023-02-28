using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicalButton : MonoBehaviour
{
    [SerializeField] private Transform buttonTop;
    [SerializeField] private Transform buttonLowerLimit;
    [SerializeField] private Transform buttonupperLimit;
    [SerializeField] private float threshHold;
    [SerializeField] private float force = 10;
    [SerializeField] private bool isPressed;
    [SerializeField] private UnityEvent onPressed;
    [SerializeField] private UnityEvent onReleased;

    private bool prevPressedState;
    private float upperLowerDiff;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
