using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    private GameController gameController;
    private Animator animator;
    private CheckpointMaterials checkpointMaterials;
    
    [SerializeField] private Material currentMaterial;
    [SerializeField] private int index;
    [SerializeField] private MeshRenderer[] meshRenderers;
    [SerializeField] private float checkpointIndex;
    
    private void Start()
    {
        checkpointMaterials = transform.parent.GetComponent<CheckpointMaterials>();
        animator = transform.GetChild(0).gameObject.GetComponent<Animator>();
        gameController = GameObject.Find("GameManager").GetComponent<GameController>();
        
        currentMaterial = checkpointMaterials.glowRed;
        SetMat(currentMaterial, meshRenderers);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("Collected", true);
            currentMaterial = checkpointMaterials.glowGreen;
            SetMat(currentMaterial, meshRenderers);
            GameControllerLibrary.SetCheckpoint(1, gameObject, gameController);
        }
    }

    private void SetMat(Material mat, MeshRenderer[] mrs)
    {
        List<Material> mats = new List<Material> { mat };
        for (int i = 0; i < mrs.Length; i++)
        {
            mrs[i].materials =  mats.ToArray();
        }
    }
}
