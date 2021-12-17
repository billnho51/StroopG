using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gameplay : MonoBehaviour
{

    public static bool isPlaying = false;

    public TextMeshProUGUI largeText;

    //array for colors in the game
    Color[] colours = new Color[4];
    //array for colors in text
    string[] colorNames = new string[4];

    public bool timerIsRunning;
    public float timeRemaining = 6;
    public GameObject gameUI;
    // Start is called before the first frame update
    void Start()
    {
        //set up color
        colours[0] = Color.red;
        colours[1] = Color.green;
        colours[2] = Color.blue;
        colours[3] = Color.yellow;

        //set up color name
        colorNames[0] = "red";
        colorNames[1] = "blue";
        colorNames[2] = "green";
        colorNames[3] = "yellow";

        pickRandomColor();

    }

    // Update is called once per frame
    void Update()
    {

        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                if (timeRemaining > 3)
                {
                    
                }
                
                else
                {
                    largeText.text = timeRemaining.ToString("F0");
                }
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 6;
                timerIsRunning = false;
                pickRandomColor();
            }
        }



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
        checkAnswer("red");
        timerIsRunning = true;
        //pickRandomColor();

    }

    public void second()
    {
        Debug.Log("Second button pressed");
        checkAnswer("blue");
        timerIsRunning = true;
        //pickRandomColor();

    }

    public void third()
    {
        Debug.Log("Third button pressed");
        checkAnswer("green");
        timerIsRunning = true;
        //pickRandomColor();

    }

    public void fourth()
    {
        Debug.Log("Fourth button pressed");
        checkAnswer("yellow");
        timerIsRunning = true;
        //pickRandomColor();
        
    }


    private void pickRandomColor()
    {
        //get color name from string list
        string randomColor = colorNames[Random.Range(0, colorNames.Length)];

        //set color variable from color list
        largeText.color = colours[Random.Range(0, colours.Length)];
        //set color text
        largeText.text = randomColor;
        

    }


    private void checkAnswer(string colorN)
    {
        switch (colorN){
            case "red":
                if (largeText.color == Color.red)
                {
                    largeText.color = Color.white;
                    largeText.text = "Correct :>";

                }
                else 
                {
                    largeText.color = Color.white;
                    largeText.text = "Incorrect :<";
                }
                break;
            
            case "blue":
                if (largeText.color == Color.blue)
                {
                    largeText.color = Color.white;
                    largeText.text = "Correct :>";

                }
                else 
                {
                    largeText.color = Color.white;
                    largeText.text = "Incorrect :<";
                }
                break;
            case "yellow":
                if (largeText.color == Color.yellow)
                {
                    largeText.color = Color.white;
                    largeText.text = "Correct :>";

                }
                else 
                {
                    largeText.color = Color.white;
                    largeText.text = "Incorrect :<";
                }
                break;
            case "green":
                if (largeText.color == Color.green)
                {
                    largeText.color = Color.white;
                    largeText.text = "Correct :>";

                }
                else 
                {
                    largeText.color = Color.white;
                    largeText.text = "Incorrect :<";
                }
                break;
            
            default:
                
                break;
        }

    }


    IEnumerator temp()
    {
        yield return new WaitForSeconds(3);
        Debug.Log("wait is over");

    }
}
