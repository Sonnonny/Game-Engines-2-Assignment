using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneDone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Done", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Done()
    {
        Destroy(Music.music.gameObject);
        SceneManager.LoadScene(0);
    }
}
