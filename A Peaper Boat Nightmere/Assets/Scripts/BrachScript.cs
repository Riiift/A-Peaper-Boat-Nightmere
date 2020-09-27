using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrachScript : MonoBehaviour
{
    private Vector3 nextPosition;
    public Transform position1, position2;
    public Transform startPosition;
    public float speed;

    void Start()
    {
        nextPosition = startPosition.position;
    }

    void Update()
    {
        PlatformMove();
    }

    void PlatformMove()
    {
        if (transform.position == position1.position)
        {
            nextPosition = position2.position;
        }

        if (transform.position == position2.position)
        {
            nextPosition = position1.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime);
    }
}
