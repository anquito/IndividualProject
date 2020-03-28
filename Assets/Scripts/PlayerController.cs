using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Vector3 startPosition;
    private GameObject finish;
    private GameObject lava;
    //public Vector3 startPosition = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        playerRb = this.GetComponent<Rigidbody>();
        finish = GameObject.FindGameObjectWithTag("Finish");
        lava = GameObject.FindGameObjectWithTag("Lava");
        startPosition = playerRb.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        // game over if player reaches finish
        if (collision.gameObject.CompareTag("Finish"))
        {
            Debug.Log("Mission Complete!");
        }

        // reset player position if hit by lava
        else if (collision.gameObject.CompareTag("Lava"))
        {
            //resetGame();
            Debug.Log("Game Over!");
        }
    }

    void resetGame()
    {
        playerRb.position = startPosition;
        playerRb.velocity = Vector3.zero;
        playerRb.angularVelocity = Vector3.zero;
    }
}
