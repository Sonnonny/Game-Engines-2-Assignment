using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chaser : MonoBehaviour
{
    float currDist;
    float closestDist = Mathf.Infinity;

    public Transform target;

    bool chase;
    public GameObject light;

    public float speed;

    float charge = 0;

    public float chaseTime;

    public Camera0 cam0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currDist = Vector3.Distance(transform.position, target.position);
        if (currDist < closestDist)
        {
            closestDist = currDist;
        }
        else if (closestDist < currDist && !chase)
        {
            StartCoroutine(Engines());
            
        }

        if (!chase) return;

        light.SetActive(true);
        if (charge == 0) charge = 0.001f;
        else if (charge <= 1) charge += 5*Time.deltaTime*charge;
        //transform.LookAt(target);
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime * charge);
        cam0.rotate = true;

        if (chaseTime >= 0)
        {
            chaseTime -= Time.deltaTime;
            
        }
        if(chaseTime <= 0 && chaseTime > -10)
        {
            SceneManager.LoadScene(3);
        }

        SlowRotate();

    }

    void SlowRotate()
    {
        Vector3 targetDirection = target.position - transform.position;

        // The step size is equal to speed times frame time.
        float singleStep = 0.1f * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        // Draw a ray pointing at our target in
        //Debug.DrawRay(transform.position, newDirection, Color.red);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);
    }

    IEnumerator Engines()
    {
        yield return new WaitForSeconds(2);
        chase = true;
    }
}
