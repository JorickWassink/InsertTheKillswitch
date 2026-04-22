using System;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static Action<Vector2> PlaceTower;

    public void RunPlaceTower(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPos.z = 0f; // important for 2D
            PlaceTower?.Invoke(worldPos);
        }
    }
}
