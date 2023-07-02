using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Camera : MonoBehaviour
{

    private Transform playerTransform;

    private const float MAX_X = 60f;
    
    private const float MIN_X = -60f;

    // Start is called before the first frame update
    void Start()
    {
        var playerObject = GameObject.FindWithTag("Player");

        if (playerObject != null) {
            this.playerTransform = playerObject.transform;
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
