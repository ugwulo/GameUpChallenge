using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRb;
    public float bounceForce = 6;

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        audioManager.Play("bounce");
        playerRb.velocity = new Vector3(playerRb.velocity.x, bounceForce, playerRb.velocity.z);
        string materialName = collision.transform.GetComponent<MeshRenderer>().material.name;

        if(materialName == "Safe (Instance)")
        {
             
        }
        else if(materialName == "Unsafe (Instance)")
        {
            GameManager.isGameOver = true;
            audioManager.Play("game over");
        }

        else if (materialName == "Last Ring (Instance)" && !GameManager.isLevelCompleted)
        {
            GameManager.isLevelCompleted = true;
            audioManager.Play("win level");
        }
    }
}
