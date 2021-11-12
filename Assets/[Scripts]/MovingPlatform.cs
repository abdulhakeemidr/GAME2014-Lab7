using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Header("Movement")]
    public MovingPlatformDirection direction;
    [Range(0.1f, 10.0f)]
    public float speed;
    [Range(1, 20)]
    public float distance;
    [Range(0.05f, 0.1f)]
    public float distanceOffset;
    public bool isLooping;

    private Vector2 startingPosition;
    private bool IsMoving;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        IsMoving = true;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
        if(isLooping)
        {
            IsMoving = true;
        }
    }

    private void MovePlatform()
    {
        float pingPongValue = (IsMoving) ? Mathf.PingPong(Time.time * speed, distance) : distance;

        if((!isLooping) && (pingPongValue >= distance - distanceOffset))
        {
            IsMoving = false;
        }
        Debug.Log(pingPongValue);
        switch(direction)
        {
            case MovingPlatformDirection.HORIZONTAL:
                transform.position = new Vector2(startingPosition.x + pingPongValue, transform.position.y);
                break;
            case MovingPlatformDirection.VERTICAL:
                transform.position = new Vector2(startingPosition.x, startingPosition.y + pingPongValue);
                break;
            case MovingPlatformDirection.DIAGONAL_UP:
                transform.position = new Vector2(startingPosition.x + pingPongValue, startingPosition.y + pingPongValue);
                break;
            case MovingPlatformDirection.DIAGONAL_DOWN:
                transform.position = new Vector2(startingPosition.x + pingPongValue, startingPosition.y - pingPongValue);
                break;
        }

        
    }
}
