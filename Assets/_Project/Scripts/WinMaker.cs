using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMaker : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.RespawnPlayer("Victory", 3f);
            gameObject.SetActive(false);
        }
    }
}
