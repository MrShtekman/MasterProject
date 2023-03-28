using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : InteractiveObject
{
    private Vector3 originalPos;
    private bool open;
    [SerializeField] private bool reverse;
    [SerializeField] private Transform destination;
    private void Start()
    {
        originalPos = transform.position;
    }
    public override void DoAction(int value)
    {
        open = Convert.ToBoolean(value);

        if (reverse)
            open = !open;

        StopAllCoroutines();
        if (open)
            StartCoroutine(Open());
        else
            StartCoroutine(Close());
    }


    IEnumerator Open()
    {
        float progress = 0;
        while (progress < 100)
        {
            transform.position = Vector3.Lerp(transform.position, destination.position, progress / 100);
            progress++;
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator Close()
    {
        float progress = 0;
        while (progress < 100)
        {
            transform.position = Vector3.Lerp(transform.position, originalPos, progress / 100);
            progress++;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
