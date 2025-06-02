using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trooper : MonoBehaviour
{
    public float speed;
    public float offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed;
        if (Input.GetKey(KeyCode.W))
            speed = 0.1f;

        RaycastHit hit;
        Ray ray = new Ray(transform.position + Vector3.up * 5, Vector3.down);
        int layer = 1 << LayerMask.NameToLayer("Floor");

        if(Physics.Raycast(ray, out hit, layer))
        {
            transform.position = hit.point+Vector3.up*offset;
                }

    }

    
}
