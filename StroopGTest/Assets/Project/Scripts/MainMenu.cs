using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void play()
    {
        SceneManager.LoadScene("StroopG");
    }

    public void tutorial()
    {
        SceneManager.LoadScene("Tutorial");

    }

    public void quit()
    {
        Debug.Log("Quitting game....");
        //does not quit current play in unity editor
        Application.Quit();
    }
}
