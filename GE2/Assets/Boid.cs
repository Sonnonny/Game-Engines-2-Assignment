using UnityEngine;
using System.Collections;

public class Boid : MonoBehaviour
{
    private GameObject Controller;
    private bool inited = false;
    private float minVelocity;
    private float maxVelocity;
    private float randomness;
    private GameObject chasee;

    public GameObject death;

    void Start()
    {
        StartCoroutine("BoidSteering");
        //transform.Rotate(0, -11.2f, 0);
    }

    public void Update()
    {
       // transform.LookAt(chasee.transform);
    }

    IEnumerator BoidSteering()
    {
        while (true)
        {
            if (inited)
            {
                Vector3 velo = GetComponent<Rigidbody>().velocity + Calc() * Time.deltaTime;
                velo = new Vector3(0, velo.y, velo.z);
                GetComponent<Rigidbody>().velocity = velo;

                // enforce minimum and maximum speeds for the boids
                float speed = GetComponent<Rigidbody>().velocity.magnitude;
                if (speed > maxVelocity)
                {
                    GetComponent<Rigidbody>().velocity = velo.normalized * maxVelocity;
                }
                else if (speed < minVelocity)
                {
                    GetComponent<Rigidbody>().velocity = velo.normalized * minVelocity;
                }
            }

            float waitTime = Random.Range(0.3f, 0.5f);
            yield return new WaitForSeconds(waitTime);
        }
    }

    private Vector3 Calc()
    {
        Vector3 randomize = new Vector3((Random.value * 2) - 1, (Random.value * 2) - 1, (Random.value * 2) - 1);

        randomize.Normalize();
        BoidManager boidController = Controller.GetComponent<BoidManager>();
        Vector3 flockCenter = boidController.flockCenter;
        Vector3 flockVelocity = boidController.flockVelocity;
        Vector3 follow = chasee.transform.localPosition;

        flockCenter = flockCenter - transform.localPosition;
        flockVelocity = flockVelocity - GetComponent<Rigidbody>().velocity;
        follow = follow - transform.localPosition;


        Vector3 done = (flockCenter + flockVelocity + follow * 2 + randomize * randomness);
        done = new Vector3(-13, done.y, done.z);

        return done;
    }

    public void SetController(GameObject theController)
    {
        Controller = theController;
        BoidManager boidController = Controller.GetComponent<BoidManager>();
        minVelocity = boidController.minVelocity;
        maxVelocity = boidController.maxVelocity;
        randomness = boidController.randomness;
        chasee = boidController.chasee;
        inited = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Broke")
        {
            GameObject Go = Instantiate(death,transform.position, Quaternion.identity);
            Go.transform.SetParent(null);
            Destroy(gameObject);
        }
    }
}