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

        if (transform.position.z < 10) {
            var child0 = transform.GetChild(0);
            var child1 = transform.GetChild(1);

            List<Transform> children = new List<Transform>();
            children.Add(child0.GetChild(0));
            children.Add(child0.GetChild(1));
            children.Add(child1.GetChild(0));
            children.Add(child1.GetChild(1));
            
            foreach(var child in children) {
                Renderer r = child.GetComponent<Renderer>();
                Color materialColor = r.material.color;
                r.material.color = new Color(materialColor.r, materialColor.g, materialColor.b, 0.5f);
            }




        }
    }
}
