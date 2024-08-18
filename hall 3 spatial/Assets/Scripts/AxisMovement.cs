using System;
using Unity.VisualScripting;
using UnityEngine;

public class AxisMovement : MonoBehaviour
{
    public float speed = 5f;
    public float minStart = 0f;
    public float maxEnd = 10f;
    public bool axisX = true;
    public bool axisY = false;
    public bool axisZ = false;
    private bool isLimiter = false;

   // private FootstepManager footstepManager;

    void Start()
    {
        // footstepManager = GetComponent<FootstepManager>();
        // if (footstepManager == null)
        // {
        //     Debug.LogError("FootstepManager component is missing!");
        // }
    }

    private void Update()
    {
        if((Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) && !isLimiter )
        {
           // footstepManager.PlayFootstep();
        }
    }

    void FixedUpdate()
    {
        float moveInputVertical = Input.GetAxis("Vertical");
        float moveInputHorizontal = Input.GetAxis("Horizontal");
        float newPosition = GetNewPosition(moveInputVertical, moveInputHorizontal);
        if (newPosition < minStart || newPosition > maxEnd)
        {
            isLimiter = true;
        }
        else
        {
            isLimiter = false;
        }
        newPosition = ClampPosition(newPosition);
        SetNewPosition(newPosition);
    }

    float GetNewPosition(float inputVertical, float inputHorizontal)
    {
        float moveInput = inputVertical + inputHorizontal;

        if (axisX)
            return transform.position.x + moveInput * speed * Time.fixedDeltaTime;
        else if (axisY)
            return transform.position.y + moveInput * speed * Time.fixedDeltaTime;
        else if (axisZ)
            return transform.position.z + moveInput * speed * Time.fixedDeltaTime;

        return transform.position.y; // Default to Y-axis if none is selected
    }

    float ClampPosition(float position)
    {
        return Mathf.Clamp(position, minStart, maxEnd);
    }

    void SetNewPosition(float newPosition)
    {
        if (axisX)
            transform.position = new Vector3(newPosition, transform.position.y, transform.position.z);
        else if (axisY)
            transform.position = new Vector3(transform.position.x, newPosition, transform.position.z);
        else if (axisZ)
            transform.position = new Vector3(transform.position.x, transform.position.y, newPosition);
    }
}
