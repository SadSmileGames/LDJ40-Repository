using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 20f;
    public float panBorderThickness = 10f;

    public Vector2 panLimitX;
    public Vector2 panLimitY;

    private void LateUpdate()
    {
        MoveCamera();
    }

    private void MoveCamera()
    {
        Vector3 pos = transform.position;

        if(Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            pos.y += panSpeed * Time.deltaTime;
        }

        if (Input.mousePosition.y <=  panBorderThickness)
        {
            pos.y -= panSpeed * Time.deltaTime;
        }

        if (Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.x += panSpeed * Time.deltaTime;
        }

        if (Input.mousePosition.x <= panBorderThickness)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }

        pos.x = Mathf.Clamp(pos.x, panLimitX.x, panLimitX.y);
        pos.y = Mathf.Clamp(pos.y, panLimitY.x, panLimitY.y);

        transform.position = pos;
    }
}
