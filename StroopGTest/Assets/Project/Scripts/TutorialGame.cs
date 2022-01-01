using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TutorialGame : MonoBehaviour
{
    //public objects for indicating text to make changes to
    public TextMeshProUGUI largeText;
    public TextMeshProUGUI scoreText;
    private testingAnimate shaking;
    public GameObject gameUI;
    public GameObject EndUI;



    //private variables to keep track score from each play
    private int points;
    private int counter = 0;
    public static bool isPlaying = false;

    //timer during gameplay
    private bool timerIsRunning;
    //timer at start of tutorial to show description
    public bool initialTimerRunning;
    private float timeRemaining = 5;
    public float initialTimeRemaining = 10;

    //array for colors in the game
    Color[] colours = new Color[4];
    //array for colors in text
    string[] colorNames = new string[4];


    // Start is called before the first frame update
    void Start()
    {
        //set up activeUI
        gameUI.SetActive(true);
        EndUI.SetActive(false);

        //linking varibales with class to get constraints
        shaking = scoreText.GetComponent<testingAnimate>();
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
        //start initial timer
        initialTimerRunning = true;

    }

    // Update is called once per frame
    void Update()
    {
        //run innitial timer for 10 secs - change from description to countdown when hit 5
        if (initialTimerRunning)
        {
            if (initialTimeRemaining > 0)
            {
                
                if (initialTimeRemaining > 5)
                {
                    
                }
                
                else
                {
                    largeText.text = initialTimeRemaining.ToString("F0");
                }
                initialTimeRemaining -= Time.deltaTime;

            }
            //start the game after 10 sec
            else
            {
                initialTimerRunning = false;
                pickRandomColor();
            }


        }

        //run timer for 5 secs - show player results of their answer for 3 secs and change to countdown at 3
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
                timeRemaining = 5;
                timerIsRunning = false;
                pickRandomColor();
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


    // game play funtions
    //Each buttons has its specific case to check when pressed
    //check answer to update score board
    //change to next questions
    public void first()
    {
        //do nothing while countdown
        if (timerIsRunning || initialTimerRunning)
        {


        }
        else
        {
            //Debug.Log("First button pressed");
            checkAnswer("red");
            timerIsRunning = true;

        }


    }

    public void second()
    {
        //do nothing while countdown
        if (timerIsRunning || initialTimerRunning)
        {


        }
        else
        {
            //Debug.Log("Second button pressed");
            checkAnswer("blue");
            timerIsRunning = true;
        }
        

    }

    public void third()
    {
        //do nothing while countdown
        if (timerIsRunning || initialTimerRunning)
        {


        }
        else
        {
            //Debug.Log("Third button pressed");
            checkAnswer("green");
            timerIsRunning = true;
        }


    }

    public void fourth()
    {
        //do nothing while countdown
        if (timerIsRunning || initialTimerRunning)
        {


        }
        else
        {
            //Debug.Log("Fourth button pressed");
            checkAnswer("yellow");
            timerIsRunning = true;    
        }

    }


    //going to next question
    private void pickRandomColor()
    {
        //Change active UI after 5 questions
        if (counter > 5)
        {
            gameUI.SetActive(false);
            EndUI.SetActive(true);

        }
        //if not - update new questions
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
        //increase counter to keep track of questions answered
        //change text base on whether the answer is correct or false
        counter++;
        switch (colorN){
            case "red":
                if (largeText.color == Color.red)
                {
                    largeText.color = Color.white;
                    largeText.text = "Correct :>";
                    //updates points
                    points += 1;
                    scoreText.text = points.ToString();

                }
                else 
                {
                    largeText.color = Color.white;
                    largeText.text = "Incorrect :<";
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
                    largeText.color = Color.white;
                    largeText.text = "Correct :>";
                    //updates points
                    points += 1;
                    scoreText.text = points.ToString();

                }
                else 
                {
                    largeText.color = Color.white;
                    largeText.text = "Incorrect :<";
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
                    largeText.color = Color.white;
                    largeText.text = "Correct :>";
                    //updates points
                    points += 1;
                    scoreText.text = points.ToString();

                }
                else 
                {
                    largeText.color = Color.white;
                    largeText.text = "Incorrect :<";
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
                    largeText.color = Color.white;
                    largeText.text = "Correct :>";
                    //updates points
                    points += 1;
                    scoreText.text = points.ToString();

                }
                else 
                {
                    largeText.color = Color.white;
                    largeText.text = "Incorrect :<";
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
}
