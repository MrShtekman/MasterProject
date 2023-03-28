using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Door : InteractiveObject
{
    [SerializeField] private int password = 2023;
    [SerializeField] private Transform targetRotation;
    private quaternion originalRotation;


    private void Start()
    {
        originalRotation = transform.rotation;
    }

    public override void DoAction(int value)
    {
        StopAllCoroutines();
        if (value == password)
            StartCoroutine(OpenDoor());
        else
            StartCoroutine(CloseDoor());
    }

    IEnumerator OpenDoor()
    {

        float progress = 0;
        while (progress < 100)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation.rotation, progress / 100);
            progress++;
            yield return new WaitForSeconds(0.02f);
        }
    }

    IEnumerator CloseDoor()
    {
        float progress = 0;
        while (progress < 100)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, originalRotation, progress / 100);
            progress++;
            yield return new WaitForSeconds(0.02f);
        }
    }
}
