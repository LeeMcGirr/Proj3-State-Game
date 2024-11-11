using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleStateMachine : MonoBehaviour
{

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

    Renderer myRend;
    Material myMat;

    // Start is called before the first frame update
    void Start()
    {
        myRend= GetComponent<Renderer>();
        myMat = myRend.material;
    }
    // Update is called once per frame
    void Update()
    {

        //to determine what code to run based off the current state of our myMode variable
        //we're going to use a switch statement
        switch (myMode) //declare the enum this is referencing
        {
            case stateMode.RED: //for each potential state or mode, delcare a "case" and then write any relevant code for that mode
                myMat.color = Color.red;
                break; //at the end of each case, put a break

            case stateMode.GREEN:
                myMat.color = Color.green;
                break;

            case stateMode.BLUE:
                myMat.color = Color.blue;
                break;

            case stateMode.CYAN:
                myMat.color = Color.cyan;
                break;
        }         
    }
}
