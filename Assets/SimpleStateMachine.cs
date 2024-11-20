using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleStateMachine : MonoBehaviour
{
    public float speed = .001f;
    public float time = 10f;
    public float percentage;
    public bool colorChange = false;
    //here's my enumerable, this will track the color of the object's material
    public enum stateMode //declaring a new variable type
    {
        RED,
        GREEN,
        BLUE,
        CYAN,
        MAGENTA,
        YELLOW
    }

    //an actual instance of the enumerable stateMode we have just defined
    public stateMode myMode; //this is an instance stateMode
    stateMode prevMode;

    Renderer myRend;
    Material myMat;

    Color targetCol;

    // Start is called before the first frame update
    void Start()
    {
        colorChange = false;
        myRend= GetComponent<Renderer>();
        myMat = myRend.material;
        if(myMode != stateMode.RED) { prevMode = stateMode.RED; }
        else { prevMode = stateMode.CYAN; }

    }
    // Update is called once per frame
    void Update()
    {
        
        //to determine what code to run based off the current state of our myMode variable
        //we're going to use a switch statement
        switch (myMode) //declare the enum this is referencing
        {
            case stateMode.RED: //for each potential state or mode, delcare a "case" and then write any relevant code for that mode
                targetCol = Color.red;
                break; //at the end of each case, put a break

            case stateMode.GREEN:
                targetCol = Color.green;
                break;

            case stateMode.BLUE:
                targetCol = Color.blue;
                break;

            case stateMode.CYAN:
                targetCol = Color.cyan;
                break;
        }   
        
        if(myMode != prevMode && !colorChange)
        {

            colorChange = true;
            StartCoroutine(SetColor(targetCol, time));
        }

        prevMode = myMode;
    }

    public static float RemapFloat(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }

    IEnumerator SetColor(Color c, float t)
    {
        while(t >= 0)
        {
            
            t -= speed;
            percentage = RemapFloat(t, 0, time, 0, 1);
            myMat.color = Color.Lerp(myMat.color, c, 1 - percentage);
            yield return new WaitForSeconds(speed);
        }
        colorChange = false;
        
    }
}
