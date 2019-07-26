using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateDistance : MonoBehaviour
{
    Vector3 Destination;
    public static float Distance_ = 0;
    Vector3 lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        Destination = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Distance_ += Vector3.Distance(transform.position, Destination);
        Destination = transform.position;
    }
}
