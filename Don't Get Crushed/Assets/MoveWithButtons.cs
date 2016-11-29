using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class MoveWithButtons : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

	public char direction;
	public GameController controller;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void OnPointerDown (PointerEventData eventData)
	{
		GameController.direction = this.direction;
		GameController.moving = true;
	}

	public void OnPointerUp (PointerEventData eventData)
	{
		GameController.moving = false;
		GameController.direction = '\0';
	}

}
