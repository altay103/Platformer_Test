using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameObject player;
    [SerializeField] private CameraFollower cameraFollower;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject victoryPoint;
    bool first = true;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            Debug.Log("Hello World");
        }
        else
        {
            Destroy(gameObject);
        }
        SpawnPlayer();

    }


    public void SpawnPlayer()
    {
        if (first)
        {
            first = false;
            player = Instantiate(player, spawnPoint.position, spawnPoint.rotation);
            cameraFollower.target = player.transform;
        }
        else
        {
            player.transform.position = spawnPoint.position;
            player.transform.rotation = spawnPoint.rotation;
        }


        player.GetComponent<MovementController>().enabled = true;
        player.GetComponent<CharacterController>().enabled = true;
        victoryPoint.SetActive(true);
    }
    public void RespawnPlayer(string anim, float deltaTime = 1.8f)
    {
        player.GetComponent<MovementController>().enabled = false;
        player.GetComponent<CharacterController>().enabled = false;
        player.GetComponent<Animator>().SetTrigger(anim);
        StartCoroutine(DelayedSpawn(deltaTime));
    }
    IEnumerator DelayedSpawn(float deltaTime)
    {
        yield return new WaitForSeconds(deltaTime);

        SpawnPlayer();
    }
}
