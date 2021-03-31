using UnityEngine;

public class SegmentController : MonoBehaviour
{
    [Header("Right Leg")]
    [SerializeField] private LegMovement rightLeg;
    [Header("Left Leg")]
    [SerializeField] private LegMovement leftLeg;


    // Update is called once per frame
    void Update()
    {
        if (rightLeg.Moving)
        {
            rightLeg.allowMovement = true;
            leftLeg.allowMovement = false;
        }
        else if(leftLeg.Moving)
        {
            leftLeg.allowMovement = true;
            rightLeg.allowMovement = false;
        }
    }
}
