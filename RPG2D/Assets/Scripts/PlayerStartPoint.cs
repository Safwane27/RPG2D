using UnityEngine;
using System.Collections;

public class PlayerStartPoint : MonoBehaviour
{

    private PlayerController thePlayer;
    private CameraController theCamera;

    public Vector2 startDirection;

    public string pointName;

    // Use this for initialization
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();

        if (thePlayer.startPoint == pointName)
        {


            thePlayer.transform.position = transform.position; //ThePlayer takes the position of our start point
            thePlayer.lastMove = startDirection;

            theCamera = FindObjectOfType<CameraController>();
            theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z); // To not change the z position

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
