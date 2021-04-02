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

    private void Start()
    {
        rig = GetComponent<RigBuilder>().layers[0].rig;
    }

    private void MoveHeadTarget()
    {
        t += Time.deltaTime;
        Vector3 pos = headTarget.position;
        pos.x += Mathf.Sin(t * Mathf.PI * frequency) * amplitude;
        headTarget.position = pos;
    }

    // Update is called once per frame
    private void Update()
    {
        
       
        // Foward and backward movement
        if (Input.GetKey(KeyCode.W))
        {
            rig.weight = 1.0f;
            transform.position += transform.forward * moveSpeed;
            head.position = new Vector3(headTarget.position.x, head.position.y, head.position.z);
            // Turning
            if (Input.GetKey(KeyCode.Q))
            {
                transform.rotation *= Quaternion.Euler(0, -turnAngle, 0);

            }
            else if (Input.GetKey(KeyCode.E))
            {
                transform.rotation *= Quaternion.Euler(0, turnAngle, 0);

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
            headTarget.position = Vector3.zero;
        }
    }
}
