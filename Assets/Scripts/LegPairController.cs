using System.Collections;
using UnityEngine;

public class LegPairController : MonoBehaviour
{
    [SerializeField] private int pairIndex;
    [SerializeField] private LegPairController pairInFront; // The pair of legs in front
    [Header("Legs")]
    [SerializeField] private LegMovement rightLeg;
    [SerializeField] private LegMovement leftLeg;

    private void Start()
    {
        //segmentController = transform.parent.GetComponent<SegmentController>();
        pairInFront = transform.parent.GetComponent<LegPairController>();
        StartCoroutine(MoveLegs());   
    }

    private IEnumerator MoveLegs()
    {
        while(true)
        {
            do
            {
                rightLeg.Move();
                if (pairInFront != null) { pairInFront.leftLeg.Move(); }
                yield return null;
            }
            while ((pairInFront != null) ? (pairInFront.leftLeg.Moving && rightLeg.Moving)  : rightLeg.Moving);

            do
            {
                leftLeg.Move();
                if (pairInFront != null) { pairInFront.rightLeg.Move(); }
                yield return null;
            }
            while ((pairInFront != null) ? (pairInFront.rightLeg.Moving && leftLeg.Moving) : leftLeg.Moving);
        }
    }
}
