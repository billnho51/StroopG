using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gameplay : MonoBehaviour
{

    public static bool isPlaying = false;

    public TextMeshProUGUI largeText;
    public GameObject gameUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(isPlaying)
            {
                Resume();

            }
            else
            {
                Pause();
            }

        }
    }


    void Resume()
    {
        gameUI.SetActive(false);
        Time.timeScale = 1f;
        isPlaying = false;

    }

    void Pause()
    {
        gameUI.SetActive(true);
        Time.timeScale = 0f;
        isPlaying = true;
        
    }


    public void first()
    {
        Debug.Log("First button pressed");
        pickRandomColor();

    }

    public void second()
    {
        Debug.Log("Second button pressed");
        pickRandomColor();

    }

    public void third()
    {
        Debug.Log("Third button pressed");
        pickRandomColor();

    }

    public void fourth()
    {
        Debug.Log("Fourth button pressed");
        pickRandomColor();
        
    }


    private void pickRandomColor()
    {
        string[] colors = new string[] {"red", "blue", "yellow","green"};
        string randomColor = colors[Random.Range(0, colors.Length)];
        if (randomColor == "red"){
            largeText.color = new Color32(222, 41, 22, 255);
        }

        largeText.text = randomColor;
        

    }
}
