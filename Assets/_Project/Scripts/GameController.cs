using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController instance;
    [SerializeField] private GameObject player;
    [SerializeField] private CameraFollower cameraFollower;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }
    public void RespawnPlayer()
    {

        player.transform.position = new Vector3(0, 1, 0);
    }
}
