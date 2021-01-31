using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class nextLevel : MonoBehaviour
{
    public int TotalLevels=2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void nextScene()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        if (currentLevel < TotalLevels - 1)
        {
            SceneManager.LoadScene(currentLevel + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}
