using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : InteractiveObject
{
    [SerializeField] int password = 2023;
    private int angle = -90;


    public override void DoAction(int value)
    {
        StopAllCoroutines();
        if (value == password)
        {
            StartCoroutine(OpenDoor());
        }
        else
        {
            StartCoroutine(CloseDoor());
        }
    }

    IEnumerator OpenDoor()
    {
        while (transform.rotation.eulerAngles.y > 270)
        {
            Debug.Log(transform.rotation.eulerAngles.y);
            transform.Rotate(0, -1, 0);
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator CloseDoor()
    {
        while (transform.rotation.eulerAngles.y < 359)
        {
            transform.Rotate(0, 1, 0);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
