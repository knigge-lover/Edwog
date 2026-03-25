using System;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    private GameController gameController;

    private void Start()
    {
        gameController = GameObject.Find("GameManager").GetComponent<GameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameControllerLibrary.SetCheckpoint(1, gameController);
        }
    }
}
