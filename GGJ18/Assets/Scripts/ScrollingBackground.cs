using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour {

	public bool scrolling;
	public bool paralaxXaxis = true;
	public bool paralaxYaxis = true;
	public float backgroundSize = 19.57f;
	public float paralaxSpeedX = 0.5f;
	public float paralaxSpeedY = -0.7f;

	private Transform cameraTransform;
	private Transform[] layers;
	private float viewZone = 30;
	private int leftIndex;
	private int rightIndex;
	private float lastCameraX;
	private float lastCameraY;


	private void Start(){

		cameraTransform = Camera.main.transform;

		lastCameraX = cameraTransform.position.x;
		lastCameraY = cameraTransform.position.y;

		layers = new Transform[transform.childCount];
		for (int i = 0; i < transform.childCount; i++) {
			layers [i] = transform.GetChild (i);
		}

		leftIndex = 0;
		rightIndex = layers.Length - 1;
	}

	private void Update(){
		if (paralaxXaxis) {
			float deltaX = cameraTransform.position.x - lastCameraX;
			transform.position += Vector3.right * (deltaX * paralaxSpeedX);
		}
		if (paralaxYaxis) {
			float deltaY = cameraTransform.position.y - lastCameraY;
			transform.position += Vector3.down * (deltaY * paralaxSpeedY);
		}

		lastCameraX = cameraTransform.position.x;
		lastCameraY = cameraTransform.position.y;
		if (scrolling) {
			if (cameraTransform.position.x < (layers [leftIndex].transform.position.x + viewZone)) {
				ScrollLeft ();
			}
			if (cameraTransform.position.x > (layers [leftIndex].transform.position.x + viewZone)) {
				ScrollRight ();
			}
		}
	}

	private void ScrollLeft(){
		int lastRight = rightIndex;
		layers [rightIndex].position = Vector2.right * (layers [leftIndex].position.x - backgroundSize);
		leftIndex = rightIndex;
		rightIndex--;
		if (rightIndex < 0) {
			rightIndex = layers.Length - 1;
		}
	}

	private void ScrollRight(){
		int lastLeft = leftIndex;
		layers [leftIndex].position = Vector2.right * (layers [rightIndex].position.x + backgroundSize);
		rightIndex = leftIndex;
		leftIndex++;
		if (leftIndex == layers.Length) {
			leftIndex = 0;
		}

	}
}
