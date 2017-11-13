using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SlimeController : MonoBehaviour {

    public float moveSpeed;

    private Rigidbody2D myRigidBody;

    private bool isMoving;

    public float moveInterval;
    private float moveIntervalCounter;
    public float timeToMove;
    private float timeToMoveCounter;

    private Vector3 moveDirection;


	// Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();

        //Add randomness to slime movement
        moveIntervalCounter = Random.Range(moveInterval * 0.5f, moveInterval * 1.5f);
        timeToMoveCounter = Random.Range(timeToMove * 0.5f, timeToMove * 1.5f);

    }

    // Update is called once per frame
    void Update () {

        if (isMoving)
        {
            timeToMoveCounter -= Time.deltaTime;
            //Velocity = how fast our object is moving
            myRigidBody.velocity = moveDirection;

            if(timeToMoveCounter <= 0f)
            {
                isMoving = false;
                moveIntervalCounter = Random.Range(moveInterval * 0.5f, moveInterval * 1.5f);
            }
        }
        else
        {
            moveIntervalCounter -= Time.deltaTime;
            myRigidBody.velocity = Vector2.zero;

            if(moveIntervalCounter <= 0f)
            {
                isMoving = true;
                timeToMoveCounter = Random.Range(timeToMove * 0.5f, timeToMove * 1.5f);

                moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);
            }
        }

	}
    
}
