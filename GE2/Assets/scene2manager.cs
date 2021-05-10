using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scene2manager : MonoBehaviour
{


    public GameObject firstCam;
    public GameObject secondCam;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Switch()
    {
        firstCam.SetActive(false);
        secondCam.SetActive(true);
    }
}
