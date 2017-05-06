using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	private Vector3 startMousePosition;

	// Use this for initialization
	void Start()
	{
		
	}
	
	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0)) {
			startMousePosition = Input.mousePosition;
		}

		if (Input.GetMouseButton(0)) {
			var currentMousePosition = Input.mousePosition;
			var diff = currentMousePosition - startMousePosition;

			this.transform.localRotation = Quaternion.Euler(diff.y, diff.z, diff.x);
		}

		if (Input.GetMouseButtonUp(0)) {
			this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 100, 100));	
		}
	}
}
