using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenTOLeve1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeScreenTOLevel1()
    {
        SceneManager.LoadScene("SampleScene");
    }
    
    public void changeScreenTOMainMenu()
    {
        SceneManager.LoadScene("Scenes/MainScreen");
    }
    
}
