using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{

    private Player playerTarget;
    CinemachineVirtualCamera virtualCamera;

    private static int counter = 0;

    // Start is called before the first frame update
    void Start()
    {

        CameraController.counter++;
        Debug.Log($"CameraController Start() called {counter}");

        //Get the Player
        //playerTarget = GameObject.FindObjectOfType<Player>();
        playerTarget = Player.instance;

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
