using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMotor2D))]
public class PlayerController : MonoBehaviour
{
    //The motor of the player
    private CharacterMotor2D motor;

    //The movement speed of the player
    public float moveSpeed = 5f;

    private void Awake()
    {
        motor = GetComponent<CharacterMotor2D>();
    }

    private void Update()
    {
        motor.Move(CalculateVelocity());
    }

    private Vector2 CalculateVelocity()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 velocity = new Vector2(horizontal, vertical).normalized * moveSpeed * Time.deltaTime;

        return velocity;
    }
}
