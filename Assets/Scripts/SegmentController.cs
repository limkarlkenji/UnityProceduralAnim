using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentController : MonoBehaviour
{
    public List<LegPairController> segments = new List<LegPairController>();

    private void Start()
    {
        //for (int i = 0; i < transform.childCount; i++)
        //{
        //    segments.Add(transform.GetChild(i).GetComponent<LegPairController>().SetIndex(i));
        //}

        //for (int i = 0; i < transform.childCount; i++)
        //{
        //    segments.Add(transform.GetChild(i).GetComponent<LegPairController>().SetIndex(i));
        //}
    }
}
