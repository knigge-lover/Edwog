using System;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    private GameController gameController;
    private Animator animator;
    
    private void Start()
    {
        animator = transform.GetChild(0).gameObject.GetComponent<Animator>();
        gameController = GameObject.Find("GameManager").GetComponent<GameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("Collected", true);
            GameControllerLibrary.SetCheckpoint(1, gameController);
        }
    }
}
