using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private Rigidbody2D playerRigidBody2D;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");//;
        float verticalMovement = Input.GetAxisRaw("Vertical"); // * Time.deltaTime;
        playerRigidBody2D.velocity = new Vector2(horizontalMovement, verticalMovement);
    }
}
