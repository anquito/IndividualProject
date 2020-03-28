using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFireball : MonoBehaviour
{
    private Rigidbody fireballRb;
    private float topLimit = 39.0f;
    // Start is called before the first frame update
    void Start()
    {
        fireballRb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > topLimit)
        {
            Destroy(gameObject);
            Destroy(fireballRb);
        }
    }
}
