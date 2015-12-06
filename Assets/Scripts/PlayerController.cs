using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    //Player States
    private enum PlayerDirection { UP, DOWN, LEFT, RIGHT };

    private enum PlayerState { ATTACKING, IDLE, MOVING, DEAD };

    //Components
    private Transform playerTransform;
    private Animator playerAnimator;
    
    //Player Properties
    public float playerSpeed;
    private PlayerDirection currentDirection;
    private PlayerState currentPState;
    private Vector2 playerVelocity;

	// Use this for initialization
	void Start () {
        currentDirection = PlayerDirection.DOWN;
        currentPState = PlayerState.IDLE;
        playerTransform = GetComponent<Transform>();
        playerVelocity = new Vector2(0,0);
        playerAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        float dt = Time.deltaTime;
        Vector3 theScale = playerTransform.localScale;
        //Handle controls
        Controls(dt);

        if(currentDirection == PlayerDirection.UP)
        {
            playerAnimator.SetBool("IsUp", true);
            playerAnimator.SetBool("IsHorizontal", false);
            if (currentPState == PlayerState.MOVING)
            {
                playerAnimator.SetBool("IsMoving", true);
            } else
            {
                playerAnimator.SetBool("IsMoving", false);
            }
        } else if(currentDirection == PlayerDirection.DOWN)
        {
            playerAnimator.SetBool("IsUp", false);
            playerAnimator.SetBool("IsHorizontal", false);
            if (currentPState == PlayerState.MOVING)
            {
                playerAnimator.SetBool("IsMoving", true);
            }
            else
            {
                playerAnimator.SetBool("IsMoving", false);
            }
        }

        if(currentDirection == PlayerDirection.RIGHT)
        {
            playerAnimator.SetBool("IsHorizontal", true);
            theScale.x *= -1;
            playerTransform.localScale = theScale;
            if (currentPState == PlayerState.MOVING)
            {
                playerAnimator.SetBool("IsMoving", true);
            }
            else
            {
                playerAnimator.SetBool("IsMoving", false);
            }
        } else if(currentDirection == PlayerDirection.LEFT)
        {
            playerAnimator.SetBool("IsHorizontal", true);
            //Flip the animations
            theScale.x *= -1;
            playerTransform.localScale = theScale;
            if (currentPState == PlayerState.MOVING)
            {
                playerAnimator.SetBool("IsMoving", true);
            }
            else
            {
                playerAnimator.SetBool("IsMoving", false);
            }
        }
        
    }

    void Controls(float dt)
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            //Move player up and change states
            currentDirection = PlayerDirection.UP;
            currentPState = PlayerState.MOVING;
            playerTransform.Translate(Vector2.up * playerSpeed * dt);
        }
        else if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            //Move player down and change states
            currentDirection = PlayerDirection.DOWN;
            currentPState = PlayerState.MOVING;
            playerTransform.Translate(Vector2.down * playerSpeed * dt);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            //Move player left and change states
            currentDirection = PlayerDirection.LEFT;
            currentPState = PlayerState.MOVING;
            playerTransform.Translate(Vector2.left * playerSpeed * dt);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            //Move player right and chnage states
            currentDirection = PlayerDirection.RIGHT;
            currentPState = PlayerState.MOVING;
            playerTransform.Translate(Vector2.right * playerSpeed * dt);
        }
        else
        {
            //IF none is true then we are not moving
            currentPState = PlayerState.IDLE;
        }
    }
}
