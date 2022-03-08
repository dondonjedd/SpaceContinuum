using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    List<Touch> touches;
    private Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        foreach (Touch touch in Input.touches) {
            touches.Add(touch);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            Debug.Log(touchPosition);
            
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);

            Debug.Log(worldPosition);
        }
        
    }
}
