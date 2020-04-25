using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    private Vector3 startPosition;
    private GameObject finish;
    private GameObject lava;
    public AudioClip lavaSound;
    private AudioSource audioSource;
    //public Vector3 startPosition = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        playerRb = this.GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        finish = GameObject.FindGameObjectWithTag("Finish");
        lava = GameObject.FindGameObjectWithTag("Lava");
        startPosition = playerRb.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        // game over if player reaches finish
        if (collider.gameObject.CompareTag("Finish"))
        {
            Debug.Log("Mission Complete!");
        }

        // reset player position if hit by lava
        else if (collider.gameObject.CompareTag("Lava"))
        {
            //resetGame();
            Debug.Log("Game Over!");
            audioSource.PlayOneShot(lavaSound, 0.75f);
        }

        // alert player if hit by fireball
        else if (collider.gameObject.CompareTag("Fireball"))
        {
            Debug.Log("You've taken damage!");
        }
    }

    void resetGame()
    {
        playerRb.position = startPosition;
        playerRb.velocity = Vector3.zero;
        playerRb.angularVelocity = Vector3.zero;
    }
}
