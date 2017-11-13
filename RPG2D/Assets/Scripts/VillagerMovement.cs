using UnityEngine;
using System.Collections;

/**
 * 
 * Script to make the villager move randomly in a certain area
 * 
 **/

public class VillagerMovement : MonoBehaviour {

    public float moveSpeed;
    private Vector2 minWalkPoint;
    private Vector2 maxWalkPoint;

    private Rigidbody2D rb;

    public bool isWalking;
    public float walkTimer;
    private float walkCounter;
    public float idleTimer;
    private float idleCounter;

    private int walkDirection;

    public BoxCollider2D walkArea;
    private bool hasWalkZone;

    public bool canMove;

    private DialogueManager dMan;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        dMan = FindObjectOfType<DialogueManager>();

        walkCounter = walkTimer;
        idleCounter = idleTimer;

        ChooseDirection();
        if(walkArea != null)
        {
            hasWalkZone = true;
            minWalkPoint = walkArea.bounds.min;
            maxWalkPoint = walkArea.bounds.max;
        }

        canMove = true;

	}
	
	// Update is called once per frame
	void Update () {

        if (!dMan.dActive)
        {
            canMove = true;
        }

        if (!canMove)
        {
            rb.velocity = Vector2.zero;
            return; //To exit the update loop
        }
	    if(isWalking == true)
        {
            walkCounter -= Time.deltaTime;

            switch (walkDirection)
            {
                case 0:
                    rb.velocity = new Vector2(0, moveSpeed);
                    if (hasWalkZone && transform.position.y > maxWalkPoint.y)
                    {
                        isWalking = false;
                        idleCounter = idleTimer;
                    }
                    break;
                case 1:
                    rb.velocity = new Vector2(moveSpeed, 0);
                    if (hasWalkZone && transform.position.x > maxWalkPoint.x)
                    {
                        isWalking = false;
                        idleCounter = idleTimer;
                    }
                    break;
                case 2:
                    rb.velocity = new Vector2(0, -moveSpeed);
                    if (hasWalkZone && transform.position.y < minWalkPoint.y)
                    {
                        isWalking = false;
                        idleCounter = idleTimer;
                    }
                    break;
                case 3:
                    rb.velocity = new Vector2(-moveSpeed, 0);
                    if (hasWalkZone && transform.position.x < minWalkPoint.x)
                    {
                        isWalking = false;
                        idleCounter = idleTimer;
                    }
                    break;
            }

            if (walkCounter < 0)
            {
                isWalking = false;
                idleCounter = idleTimer;
            }
        }
        else
        {
            idleCounter -= Time.deltaTime;
            rb.velocity = Vector2.zero;
            if (idleCounter < 0)
            {
                ChooseDirection();
            }
        }
	}

    public void ChooseDirection()
    {
        walkDirection = Random.Range(0, 4);
        isWalking = true;
        walkCounter = walkTimer;
    }
}
