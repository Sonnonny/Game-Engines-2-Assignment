using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCam : MonoBehaviour
{
    public float x, y, z;

    public float xNew, yNew, zNew;

    public float xT, yT, zT;


    public float xTimer, yTimer, zTimer;



    // Start is called before the first frame update
    void Start()
    {
        xTimer = Random.Range(3, 6);
        yTimer = Random.Range(3, 6);
        zTimer = Random.Range(3, 6);

        xNew = Random.Range(-0.2f, 0.2f);
        yNew = Random.Range(-0.2f, 0.2f);
        zNew = Random.Range(-0.2f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        xT += Time.deltaTime/3;
        yT += Time.deltaTime/3;
        zT += Time.deltaTime/3;

        x = Mathf.Lerp(x,xNew,xT);
        y = Mathf.Lerp(y, yNew, yT);
        z = Mathf.Lerp(z, zNew, zT);

        if(xT > xTimer)
        {
            xNew = Random.Range(-0.2f, 0.2f);
            xT = 0;
            xTimer = Random.Range(3, 6);
        }
        if (yT > yTimer)
        {
            yT = 0;
            yNew = Random.Range(-0.2f, 0.2f);
            yTimer = Random.Range(3, 6);
        }
        if (zT > zTimer)
        {
            zT = 0;
            zNew = Random.Range(-0.2f, 0.2f);
            zTimer = Random.Range(3, 6);
        }



        transform.Rotate(x, y, z);
    }




}
