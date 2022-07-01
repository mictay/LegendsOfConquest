using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{

    public static Player instance { get; private set; }

    public int instanceNumber = 0;
    private float playerPositionBoxDetectionSize = 1.5f;

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

    private static int counter = 0;

    private bool deactivatedMovement = false;

    private void Awake()
    {
        Debug.Log("Player Awake() called");

        if (instance != null && instance != this) { 
            Debug.Log("Player Awake() destory this");
            Destroy(this.gameObject);
        }
        else
        {
            Debug.Log("Player Awake() create instance from this");
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Player Start() called");
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {

        if (this.deactivatedMovement)
        {
            playerRigidBody2D.velocity = Vector2.zero;
            playerAnimator.SetFloat("movementX", 0);
            playerAnimator.SetFloat("movementY", 0);
            return;
        }

        float horizontalMovement = getInputHorizontalRaw(); //Input.GetAxisRaw("Horizontal");//;
        float verticalMovement = getInputVerticalRaw(); //Input.GetAxisRaw("Vertical"); // * Time.deltaTime;

        playerRigidBody2D.velocity = new Vector2(horizontalMovement, verticalMovement) * moveSpeed;

        //Give the current player velocity values to the animator
        //Note we didn't give it the input values, we used the player's velocity, I suppose
        //     the player could be colliding and we wouldn't be moving even if there is input
        playerAnimator.SetFloat("movementX", playerRigidBody2D.velocity.x);
        playerAnimator.SetFloat("movementY", playerRigidBody2D.velocity.y);

        //if we are walking in any direction, remember this direction.
        if (horizontalMovement == 1 || horizontalMovement == -1 || verticalMovement == 1 || verticalMovement == -1)
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

    public void SetLimit(Vector3 bottomLeftEdgeToSet, Vector3 topRightEdgeToSet)
    {

        Debug.Log($"Player SetLimit() called {counter} for Player {instanceNumber} setting bounds {bottomLeftEdgeToSet}, {topRightEdgeToSet}");

        this.bottomLeftEdge = bottomLeftEdgeToSet;
        this.topRightEdge = topRightEdgeToSet;
    }

    public void SetDeactivatedMovement(bool deactivatedMovement)
    {
        this.deactivatedMovement = deactivatedMovement;
    }

    public bool isDeactivatedMovement()
    {
        return this.deactivatedMovement;
    }

    private float getInputHorizontalRaw()
    {
        Vector3 pointerWorldPosition = Vector3.zero;

        bool mouseButtonPressed = Input.GetMouseButton(0);

        if (mouseButtonPressed)
            pointerWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.touchCount > 0)
        {
            Touch touchPressed = Input.GetTouch(0);

            if (touchPressed.pressure > 0)
                pointerWorldPosition = Camera.main.ScreenToWorldPoint(touchPressed.position);
        }

        if (pointerWorldPosition != Vector3.zero)
        {
            //Debug.Log("getInputHorizontalRaw w:" + pointerWorldPosition.x + " compared p:" + playerRigidBody2D.position.x);

            if (pointerWorldPosition.x < playerRigidBody2D.position.x && !IsWithinPlayerHorizontalBox(pointerWorldPosition))
                return -1;
            else if (pointerWorldPosition.x > playerRigidBody2D.position.x && !IsWithinPlayerHorizontalBox(pointerWorldPosition))
                return 1;
            else return 0;
        }

        return Input.GetAxisRaw("Horizontal"); ;
    }

    private float getInputVerticalRaw()
    {
        Vector3 pointerWorldPosition = Vector3.zero;

        bool mouseButtonPressed = Input.GetMouseButton(0);
        
        if(mouseButtonPressed)
            pointerWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(Input.touchCount > 0)
        {
            Touch touchPressed = Input.GetTouch(0);

            if (touchPressed.pressure > 0)
                pointerWorldPosition = Camera.main.ScreenToWorldPoint(touchPressed.position);
        }

        if (pointerWorldPosition != Vector3.zero)
        {
            //Debug.Log("getInputVerticalRaw w:" + pointerWorldPosition.y + " compared p:" + playerRigidBody2D.position.y);

            if (pointerWorldPosition.y < playerRigidBody2D.position.y && !IsWithinPlayerVerticalBox(pointerWorldPosition))
                return -1;
            else if (pointerWorldPosition.y > playerRigidBody2D.position.y && !IsWithinPlayerVerticalBox(pointerWorldPosition))
                return 1;
            else return 0;
        }

        return Input.GetAxisRaw("Vertical");
    }

    private bool IsWithinPlayerVerticalBox(Vector3 pointerWorldPosition)
    {

        bool ret = false;

        if (playerPositionBoxDetectionSize > Mathf.Abs(pointerWorldPosition.y - playerRigidBody2D.position.y))
        {
            ret = true;
        }
/*        Debug.Log("IsWithinPlayerVerticalBox is " + ret 
            + " wY: " + pointerWorldPosition.y
            + " pY:" + playerRigidBody2D.position.y
            + " abs: " + Mathf.Abs(playerRigidBody2D.position.y - pointerWorldPosition.y));*/

        return ret;
    }

    private bool IsWithinPlayerHorizontalBox(Vector3 pointerWorldPosition)
    {
        bool ret = false;

        if (playerPositionBoxDetectionSize > Mathf.Abs(pointerWorldPosition.x - playerRigidBody2D.position.x))
        {
            ret = true;
        }

/*        Debug.Log("IsWithinPlayerHorizontalBox is " + ret
            + " wX: " + pointerWorldPosition.x
            + " pX:" + playerRigidBody2D.position.x
            + " abs: " + Mathf.Abs(playerRigidBody2D.position.x - pointerWorldPosition.x));*/

        return ret;
    }

}
