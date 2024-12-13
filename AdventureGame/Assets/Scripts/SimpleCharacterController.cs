using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCharacterController : MonoBehaviour
{
    private Rigidbody2D body;
    public float moveSpeed = 10f;
    public float jumpForce = 8f;
    public float gravity = -9.81f;
    private Vector2 velocity;
    private Transform thisTransform;
    private Vector2 movementVector = Vector2.zero;
    public float jumpHeight = 5f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        thisTransform = transform;
    }

    void Update()
    {
        MoveCharacter();
        KeepCharacterOnXAxis();
    }

    private void MoveCharacter()
    {
        body.velocity = new Vector2(Input.GetAxis("Horizontal"), body.velocity.y);
        if (Input.GetButtonDown("Jump"))
            Jumping();
    }

    private void KeepCharacterOnXAxis()
    {
        var currentPosition = thisTransform.position;
        currentPosition.z = 0f;
        thisTransform.position = currentPosition;
    }

    private void Jumping()
    {
        body.velocity = new Vector2(body.velocity.x, jumpHeight);
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }
}
