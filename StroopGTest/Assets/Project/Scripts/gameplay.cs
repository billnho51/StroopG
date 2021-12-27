using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class gameplay : MonoBehaviour
{
    public TextMeshProUGUI largeText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalScore;

    public GameObject durationTimer;

    //private class for accessing and changing data
    private testingAnimate shaking;
    private DurationBar duration;

    bool hasTextChanged = false;




    private int points;
    public static bool isPlaying = false;



    //array for colors in the game
    Color[] colours = new Color[4];
    //array for colors in text
    string[] colorNames = new string[4];
    public GameObject gameUI;
    public GameObject endUI;
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

        pickRandomColor();

    }

    // Update is called once per frame
    void Update()
    {
        bool timesUp = duration.gameDone();

        if(timesUp == true)
        {
            gameUI.SetActive(false);
            endUI.SetActive(true);
            //set final score
            finalScore.text = points.ToString();
        
            

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

    //Application Function
    void Resume()
    {
        gameUI.SetActive(false);
        //Time.timeScale = 1f;
        isPlaying = false;

    }

    void Pause()
    {
        gameUI.SetActive(true);
        //Time.timeScale = 0f;
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
    public void first()
    {
        Debug.Log("First button pressed");
        checkAnswer("red");
        //timerIsRunning = true;
        pickRandomColor();

    }

    public void second()
    {
        Debug.Log("Second button pressed");
        checkAnswer("blue");
        //timerIsRunning = true;
        pickRandomColor();

    }

    public void third()
    {
        Debug.Log("Third button pressed");
        checkAnswer("green");
        //timerIsRunning = true;
        pickRandomColor();

    }

    public void fourth()
    {
        Debug.Log("Fourth button pressed");
        checkAnswer("yellow");
        //timerIsRunning = true;
        pickRandomColor();
        
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
                    //largeText.color = Color.white;
                    //largeText.text = "Correct :>";
                    //updates points
                    points += 1;
                    scoreText.text = points.ToString();

                }
                else 
                {
                    //largeText.color = Color.white;
                    //largeText.text = "Incorrect :<";
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
                    //largeText.color = Color.white;
                    //largeText.text = "Correct :>";
                    //updates points
                    points += 1;
                    scoreText.text = points.ToString();

                }
                else 
                {
                    //largeText.color = Color.white;
                    //largeText.text = "Incorrect :<";
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
                    //largeText.color = Color.white;
                    //largeText.text = "Correct :>";
                    //updates points
                    points += 1;
                    scoreText.text = points.ToString();

                }
                else 
                {
                    //largeText.color = Color.white;
                    //largeText.text = "Incorrect :<";
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
                    //largeText.color = Color.white;
                    //largeText.text = "Correct :>";
                    //updates points
                    points += 1;
                    scoreText.text = points.ToString();

                }
                else 
                {
                    //largeText.color = Color.white;
                    //largeText.text = "Incorrect :<";
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
