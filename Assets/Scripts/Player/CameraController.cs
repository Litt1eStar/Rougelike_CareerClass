using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float cameraOffset = 0.5f; 
    [SerializeField] private float smoothSpeed = 0.125f;

    private void Update()
    {        
        Vector3 playerPos = PlayerManager.Instance.transform.position;
        float camOffset = PlayerManager.Instance.movement.XInput() > 0 ? -cameraOffset : cameraOffset;
        Vector3 targetPosition = new Vector3(playerPos.x + camOffset, playerPos.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
    }
}
