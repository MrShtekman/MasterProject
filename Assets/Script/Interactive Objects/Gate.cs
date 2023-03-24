using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : InteractiveObject
{
    private Vector3 originalPos;
    private float moveDistance = 0;

    [SerializeField] private Transform destination;
    private void Start()
    {
        originalPos = transform.position;
    }
    public override void DoAction(int value)
    {
        StopAllCoroutines();
        if (value == 1)
            StartCoroutine(Open());
        else
            StartCoroutine(Close());
    }


    IEnumerator Open()
    {
        transform.position = Vector3.Lerp(transform.position, destination.position, Time.deltaTime);
        yield return new WaitForSeconds(0.05f);
    }

    IEnumerator Close()
    {
        transform.position = Vector3.Lerp(transform.position, originalPos, Time.deltaTime);
        yield return new WaitForSeconds(0.05f);
    }
}
