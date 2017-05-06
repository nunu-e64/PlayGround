using UnityEngine;
using System.Collections;

public class Panel : MonoBehaviour
{
	private bool hold = false;
	private Vector3 startMousePosition;
	private int directionIndex = -1;
	public GameObject target;
	private float speed = 10.0f;

	// Use this for initialization
	void Start()
	{
	
	}
	
	// Update is called once per frame
	void Update()
	{
		if (directionIndex >= 0) {
			this.transform.position = this.transform.position + (target.transform.position - this.transform.position) * speed * Time.deltaTime;
			return;
		}

		if (Input.GetMouseButtonDown(0) && !hold) {
			var mousePosition = Input.mousePosition;
			mousePosition.z = 10;
			var tapPoint = Camera.main.ScreenToWorldPoint(mousePosition);
			Debug.Log(Input.mousePosition);
			Debug.Log(tapPoint);
	
			// 可視化
			Debug.DrawRay(tapPoint, new Vector3(0, 0, 100), Color.blue, 1);

			var hitObject = Physics2D.Raycast(tapPoint, Vector3.forward, 100);
			if (hitObject && hitObject.collider.gameObject.name == this.name) {
				Debug.Log("hit object is " + hitObject.collider.gameObject.name);
				hold = true;
				startMousePosition = Input.mousePosition;
			}
		}

		if (Input.GetMouseButton(0) && hold) {
			var currentMousePosition = Input.mousePosition;
			if (currentMousePosition != startMousePosition) {
				// TODO houkou
				if (currentMousePosition.y > startMousePosition.y) {
					directionIndex = 0;
				}
			}
		}
	}
}