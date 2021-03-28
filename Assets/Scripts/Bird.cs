using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private Rigidbody birdRb;
    [SerializeField] private float jumpForce;
    [SerializeField] private float horizontalSpeed;
    private readonly float verticalRange = 7;
    private readonly float horizontalRange = 10;

    private void Awake()
    {
        birdRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var previousX = transform.position.x;

        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * horizontalSpeed);

        if (transform.position.x > horizontalRange || transform.position.x < -horizontalRange) {
            transform.position = new Vector3(previousX, transform.position.y, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            birdRb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            transform.localEulerAngles = Vector3.left * 135;
        }

        if (transform.position.y > verticalRange) {
            birdRb.AddForce(Vector3.down * jumpForce * 0.1f, ForceMode.Impulse);
            transform.localEulerAngles = Vector3.left * 45;
        } else if (transform.position.y < -verticalRange) {
            birdRb.AddForce(Vector3.up * jumpForce * 0.1f, ForceMode.Impulse);
            transform.localEulerAngles = Vector3.left * 135;
        }

        var previousEulerAngles = transform.localEulerAngles;
        transform.Rotate(Vector3.left * birdRb.velocity.y);
        if (transform.localEulerAngles.x < 225 || transform.localEulerAngles.x > 315) {
            transform.localEulerAngles = previousEulerAngles;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall")) {
            GameHandler.Instance.GameOver();
        }
    }
}
