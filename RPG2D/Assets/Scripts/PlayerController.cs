using UnityEngine;
using System.Collections;

/**Player Controller Script
 * Contains the basic mechanics to contorl the player: Movement, attacking, animation parameters...
 * */

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
    private float currentMoveSpeed;

    private Animator anim;
    private Rigidbody2D playerRB;

    public bool playerMoving;
    public Vector2 lastMove;
    private Vector2 moveInput;

    private static bool playerExists;

    private bool isAttacking;
    public float attackTime;
    private float attackTimeCounter;

    public string startPoint;

    public bool canMove;

    private SFXManager sfxMan;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        playerRB = GetComponent<Rigidbody2D>();
        sfxMan = FindObjectOfType<SFXManager>();

        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        canMove = true;

        //Initialize the lastMove so the player starts the game with the sword in the right direction
        lastMove = new Vector2(0, -1);
    }
	
	// Update is called once per frame
	void Update () {

        playerMoving = false;
        moveSpeed = 5;

        if (!canMove)
        {
            playerRB.velocity = Vector2.zero;
            return;
        }

        //Moving
        if (!isAttacking)
        {
            /*
            if (Input.GetAxisRaw("Horizontal") > 0f || Input.GetAxisRaw("Horizontal") < 0f)
            {
                playerRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * currentMoveSpeed, playerRB.velocity.y);
                //Save the last movement done
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
                playerMoving = true;
            }

            if (Input.GetAxisRaw("Vertical") > 0f || Input.GetAxisRaw("Vertical") < 0f)
            {
                playerRB.velocity = new Vector2(playerRB.velocity.x, Input.GetAxisRaw("Vertical") * currentMoveSpeed);
                lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
                playerMoving = true;
            }

            if (Input.GetAxisRaw("Horizontal") == 0)
            {
                playerRB.velocity = new Vector2(0f, playerRB.velocity.y);
            }

            if (Input.GetAxisRaw("Vertical") == 0)
            {
                playerRB.velocity = new Vector2(playerRB.velocity.x, 0f);
            }
            */

            //Normalized movement vectors
            moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

            if(moveInput != Vector2.zero)
            {
                playerRB.velocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed);
                playerMoving = true;
                lastMove = moveInput;
            }
            else
            {
                playerRB.velocity = Vector2.zero;
            }

            //Attack prompt
            if (Input.GetKeyDown(KeyCode.X))
            {
                attackTimeCounter = attackTime;
                isAttacking = true;
                playerRB.velocity = Vector2.zero;
                anim.SetBool("PlayerAttacking", true);

                sfxMan.playerAttack.Play();
            }

            /*
             * //Running
            if (Input.GetKey(KeyCode.C))
            {
                    moveSpeed = 10;
            }

            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f && Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f)
            {
                currentMoveSpeed = moveSpeed * diagonalMoveModifier;
            }
            else
            {
                currentMoveSpeed = moveSpeed;
            }
            */

        }

        //Attacking
        if(attackTimeCounter > 0)
        {
            attackTimeCounter -= Time.deltaTime;
        }

        if (attackTimeCounter <= 0)
        {
            isAttacking = false;
            anim.SetBool("PlayerAttacking", false);
        }

        //Set animator parameters
        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);

    }
}
