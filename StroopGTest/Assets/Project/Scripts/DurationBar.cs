using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.UI;
public class DurationBar : MonoBehaviour
{

    private Slider durationBar;

    private float timeRemaining = 60f;
    private float maxTime = 60f;
    public float fillSpeed = 0.5f;
    private bool gameEnd = false;

    private void Awake() 
    {
        durationBar = gameObject.GetComponent<Slider>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        //set bar to full at the beginning of the round - 60secs
        durationBar.value = 1f;

    }

    // Update is called once per frame
    void Update()
    {

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            durationBar.value = timeRemaining / maxTime;

        }
        else
        {
            Debug.Log("Time has run out");
            gameEnd = true;

        }
    }


    public bool gameDone(){
        return gameEnd;

    }


}
