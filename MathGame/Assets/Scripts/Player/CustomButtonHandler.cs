using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CustomButtonHandler : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private inputhandler InputHandler; 

    public void OnPointerClick(PointerEventData eventData)
    {
        
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            InputHandler.changePlayerPosition();
        }
    }
}