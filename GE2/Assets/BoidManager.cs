using UnityEngine;
using System.Collections;

public class BoidManager : MonoBehaviour
{
    public float minVelocity = 5;
    public float maxVelocity = 20;
    public float randomness = 1;
    public int flockSize = 20;
    public GameObject prefab;
    public GameObject chasee;

    public Vector3 flockCenter;
    public Vector3 flockVelocity;

    private GameObject[] boids;

    public scene2manager scene2Manager;

    void Start()
    {
        boids = new GameObject[flockSize];
        StartCoroutine(wait());
        Invoke("Switch", 3f);
    }

    void Switch()
    {
        scene2Manager.Switch();
    }

    IEnumerator wait()
    {
        for (var i = 0; i < flockSize; i++)
        {
            Vector3 position = new Vector3(
                Random.value * GetComponent<SphereCollider>().bounds.size.x,
                Random.value * GetComponent<SphereCollider>().bounds.size.y,
                Random.value * GetComponent<SphereCollider>().bounds.size.z
            ) - GetComponent<SphereCollider>().bounds.extents;

            GameObject boid = Instantiate(prefab, transform.position, transform.rotation) as GameObject;
            boid.transform.parent = transform;
            boid.transform.localPosition = position;
            boid.GetComponent<Boid>().SetController(gameObject);
            boids[i] = boid;
            yield return new WaitForSeconds(0.1f);
        }
        
    }

    void Update()
    {
        Vector3 theCenter = Vector3.zero;
        Vector3 theVelocity = Vector3.zero;



        foreach (GameObject boid in boids)
        {
            if(boid != null)
            {
                theCenter = theCenter + boid.transform.localPosition;
                theVelocity = theVelocity + boid.GetComponent<Rigidbody>().velocity;
            }

        }

        flockCenter = theCenter / (flockSize);
        flockVelocity = theVelocity / (flockSize);
    }
}
