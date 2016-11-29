using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class PauseScript : MonoBehaviour, IPointerDownHandler
{
	public GameController control;

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
		control.Pause ();
	}
}
