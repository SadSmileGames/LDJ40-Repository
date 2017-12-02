using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMotor2D))]
public class PlayerController : MonoBehaviour
{
    //The movement speed of the player
    public float moveSpeed = 5f;

    //The motor of the player
    private CharacterMotor2D motor;

    private void Awake()
    {
        motor = GetComponent<CharacterMotor2D>();
    }

    private void Update()
    {
        motor.Move(CalculateMoveAmount());
    }

    private Vector2 CalculateMoveAmount()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 moveAmount = new Vector2(horizontal, vertical).normalized * moveSpeed * Time.deltaTime;

        return moveAmount;
    }
}
