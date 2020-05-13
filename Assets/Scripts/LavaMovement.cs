using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaMovement : MonoBehaviour
{
    private float speed = 1.0f;
    private GameManager gameManager;
    private PlayerController playerController;
    private float topBoundary = 14;
    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        startPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isFinished == false && gameManager.fpsController.enabled == true 
            && playerController.hasPowerUp == false && transform.position.y < topBoundary)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }

        else if (gameManager.isFinished == true && gameManager.fpsController.enabled == false)
        {
            transform.position = startPosition;
        }
    }
}
