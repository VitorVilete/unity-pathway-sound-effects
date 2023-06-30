using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private PlayerController playerControllerScript;
    public float speed = 10;
    private float normalSpeed;
    private float dashingSpeed;
    private float leftBound = -15;
    // Start is called before the first frame update
    void Start()
    {
        normalSpeed = speed;
        dashingSpeed = normalSpeed * 1.5f;
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.isGameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }

        if (Input.GetKey(KeyCode.LeftShift) && !playerControllerScript.isGameOver && playerControllerScript.isOnGround)
        {
            speed = dashingSpeed;
        } else if(Input.GetKeyUp(KeyCode.LeftShift) && !playerControllerScript.isGameOver)
        {
            speed = normalSpeed;
        }
    }
}
