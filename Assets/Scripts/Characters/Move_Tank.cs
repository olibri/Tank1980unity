using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class Move_Tank : MonoBehaviour
{

    [SerializeField] private Rigidbody rb;
    [SerializeField] private float rotationSpeed = 100f; 

    [SerializeField] private float speed = 5f;
    [SerializeField] private FixedJoystick joystick;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called one per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(joystick.Horizontal, 0f, joystick.Vertical).normalized;
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            rb.rotation = Quaternion.RotateTowards(rb.rotation, toRotation, rotationSpeed * Time.fixedDeltaTime);
        }
       
    }
}
