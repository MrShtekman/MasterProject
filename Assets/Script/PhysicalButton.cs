using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicalButton : MonoBehaviour
{
    [SerializeField] private Transform buttonTop;
    [SerializeField] private Transform buttonLowerLimit;
    [SerializeField] private Transform buttonUpperLimit;
    [SerializeField] private float threshHold;
    [SerializeField] private float force = 10;
    [SerializeField] private UnityEvent onPressed;
    [SerializeField] private UnityEvent onReleased;
    [SerializeField] private AudioSource pressedSound;
    [SerializeField] private AudioSource releaseSound;

    private bool isPressed;
    private bool prevPressedState;
    private float upperLowerDiff;

    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreCollision(GetComponent<Collider>(), buttonTop.GetComponent<Collider>());
        if (transform.eulerAngles != Vector3.zero)
        {
            Vector3 saveAngle = transform.eulerAngles;
            transform.eulerAngles = Vector3.zero;
            upperLowerDiff = buttonUpperLimit.position.y - buttonLowerLimit.position.y;
            transform.eulerAngles = saveAngle;
        }
        else
            upperLowerDiff = buttonUpperLimit.position.y - buttonLowerLimit.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        buttonTop.transform.localPosition = new Vector3(0, buttonTop.transform.localPosition.y, 0);
        buttonTop.transform.localEulerAngles = Vector3.zero;

        if (buttonTop.localPosition.y >= 0)
            buttonTop.transform.position = new Vector3(buttonUpperLimit.position.x, buttonUpperLimit.position.y, buttonLowerLimit.position.z);
        else
            buttonTop.GetComponent<Rigidbody>().AddForce(buttonTop.transform.up * force * Time.fixedDeltaTime);

        if (buttonTop.localPosition.y <= buttonLowerLimit.localPosition.y)
            buttonTop.transform.position = new Vector3(buttonLowerLimit.position.x, buttonLowerLimit.position.y, buttonLowerLimit.position.z);

        if (Vector3.Distance(buttonTop.position, buttonLowerLimit.position) < upperLowerDiff * threshHold)
            isPressed = true;
        else
            isPressed = false;

        if (isPressed && prevPressedState != isPressed)
            Pressed();
        if (!isPressed && prevPressedState != isPressed)
            Released();
    }

    private void Pressed()
    {
        prevPressedState = isPressed;
        onPressed.Invoke();
    }
    private void Released()
    {
        prevPressedState = isPressed;
        onReleased.Invoke();
    }

}
