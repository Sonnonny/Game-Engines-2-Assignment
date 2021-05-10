using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flight : MonoBehaviour
{
    public float speed;
    public Transform target;

    public Transform cam;

    public float timer;

    public bool rot;

    bool returnFire;

    public GameObject bullet;

    bool lastScene;

    public GameObject death;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        timer += Time.deltaTime;

        if (rot) transform.Rotate(0, 0, 0.4f);

        if(timer>= 3)
        {

        }

    }



    IEnumerator Fire()
    {

        for (int i = 0; i < 200; i++)
        {
            GameObject Go = Instantiate(bullet, transform);
            Go.transform.position += new Vector3(Random.Range(-1,1)*3, Random.Range(-1, 1), 0);
            Go.GetComponent<Rigidbody>().AddForce(0,0,-30,ForceMode.Impulse);
            Destroy(Go, 1f);
            yield return new WaitForSeconds(0.01f);

            if(i == 199)
            {
                SceneManager.LoadScene(4);
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Missile" && !returnFire)
        {
            returnFire = true;
            StartCoroutine(Fire());
        }

        if(other.tag == "Asteroid")
        {
            Instantiate(death, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
