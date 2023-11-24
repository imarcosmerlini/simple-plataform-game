using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    
    // Update is called once per frame
    private void Update()
    {
        var playerPosition = player.position;
        var cameraPosition = transform;
        cameraPosition.position = new Vector3(playerPosition.x, playerPosition.y, cameraPosition.position.z);
    }
}
