using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : InteractiveObject
{
    private bool isKinematic;
    [SerializeField] private Material kinematicMaterial, normalMaterial;
    private Rigidbody rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        isKinematic = rigidBody.isKinematic;
        MakeKinematic(isKinematic);
    }

    public override void DoAction(int value)
    {
        isKinematic = Convert.ToBoolean(value);
        Debug.Log("DoAction: " + isKinematic);
        MakeKinematic(isKinematic);
    }

    public void ToggleKinematic()
    {
        isKinematic = !isKinematic;
        MakeKinematic(isKinematic);
    }

    public void OnRelease()
    {
        MakeKinematic(isKinematic);
    }

    private void MakeKinematic(bool kinematic)
    {
        rigidBody.isKinematic = kinematic;

        if (kinematic)
            GetComponent<Renderer>().material = kinematicMaterial;
        else
            GetComponent<Renderer>().material = normalMaterial;
    }

   
}
