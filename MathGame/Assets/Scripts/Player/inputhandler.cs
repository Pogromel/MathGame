using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inputhandler : MonoBehaviour
{
    [SerializeField] InputField inputFieldX;
    [SerializeField] InputField inputFieldY;
    [SerializeField] GameObject character;
    private int maxXpos = 6;
    private int maxYpos = 6;

    void Update()
    {
        PlayerMovement();
    }
    public void PlayerMovement()
    {
        
        if (Input.GetKeyDown("up") && character.transform.position.y < maxYpos)
        {
            Vector3 temp = character.transform.position;
            temp.y += 1f;
            character.transform.position = temp;
        }
        else if (Input.GetKeyDown("down") && character.transform.position.y > -maxYpos)
        {
            Vector3 temp = character.transform.position;
            temp.y -= 1f;
            character.transform.position = temp;
        }

        //Horizontal Movement
        else if (Input.GetKeyDown("right") && character.transform.position.x < maxXpos)
        {
            Vector3 temp = character.transform.position;
            temp.x += 1f;
            character.transform.position = temp;
        }
        else if (Input.GetKeyDown("left") && character.transform.position.x > -maxXpos)
        {
            Vector3 temp = character.transform.position;
            temp.x -= 1f;
            character.transform.position = temp;
        }
    }
    public void changePlayerPosition()
    {
        string inputX = inputFieldX.text;
        string inputY = inputFieldY.text;
        try
        {
            int inputXint = int.Parse(inputX);
            int inputYint = int.Parse(inputY);
            if ((inputXint <= maxXpos && inputXint >= -maxXpos) && (inputYint <= maxYpos && inputYint >= -maxYpos))
            {
                Vector3 temp = character.transform.position;
                temp.x = inputXint;
                temp.y = inputYint;
                character.transform.position = temp;
            }
        }
        catch 
        {
            Debug.Log("Please enter a number! (It should be within the limits of the graph)");
        } 
        
        
    }
}
