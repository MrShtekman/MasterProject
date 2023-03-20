using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public event Action onButtonPressed;

    [SerializeField] private float threshold = 0.1f;
    [SerializeField] private float deadZone = 0.025f;

    private bool _pressed = false;
    private Vector3 _startPos;
    private ConfigurableJoint _joint;
    void Start()
    {
        _startPos = transform.localPosition;
        _joint = GetComponent<ConfigurableJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GetValue() + threshold >= 1 && !_pressed)
        {
            onButtonPressed?.Invoke();
            _pressed = true;
        }
        if (GetValue() - threshold <= 0)
            _pressed = false;
    }

    private float GetValue()
    {
        var value = Vector3.Distance(_startPos, transform.localPosition) / _joint.linearLimit.limit;
        if (Math.Abs(value) < deadZone)
            value = 0;

        return Mathf.Clamp(value, -1f, 1f);
    }
}
