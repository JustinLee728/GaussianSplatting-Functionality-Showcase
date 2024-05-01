using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            Debug.Log(nextSceneIndex);
            SceneManager.LoadScene(nextSceneIndex);
            if (nextSceneIndex == 5)    {
                SceneManager.LoadScene(0);
            }
        }
    }
}
