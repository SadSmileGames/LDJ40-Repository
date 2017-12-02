using UnityEngine;
using System.Collections;

// This is the script which is responsible for calculating the position of the rays that
// other scripts need for collision detection.
// This script only works with a BoxCollider2D so it requires this component. Do NOT remove it.
[RequireComponent(typeof(BoxCollider2D))]
public abstract class RaycastController2D : MonoBehaviour
{
    // This is the amount the rayOrigins are indented. It is needed to prevent clipping through corners
    public const float skinWidth = 0.02f;

    // The mask that is used for collisions. It should NEVER be the same LayerMask the object is on
    public LayerMask collisionMask;

    [Tooltip("The amount of rays that are cast in the horizontal direction. That means they are stocked ontop of each other!")]
    [Range(2, 20)]
    public int horizontalRayCount = 8;

    [Tooltip("The amount of rays that are cast in the vertical direction. That means they are next to each other!")]
    [Range(2, 20)]
    public int verticalRayCount = 4;

    // The space between the rays that guarantee an equal distance from eachother. 
    [HideInInspector]
    public float horizontalRaySpacing;
    [HideInInspector]
    public float verticalRaySpacing;

    // A reference to the BoxCollider2D
    [HideInInspector]
    public new BoxCollider2D collider2D;
    // A reference to the struct which contains all the transforms of the rayOrigins 
    [HideInInspector]
    public RaycastOrigins raycastOrigins;

    public virtual void Awake()
    {
        collider2D = GetComponent<BoxCollider2D>();
    }

    public virtual void Start()
    {
        CalculateRaySpacing();
    }

    //A method which updates the position of the Vector2s that represent the origins of the raycasts
    public void UpdateRaycastOrigins()
    {
        Bounds bounds = GetBounds();

        raycastOrigins.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
        raycastOrigins.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
        raycastOrigins.topLeft = new Vector2(bounds.min.x, bounds.max.y);
        raycastOrigins.topRight = new Vector2(bounds.max.x, bounds.max.y);
    }

    //A method that calculates the distance between the rays
    public void CalculateRaySpacing()
    {
        Bounds bounds = GetBounds();

        horizontalRaySpacing = bounds.size.y / (horizontalRayCount - 1);
        verticalRaySpacing = bounds.size.x / (verticalRayCount - 1);
    }

    //A Method that returns the bounds of the BoxCollider2D - the skinWidth on all sides
    public Bounds GetBounds()
    {
        Bounds bounds = collider2D.bounds;
        bounds.Expand(skinWidth * -2);

        return bounds;
    }

    //A Struct which contains all the corners of the BoxCollider2D Component which will be used as start points for the raycast
    public struct RaycastOrigins
    {
        public Vector2
            topLeft,
            topRight,
            bottomLeft,
            bottomRight;
    }
}
