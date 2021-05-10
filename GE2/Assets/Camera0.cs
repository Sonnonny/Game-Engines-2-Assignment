using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera0 : MonoBehaviour
{

    public bool rotate;
    public Transform rotPoint;

    public int rotType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!rotate) return;

        if(rotType == 0) transform.RotateAround(rotPoint.position,Vector3.up, 10*Time.deltaTime);
        else if(rotType == 1) transform.RotateAround(rotPoint.position, Vector3.forward, 20 * Time.deltaTime);
    }
}
