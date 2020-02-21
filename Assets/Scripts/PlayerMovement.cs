using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float verticalSpeed = 20;
    public float horizontalSpeed = 20;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * verticalSpeed * verticalInput);

        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * horizontalSpeed * horizontalInput);

        if (Input.GetKeyDown("space"))
        {
            transform.Translate(0,4,0);
        }

        //if (Input.GetKey ("space"))
        //{
            //transform.Translate(Vector3.up * Time.deltaTime * speed);
        //}

        //if (Input.GetKey("c"))
        //{
            //transform.Translate(Vector3.down * Time.deltaTime * speed);
        //}
    }
}
