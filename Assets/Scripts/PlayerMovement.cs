using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    List<Touch> touches;
    [SerializeField] private float forceMagnitude;
    [SerializeField] private float maxVelocity;

    private Camera mainCamera;
    private Rigidbody rb;
    private Vector3 movementDirection;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody>();
        foreach (Touch touch in Input.touches) {
            touches.Add(touch);
        }


    }

    // Update is called once per frame
    void Update()
    {
        inputHandler();
        keepPlayerInScreen();
        
    }

    private void FixedUpdate()
    {
        if (movementDirection == Vector3.zero) { return; }
        else {
            rb.AddForce(movementDirection*forceMagnitude*Time.deltaTime, ForceMode.Force);
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
            
        }
    }


    private void inputHandler() {
        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();

            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);

            movementDirection = transform.position - worldPosition;
            movementDirection.z = 0f;
            movementDirection.Normalize();
        }
        else
        {
            movementDirection = Vector3.zero;
        }
    }

    private void keepPlayerInScreen() {

        Vector3 viewPortPosition = mainCamera.WorldToViewportPoint(transform.position);

        if (viewPortPosition.x > 1) {
            viewPortPosition.x = 0;
            transform.position = mainCamera.ViewportToWorldPoint(viewPortPosition);
        }
        else if (viewPortPosition.x < 0)
        {
            viewPortPosition.x = 1;
            transform.position = mainCamera.ViewportToWorldPoint(viewPortPosition);
        }

        if (viewPortPosition.y > 1)
        {
            viewPortPosition.y = 0;
            transform.position = mainCamera.ViewportToWorldPoint(viewPortPosition);
        }
        else if (viewPortPosition.y < 0)
        {
            viewPortPosition.y = 1;
            transform.position = mainCamera.ViewportToWorldPoint(viewPortPosition);
        }

        

    }
}
