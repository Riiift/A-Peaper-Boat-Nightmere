using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraBehaviour : MonoBehaviour
{
    public Transform playerPos;
    private Vector3 camaraOffset;
    [Range(.01f, 1.0f)]
    public float smoothFactor = .5f;

    private void Start()
    {
        camaraOffset = transform.position - playerPos.position; 
    }
    private void Update()
    {
        Vector3 newPos = playerPos.position + camaraOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);
    }

}
