using UnityEngine;
using System.Collections;


/** Camera Controller Script
 * Following the player and staying limited to the boundaries of the map
 * */
public class CameraController : MonoBehaviour {

    public GameObject target;
    private Vector3 targetPos;
    public float moveSpeed;

    private static bool cameraExists;

    public BoxCollider2D boundBox;
    private Vector3 minBounds;
    private Vector3 maxBounds;

    //reference to camera compenent to get the orthographic size
    private Camera cam;
    private float halfHeight;
    private float halfWidth;

    // Use this for initialization
    void Start () {
        if (!cameraExists)
        {
            cameraExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        if (boundBox = null)
        {
            boundBox = FindObjectOfType<Bounds>().GetComponent<BoxCollider2D>();
            minBounds = boundBox.bounds.min;
            maxBounds = boundBox.bounds.max;
        }

        cam = GetComponent<Camera>();
        //The orthographic size is half the height of the camera
        halfHeight = cam.orthographicSize;

        halfWidth = halfHeight * Screen.width / Screen.height;

    }

    // Update is called once per frame
    void Update () {
        targetPos = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);

        if(boundBox = null)
        {
            boundBox = FindObjectOfType<Bounds>().GetComponent<BoxCollider2D>();
            minBounds = boundBox.bounds.min;
            maxBounds = boundBox.bounds.max;
        }

        float clampedX = Mathf.Clamp(transform.position.x, minBounds.x + halfWidth, maxBounds.x - halfWidth);
        float clampedY = Mathf.Clamp(transform.position.y, minBounds.y + halfHeight, maxBounds.y - halfHeight);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }

    public void setBounds(BoxCollider2D newBounds)
    {
        boundBox = newBounds;

        minBounds = boundBox.bounds.min;
        maxBounds = boundBox.bounds.max;
    }
}
