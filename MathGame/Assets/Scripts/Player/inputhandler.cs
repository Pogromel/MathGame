using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inputhandler : MonoBehaviour
{
    [SerializeField] InputField inputFieldX;
    [SerializeField] InputField inputFieldY;
    [SerializeField] GameObject character;
    private int currentXpos = 0;
    private int currentYpos = 0;
    private int maxXpos = 6;
    private int maxYpos = 3;
    public void changePlayerPosition()
    {
        string inputX = inputFieldX.text;
        string inputY = inputFieldY.text;
        try
        {
            Debug.Log("currentPosX " + currentXpos);
            Debug.Log("inputX " + int.Parse(inputX));
            int inputXint = int.Parse(inputX) + currentXpos;
            int inputYint = int.Parse(inputY) + currentYpos;
            Debug.Log("inputXint " + inputXint);
            if ((inputXint <= maxXpos && inputXint >= -maxXpos) && (inputYint <= maxYpos && inputYint >= -maxYpos))
            {
                currentXpos = inputXint;
                currentYpos = inputYint;
                Vector3 temp = character.transform.position;
                temp.x = inputXint;
                temp.y = inputYint;
                character.transform.position = temp;
            }
            else
            {
                Debug.Log("The co-ordinates are out of bounds");
            }
        }
        catch 
        {
            Debug.Log("Please enter proper co-ordinates for both boxes.");
        } 
        
        
    }
}
