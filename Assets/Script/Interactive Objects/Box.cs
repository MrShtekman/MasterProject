using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Box : InteractiveObject
{
    [SerializeField] private Material kinematicMaterial, normalMaterial;
    private bool isKinematic;
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

    public void Teleportable()
    {
        GetComponent<TeleportationArea>().enabled = true;
    }

    public void NotTeleportable()
    {
        GetComponent<TeleportationArea>().enabled = false;
    }
   
}
