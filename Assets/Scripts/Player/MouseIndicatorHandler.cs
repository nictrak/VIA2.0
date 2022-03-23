using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseIndicatorHandler : MonoBehaviour
{

    // private Sprite spriteRender;
    public Camera camera;
    // Buffer field from PlayerMoveController
    private Vector2 centerMousePosition;
    
    // Start is called before the first frame update
    void Start()
    {
        centerMousePosition = new Vector2(Screen.width / 2, Screen.height / 2);
    }

    // Update is called once per frame
    void Update()
    {
        // Buffer field from PlayerMoveController
        Vector2 mouseCursorPosition = ((Vector2)Input.mousePosition - centerMousePosition).normalized;
        Vector2 direction = GetInputMoveDirection(mouseCursorPosition);
        Quaternion target = Quaternion.Euler(0, 0, CalAngle(direction));
        transform.rotation = target;
        Vector3 positionSprite = camera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(positionSprite.x,positionSprite.y,0);
    }

    // Buffer field from PlayerMoveController
    private float CalAngle(Vector2 direction)
    {
        float res = Vector2.Angle(direction, new Vector2(0, -1));
        if(direction.x < 0)
        {
            res = res * -1;
        }
        return res;
    }
    // Buffer field from PlayerMoveController
    private Vector2 GetInputMoveDirection(Vector2 directionMouse)
    {
        Vector2 res = new Vector2(directionMouse.x * Mathf.Pow(3, 0.5f), directionMouse.y);
        return res.normalized;
    }
}



