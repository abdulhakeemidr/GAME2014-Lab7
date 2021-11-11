using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform player;
    public Transform playerSpawnPoint;

    void Start()
    {
        player.position = playerSpawnPoint.position;
    }

}
