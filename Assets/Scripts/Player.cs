using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{

    public static Player instance;

    [SerializeField] 
    public string entranceAreaName;

    [SerializeField]
    private int moveSpeed = 7;

    [SerializeField]
    private Rigidbody2D playerRigidBody2D;

    [SerializeField]
    private Animator playerAnimator;

    private Vector3 bottomLeftEdge;
    private Vector3 topRightEdge;

    [SerializeField]
    private Tilemap tileMap;

    // Start is called before the first frame update
    void Start()
    {

        //Destroy other instances of a Player
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        } else
        {
            instance = this;
        }

        //Keep this player instance when loading new scenes
        DontDestroyOnLoad(playerAnimator);

        bottomLeftEdge = tileMap.localBounds.min + new Vector3(0.5f, 1f, 0);
        topRightEdge = tileMap.localBounds.max + new Vector3(-0.5f, -1f, 0);
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

        //Keep the Player within the map
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, bottomLeftEdge.x, topRightEdge.x),
            Mathf.Clamp(transform.position.y, bottomLeftEdge.y, topRightEdge.y),
            Mathf.Clamp(transform.position.z, bottomLeftEdge.z, topRightEdge.z)
        );

    }

}
