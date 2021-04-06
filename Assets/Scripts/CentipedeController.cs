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
            // Turning
            if (Input.GetKey(KeyCode.Q))
            {
                //transform.rotation *= Quaternion.Euler(0, -turnAngle, 0);
                transform.Rotate(Vector3.up * -turnAngle);

            }
            else if (Input.GetKey(KeyCode.E))
            {
                transform.Rotate(Vector3.up * turnAngle);

            }
            else
            {
                
                MoveHeadTarget();
            }

        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += -transform.forward * moveSpeed;
        }
        // Right and left movement
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * moveSpeed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += -transform.right * moveSpeed;
        }

        if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.E) )
        {
            rig.weight = 0.0f;
            //headTarget.localPosition = headTargetOrigin;
        }
    }
}
