using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private const float MAX_X = 60f;
    
    private const float MIN_X = -60f;

    private Transform playerTransform;
    
    private GameObject playerObject;
   
    void Start()
    {
        this.playerObject = GameObject.FindWithTag("Player");

        if (this.playerObject != null) {
            this.playerTransform = this.playerObject.transform;
        }
    }


    private void LateUpdate()
    {
        this.FollowPlayerBehaviour();
    }

    private void FollowPlayerBehaviour()
    {
        var currentPosition = this.transform.position;
        currentPosition.x = this.playerTransform.position.x;

        if (currentPosition.x < Camera.MIN_X)
        {
            currentPosition.x = Camera.MIN_X;
        }

        if (currentPosition.x > Camera.MAX_X)
        {
            currentPosition.x = Camera.MAX_X;
        }

        this.transform.position = currentPosition;
    }
}
