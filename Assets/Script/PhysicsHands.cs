using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PhysicsHands : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Rigidbody rb;

    private Animator animator;
    [SerializeField] private ActionBasedController controller;
    [SerializeField] private Vector3 rotationOffset;

    private float gripValue, triggerValue;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        animator = GetComponent<Animator>();

    }

    private void FixedUpdate()
    {
        gripValue = controller.selectActionValue.action.ReadValue<float>();
        triggerValue = controller.activateActionValue.action.ReadValue<float>();

        animator.SetFloat("Grip", gripValue);
        animator.SetFloat("Trigger", triggerValue);

        rb.velocity = (target.position - transform.position) / Time.fixedDeltaTime;


        Quaternion targetRotation = target.rotation * Quaternion.Euler(rotationOffset);
        Quaternion rotationiDiff = targetRotation * Quaternion.Inverse(transform.rotation);
        rotationiDiff.ToAngleAxis(out float angleInDegree, out Vector3 rotationAxis);

        Vector3 rotaionDiffDegree = angleInDegree * rotationAxis;

        rb.angularVelocity = rotaionDiffDegree * Mathf.Deg2Rad / Time.fixedDeltaTime;
    }
}
