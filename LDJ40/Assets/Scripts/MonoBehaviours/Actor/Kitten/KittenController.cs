using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMotor2D))]
public class KittenController : MonoBehaviour
{
    public float moveSpeed;

    public KittenMovementState state;
    public Vector2 timeToWaitBetweenMoves;
    public Vector2 timeToMove;

    private float timeToWaitBetweenMovesCounter;
    private float timeToMoveCounter;

    private Vector2 moveDirection;
    private Vector2 moveAmount;

    //The motor of the kitten
    private CharacterMotor2D motor;

    private void Awake()
    {
        motor = GetComponent<CharacterMotor2D>();
    }

    private void Start()
    {
        timeToWaitBetweenMovesCounter = Random.Range(timeToWaitBetweenMoves.x, timeToWaitBetweenMoves.y);
        timeToMoveCounter = Random.Range(timeToMove.x, timeToMove.y);

        state = new KittenMovementState();
    }

    private void Update()
    {
        if(state.IsMoving)
        {
            MoveKitten();
        }
        else
        {
            WaitForNextMovement();
        }
    }

    private void WaitForNextMovement()
    {
        timeToWaitBetweenMovesCounter -= Time.deltaTime;
        if(timeToWaitBetweenMovesCounter < 0f)
        {
            timeToMoveCounter = Random.Range(timeToMove.x, timeToMove.y);
            moveDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            moveAmount = moveDirection.normalized * moveSpeed * Time.deltaTime;

            state.IsMoving = true;
        }
    }

    private void MoveKitten()
    {
        timeToMoveCounter -= Time.deltaTime;

        if (motor.state.IsColliding)
            moveAmount = -moveAmount;

        motor.Move(moveAmount);

        if (timeToMoveCounter < 0f)
        {
            state.IsMoving = false;
            timeToWaitBetweenMovesCounter = Random.Range(timeToWaitBetweenMoves.x, timeToWaitBetweenMoves.y);
        }
    }

    public struct KittenMovementState
    {
        public bool IsMoving { get; set; }
        public bool IsBeingCarried { get; set; }
    }

}
