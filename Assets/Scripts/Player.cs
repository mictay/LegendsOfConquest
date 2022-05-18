using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private int moveSpeed = 7;

    [SerializeField]
    private Rigidbody2D playerRigidBody2D;

    [SerializeField]
    private Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");//;
        float verticalMovement = Input.GetAxisRaw("Vertical"); // * Time.deltaTime;
        playerRigidBody2D.velocity = new Vector2(horizontalMovement, verticalMovement) * moveSpeed;

        //Give the current player velocity values to the animator
        //Note we didn't give it the input values, we used the player's velocity, I suppose
        //     the player could be colliding and we wouldn't be moving even if there is input
        playerAnimator.SetFloat("movementX", playerRigidBody2D.velocity.x);
        playerAnimator.SetFloat("movementY", playerRigidBody2D.velocity.y);

        //if we are walking in any direction, remember this direction.
        if(horizontalMovement == 1 || horizontalMovement == -1 || verticalMovement == 1 || verticalMovement == -1)
        {
            playerAnimator.SetFloat("lastX", horizontalMovement);
            playerAnimator.SetFloat("lastY", verticalMovement);
        }

    }

}
