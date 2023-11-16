using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;
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
            moveDirection.y = 1;
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
        
        transform.Translate(moveDirection * (movementSpeed * Time.deltaTime), Space.World);
        
        // transform.Rotate(new Vector3(0, 0, 100 * Time.deltaTime));

        Vector2 mousePosition = Input.mousePosition;
        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 newDirection = mouseWorldPosition - new Vector2(transform.position.x, transform.position.y);
        newDirection.Normalize();

        float newAngle = Mathf.Atan2(newDirection.y, newDirection.x) * Mathf.Rad2Deg;

        transform.eulerAngles = new Vector3(0.0f, 0.0f, newAngle);

        if (Input.GetMouseButtonDown(0))
        {
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0.0f, 0.0f, transform.eulerAngles.z));
    }
}
