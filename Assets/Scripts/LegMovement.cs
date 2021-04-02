using System.Collections;
using UnityEngine;

public class LegMovement : MonoBehaviour
{
    public Transform homeTransform; // The position and rotation we want to stay in range of
    public bool Moving;             // Is the leg moving?

    [SerializeField] private float allowedDistanceFromHome; // Stay within this distance of home
    [SerializeField] private float moveOffset;              // Adds an offset when moving the target towards home (Adds this value on local Z forward)
    [SerializeField] private float legBendHeightOffset;           // How high will the leg bend up when moving
    [SerializeField] private float moveDuration;            // How long a step takes to complete
    [SerializeField] private float dist;

    private Vector3 lastPos;

    private void Start()
    {
        lastPos = transform.position;
    }

    private IEnumerator MoveToHome()
    {
        Moving = true;
        Vector3 endPoint = homeTransform.position + (transform.forward * moveOffset);
        float timeElapsed = 0;

        while (timeElapsed < moveDuration)
        {
            timeElapsed += Time.deltaTime;
            float normalizedTime = timeElapsed / moveDuration;
            transform.position = Bezier(lastPos, endPoint, normalizedTime);   // Interpolate position and rotation

            yield return null;
        }

        lastPos = transform.position;
        Moving = false;
    }

    public void Move()
    {
        if (Moving)
        {
            return;
        }

        dist = Vector3.Distance(transform.position, homeTransform.position);

        if (dist > allowedDistanceFromHome)      // If we are too far off in position or rotation
        {
            StartCoroutine(MoveToHome());   // Start the step coroutine
        }
        else
        {
            transform.position = lastPos;
        }

    }

    Vector3 Bezier(Vector3 current, Vector3 target, float t)
    {
        Vector3 p0 = current;
        Vector3 p1 = (current + (target - current) / 2) + (Vector3.up * legBendHeightOffset);
        Vector3 p2 = target;
        Vector3 q1 = Vector3.Lerp(p0, p1, t);
        Vector3 q2 = Vector3.Lerp(p1, p2, t);

        return Vector3.Lerp(q1, q2, t);
    }
}
