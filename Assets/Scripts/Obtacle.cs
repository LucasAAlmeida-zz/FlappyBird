using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obtacle : MonoBehaviour
{
    [SerializeField] private float speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed, Space.World);

        if (transform.position.z < -2) {
            //Passed successfully
            Destroy(gameObject);
        }
    }
}
