using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float TrackingSpeed = 5f;
    
    private void Update()
    {
        transform.position = (Vector2)player.position;
    }
}
