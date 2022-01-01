using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class gameplay : MonoBehaviour
{
    //public objects for indicating text to make changes to
    public TextMeshProUGUI largeText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalScore;
    public GameObject durationTimer;
    public GameObject gameUI;
    public GameObject endUI;
    public GameObject pauseUI;

    //private class for accessing and changing data
    private testingAnimate shaking;
    private DurationBar duration;


    //keep track of score each play
    private int points;
    private bool timesUp;
    public static bool isPlaying = false;

    public bool mouseOnobject = false;



    //array for colors in the game
    Color[] colours = new Color[4];
    //array for colors in text
    string[] colorNames = new string[4];
 
    // Start is called before the first frame update
    void Start()
    {

        //linking varibales with class to get constraints
        shaking = scoreText.GetComponent<testingAnimate>();
        duration = durationTimer.GetComponent<DurationBar>();
        
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

        //set up activeUI
        gameUI.SetActive(true);
        pauseUI.SetActive(false);
        endUI.SetActive(false);
        //initiate the game
        pickRandomColor();
        

    }

    // Update is called once per frame
    void Update()
    {
        //update value each frame to check whether time has run out
        timesUp = duration.gameDone();
        //check if mouse is clicked anywhere except buttons
        if (Input.GetMouseButtonDown(0) && !mouseOnobject)
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

    //Application Function
    void Resume()
    {
        gameUI.SetActive(false);
        pauseUI.SetActive(true);
        isPlaying = false;

    }

    void Pause()
    {
        gameUI.SetActive(true);
        pauseUI.SetActive(false);
        isPlaying = true;
        
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void mainMenu()
    {
        SceneManager.LoadScene("menu");

    }

    public void quit()
    {
        Debug.Log("Quitting game....");
        //does not quit current play in unity editor
        Application.Quit();
    }

    //add constrainsts when hover above clickable object
    public void OnMouseEnter() 
    {
        mouseOnobject = true;     
    }

    public void OnMouseExit() 
    {
        mouseOnobject = false;    
    }

    // game play funtions
    //Each buttons has its specific case to check when pressed
    //check answer to update score board
    //change to next questions
    public void first()
    {
        //Debug.Log("First button pressed");
        checkAnswer("red");
        pickRandomColor();

    }

    public void second()
    {
        //Debug.Log("Second button pressed");
        checkAnswer("blue");
        pickRandomColor();

    }

    public void third()
    {
        //Debug.Log("Third button pressed");
        checkAnswer("green");
        pickRandomColor();

    }

    public void fourth()
    {
        //Debug.Log("Fourth button pressed");
        checkAnswer("yellow");
        pickRandomColor();
        
    }

    //going to next question
    private void pickRandomColor()
    {
        //Cahnge active UI and update final score board after 60 secs
        if (timesUp == true)
        {
            gameUI.SetActive(false);
            endUI.SetActive(true);
            //set final score
            finalScore.text = points.ToString();


        }
        //if not update the new color
        else
        {
            //get color name from string list
            string randomColor = colorNames[Random.Range(0, colorNames.Length)];

            //set color variable from color list
            largeText.color = colours[Random.Range(0, colours.Length)];
            //set color text
            largeText.text = randomColor;

        }

        

    }


    private void checkAnswer(string colorN)
    {
        //updates points base on correct or wrong
        switch (colorN){
            case "red":
                if (largeText.color == Color.red)
                {
                    
                    points += 1;
                    scoreText.text = points.ToString();

                }
                else 
                {
                    shakeText();
                    if (points > 0)
                    {
                        points -= 1;
                        scoreText.text = points.ToString();

                    }


                }
                break;
            
            case "blue":
                if (largeText.color == Color.blue)
                {
                    //updates points
                    points += 1;
                    scoreText.text = points.ToString();

                }
                else 
                {
                    shakeText();
                    if (points > 0)
                    {
                        points -= 1;
                        scoreText.text = points.ToString();

                    }
                }
                break;
            case "yellow":
                if (largeText.color == Color.yellow)
                {
                    //updates points
                    points += 1;
                    scoreText.text = points.ToString();

                }
                else 
                {
                    shakeText();
                    if (points > 0)
                    {
                        points -= 1;
                        scoreText.text = points.ToString();

                    }
                }
                break;
            case "green":
                if (largeText.color == Color.green)
                {
                    //updates points
                    points += 1;
                    scoreText.text = points.ToString();

                }
                else 
                {
                    shakeText();
                    if (points > 0)
                    {
                        points -= 1;
                        scoreText.text = points.ToString();

                    }
                }
                break;
            
            default:
                
                break;
        }

    }

    void shakeText()
    {
        
        shaking.setRun();
        
    }

    public int getPoints()
    {
        return this.points;

    }
}
