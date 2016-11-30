using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;

public class GameController : MonoBehaviour
{

	private static bool _paused;

	public static bool moving = false;

	private const float _movementSpeed = 3.0f;
	private const float _rotationSpeed = 5.0f;

	public static char direction;


	public GameObject player;

	public GameObject canvas;
	public BleacherController bc;


	// Use this for initialization
	void Start ()
	{
		_paused = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (moving) {
			UpdateMovement (direction);
		}
	}

	public void Pause ()
	{
		if (_paused) {
			Time.timeScale = 1;
			_paused = !_paused;
			bc.paused = _paused;
		} else {
			Time.timeScale = 0;
			_paused = !_paused;
			bc.paused = _paused;
		}
		var enableds = this.canvas.GetComponentsInChildren<RawImage> ();

		foreach (var element in enableds) {
			element.enabled = !element.enabled;
		}
	}

	/// <summary>
	/// Updates the player's movement.
	/// </summary>
	/// <param name="direction">'F' for forward, 'B' for backward, 'L' for left, 'R' for right</param>
	public void UpdateMovement (char direction)
	{
		if (direction == 'F' || direction == 'B') {
			player.GetComponent<Rigidbody> ().velocity += direction == 'F' ? player.transform.forward * _movementSpeed : player.transform.forward * -_movementSpeed;
			//player.GetComponent<Rigidbody> ().velocity += 15.0f * -player.transform.up;
		}
		if (direction == 'L' || direction == 'R') {
			var rot = player.GetComponent<Transform> ().localRotation;
			Debug.Log (rot);
			rot.eulerAngles = direction =='L' ? rot.eulerAngles - Vector3.up * _rotationSpeed : rot.eulerAngles + Vector3.up * _rotationSpeed;
			player.transform.localRotation = rot;
		}
	}
}
