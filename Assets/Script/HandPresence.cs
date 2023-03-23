using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;



[RequireComponent(typeof(Animator))]
public class HandPresence : MonoBehaviour
{

    private Animator animator;
    private new SkinnedMeshRenderer renderer;
    [SerializeField] bool hideWhenGrab;
    [SerializeField] private ActionBasedController controller;
    [SerializeField] private XRDirectInteractor interactor;

    //for physical hand
    [SerializeField] private bool isPhysics;
    [SerializeField] private Vector3 rotationOffset;

     public Transform target = null;
    private Rigidbody rb;

    private CapsuleCollider[] handColliders = null;

    private float gripValue, triggerValue;

    

    void Start()
    {
        //animation
        animator = GetComponent<Animator>();

        //Hide renderer
        renderer = GetComponentInChildren<SkinnedMeshRenderer>();
        interactor.selectEntered.AddListener(HideHand);
        interactor.selectExited.AddListener(ShowHand);

        //hide collider
        handColliders = GetComponentsInChildren<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();

    }

    private void HideHand(SelectEnterEventArgs arg0)
    {
        if (hideWhenGrab)
        {
            renderer.enabled = false;
            foreach (var collider in handColliders)
            {
                collider.enabled = false;
            }
        }
    }
    private void ShowHand(SelectExitEventArgs arg0)
    {
        if (hideWhenGrab)
        {
            StartCoroutine(Delay(0.3f));
        }
    }

    private IEnumerator Delay(float delayInSec)
    {
        yield return new WaitForSeconds(delayInSec);
        renderer.enabled = true;
        foreach (var collider in handColliders)
        {
            collider.enabled = true;
        }
    }


    private void ApplyPhysics()
    {
        rb.velocity = (target.position - transform.position) / Time.fixedDeltaTime;


        Quaternion targetRotation = target.rotation * Quaternion.Euler(rotationOffset);
        Quaternion rotationiDiff = targetRotation * Quaternion.Inverse(transform.rotation);
        rotationiDiff.ToAngleAxis(out float angleInDegree, out Vector3 rotationAxis);

        if (Mathf.Abs(rotationAxis.magnitude) != Mathf.Infinity)
        {
            if (angleInDegree > 180.0f)
                angleInDegree -= 360.0f; 
           
            Vector3 rotaionDiffDegree = angleInDegree * rotationAxis;
            rb.angularVelocity = rotaionDiffDegree * Mathf.Deg2Rad / Time.fixedDeltaTime;

        }
    }

    void FixedUpdate()
    {

        gripValue = controller.selectActionValue.action.ReadValue<float>();
        triggerValue = controller.activateActionValue.action.ReadValue<float>();

        animator.SetFloat("Grip", gripValue);
        animator.SetFloat("Trigger", triggerValue);

        if (isPhysics)
            ApplyPhysics();


    }




}
