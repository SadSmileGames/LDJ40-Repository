using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMotor2D : RaycastController2D
{
    // A reference to the struct which contains all the information about the collision state of the CC2D
    public ControllerState2D state;

    public void Move(Vector2 moveAmount)
    {
        UpdateRaycastOrigins();
        state.Reset();

        HorizontalCollisions(ref moveAmount);
        VerticalCollisions(ref moveAmount);

        transform.Translate(moveAmount);
    }

    private void HorizontalCollisions(ref Vector2 moveAmount)
    {
        float directionX = Mathf.Sign(moveAmount.x);
        float rayLenght = Mathf.Abs(moveAmount.x) + skinWidth;

        if (Mathf.Abs(moveAmount.x) < skinWidth)
        {
            rayLenght = 2 * skinWidth;
        }

        // This loop cast all of the rays and does the constrain thingy
        for (int i = 0; i < horizontalRayCount; i++)
        {
            // If: directionX == 1 -> Cast from the right side of the BC2D
            // If: directionX == -1 -> Cast from the left side of the BC2D
            Vector2 rayOrigin = (directionX == -1) ? raycastOrigins.bottomLeft : raycastOrigins.bottomRight;
            rayOrigin += Vector2.up * (horizontalRaySpacing * i);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * directionX, rayLenght, collisionMask);

            // Moves to the next ray if nothing was hit
            if (!hit)
                continue;

            // If standing directly at a wall, it will move to the next ray.
            if (hit.distance == 0)
                continue;

            // This is actually constrains the possible moveAmount. This prevents clipping
            moveAmount.x = (hit.distance - skinWidth) * directionX;
            // Sets the lenght of the ray to the distance of the hit. This is important if the colliders are stacked like stairs for example
            rayLenght = hit.distance;

            //Sets the state of the CharacterController2D
            state.IsCollidingLeft = directionX == -1;
            state.IsCollidingRight = directionX == 1;
        }
    }

    private void VerticalCollisions(ref Vector2 moveAmount)
    {
        float directionY = Mathf.Sign(moveAmount.y);
        float rayLenght = Mathf.Abs(moveAmount.y) + skinWidth;

        for (int i = 0; i < verticalRayCount; i++)
        {
            Vector2 rayOrigin = (directionY == -1) ? raycastOrigins.bottomLeft : raycastOrigins.topLeft;
            rayOrigin += Vector2.right * (verticalRaySpacing * i + moveAmount.x);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up * directionY, rayLenght, collisionMask);

            if (!hit)
                continue;

            moveAmount.y = (hit.distance - skinWidth) * directionY;
            rayLenght = hit.distance;

            state.IsCollidingBelow = directionY == -1;
            state.IsCollidingAbove = directionY == 1;
        }
    }
}
