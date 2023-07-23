using UnityEngine;

public class Camera : MonoBehaviour
{
    private const float MAX_X = 60f;

    private const float MIN_X = -60f;

    private Transform playerTransform;

    private GameObject playerObject;

    void Start()
    {
        Debug.Log(GameManager.instance.playerIndex);

        this.playerObject = GameObject.FindWithTag("Player");

        if (this.playerObject != null)
        {
            this.playerTransform = this.playerObject.transform;
        }
    }


    private void LateUpdate()
    {
        this.FollowPlayerBehaviour();
    }

    private void FollowPlayerBehaviour()
    {
        if (this.playerObject == null)
        {
            return;
        }

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
