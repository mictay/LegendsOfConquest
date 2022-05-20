using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{

    private Player playerTarget;
    CinemachineVirtualCamera virtualCamera;

    // Start is called before the first frame update
    void Start()
    {
        //Get the Player
        playerTarget = GameObject.FindObjectOfType<Player>();

        //Get the Specific Component of this GameObject
        virtualCamera = GetComponent<CinemachineVirtualCamera>();

        //Assign the Follow the Player
        virtualCamera.Follow = playerTarget.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
