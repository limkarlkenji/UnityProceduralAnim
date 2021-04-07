using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class CentipedeController : MonoBehaviour
{
    [SerializeField] private Transform headTarget;
    [SerializeField] private Transform head;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float turnAngle;

    [SerializeField] private float frequency;
    [SerializeField] private float amplitude;

    private float t = 0;
    private Rig rig;

    [SerializeField] private Vector3 headTargetOrigin;

    private void Start()
    {
        rig = GetComponent<RigBuilder>().layers[0].rig;
        headTargetOrigin = headTarget.localPosition;
    }

    private void MoveHeadTarget()
    {
        t += Time.deltaTime;
        Vector3 pos = headTarget.localPosition;
        pos.x = amplitude * Mathf.Sin(t * frequency);
        headTarget.localPosition = pos;
    }

    // Update is called once per frame
    private void Update()
    {
        // Foward and backward movement
        if (Input.GetKey(KeyCode.W))
        {
            rig.weight = 1.0f;
            transform.position += transform.forward * moveSpeed;

            head.LookAt(headTarget.position);
            MoveHeadTarget();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += -transform.forward * moveSpeed;
        }

    }
}
