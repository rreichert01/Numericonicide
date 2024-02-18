// It was suggested that I use a prebuilt camera controler
// This script was retrieved from: https://pastebin.com/D6A0pQPn

using UnityEngine;
using System.Collections;
using System;

public class CamController : MonoBehaviour
{

    public Transform player;
    public float damping = 0.3f;
    public float lookAheadFactor = 3;
    public float lookAheadReturnSpeed = 0.5f;
    public float lookAheadMoveThreshold = 0.1f;

    private float offsetZ;
    private Vector3 lastTargetPosition;
    private Vector3 currentVelocity;
    private Vector3 lookAheadPos;


    // Use this for initialization
    void Start()
    {
        lastTargetPosition = player.position;
        offsetZ = transform.position.z - player.position.z;
        transform.parent = null;
    }


    public void Awake()
    {
        GetComponent<Camera>().orthographicSize = (Screen.height / 120f); 
    }

    void Update()
    {
        float xMoveDelta = player.position.x - lastTargetPosition.x;
        bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

        if (updateLookAheadTarget)
        {
            lookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign(xMoveDelta);
        }
        else
        {
            lookAheadPos = Vector3.MoveTowards(lookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);
        }

        Vector3 aheadTargetPos = player.position + lookAheadPos + Vector3.forward * offsetZ;
        Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref currentVelocity, damping);


        transform.position = newPos;
        lastTargetPosition = player.position;
    }
}