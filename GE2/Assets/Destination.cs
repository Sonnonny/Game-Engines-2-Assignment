using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destination : MonoBehaviour
{
    public Transform end;

    public float startRot;
    public float flyRot;

    public float speed;

    public float flyTime;

    //public Camera0 cam0;

    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(end);
        transform.Rotate(0, 0, -startRot);
        //
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, end.position, speed*Time.deltaTime);

        transform.Rotate(0,0,flyRot*Time.deltaTime);

        if (flyTime >= 0)
        {
            flyTime -= Time.deltaTime;
        }
        if (flyTime <= 0 && flyTime > -10)
        {
            SceneManager.LoadScene(2);
        }
    }
}
