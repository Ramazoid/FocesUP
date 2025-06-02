using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToFloor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;
        int layer = 1<<LayerMask.NameToLayer("Ground");
        if(Physics.Raycast(ray, out hit,float.PositiveInfinity, layer))
        {
            transform.position = hit.point + Vector3.up * transform.localScale.y / 2;
        }
    }
}
