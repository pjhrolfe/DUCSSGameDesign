using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDirection = Vector2.zero;
        
        if (Input.GetKey(KeyCode.W))
        {
            moveDirection.y = 3;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveDirection.y = -1;
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection.x = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveDirection.x = 1;
        }
        
        transform.Translate(moveDirection * (movementSpeed * Time.deltaTime));
    }
}
