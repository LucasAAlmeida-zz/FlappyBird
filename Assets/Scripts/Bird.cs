using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private Rigidbody birdRb;
    [SerializeField] private float jumpForce;
    [SerializeField] private float horizontalSpeed;

    private void Awake()
    {
        birdRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * horizontalSpeed);

        if (Input.GetKeyDown(KeyCode.Space)) {
            birdRb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            transform.localEulerAngles = Vector3.left * 135;
        }

        var previousEulerAngles = transform.localEulerAngles;
        transform.Rotate(Vector3.left * birdRb.velocity.y);
        if (transform.localEulerAngles.x < 225 || transform.localEulerAngles.x > 315) {
            transform.localEulerAngles = previousEulerAngles;
        }

    }
}
