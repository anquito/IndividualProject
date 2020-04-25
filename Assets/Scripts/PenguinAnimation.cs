using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinAnimation : MonoBehaviour
{
    private Animator playerAnim;
    private GameManager gameM;
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        gameM = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && gameM.isFinished == false)
        {
            playerAnim.SetTrigger("Jump_trig");
        }

        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) ||
        Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) ||
        Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) ||
        Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.DownArrow)) && gameM.isFinished == false)
        {
            playerAnim.SetInteger("Walk", 1);
        }

        else
        {
            playerAnim.SetInteger("Walk", 0);
        }
    }
}
