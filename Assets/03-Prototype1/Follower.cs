using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public GameObject targetObject;
    private Vector3 initialPosition;

    public GameObject ground;
    private Vector3 groundPosition;


    public float easing = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = this.transform.position;
        groundPosition = ground.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPoisition;

        if (targetObject != null &&
            targetObject.GetComponent<Rigidbody>().velocity.magnitude < 0.01)
            targetObject = null;

        if (targetObject == null)
            targetPoisition = initialPosition;
        else

            targetPoisition = targetObject.transform.position;

        Vector3 followPosition = Vector3.Lerp(this.transform.position, targetPoisition, easing);

        if (followPosition.x < initialPosition.x)
            followPosition.x = initialPosition.x;
        if (followPosition.x < initialPosition.y)
            followPosition.x = initialPosition.y;

        followPosition.z = initialPosition.z;

        this.transform.position = followPosition;

        this.GetComponent<Camera>().orthographicSize = followPosition.y - groundPosition.y;

    }
}
