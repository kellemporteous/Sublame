using UnityEngine;
using System.Collections;

public class MovingEnemy : MonoBehaviour {
	public GameObject StartPoint;
	public GameObject EndPoint;

	public float TravelTime = 5.0f;
	private bool MovingStartToEnd = true;
	private float CurrentTime = 0.0f;


	void Start () {

		// Turn off the mesh renderer on the start and end point
		StartPoint.GetComponent<MeshRenderer> ().enabled = false;
		EndPoint.GetComponent<MeshRenderer> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

		// retrieve our start and end location
		Vector3 startLocation = StartPoint.transform.position;
		Vector3 endLocation = EndPoint.transform.position;

		// Update the time and check if we've reached the end
		CurrentTime += Time.deltaTime;
		if (CurrentTime >= TravelTime) {
			// Reset current time
			CurrentTime = 0;

			// Flip MovingStartToEnd
			MovingStartToEnd = !MovingStartToEnd;
		}

		// work out our travel % (ie. progress)
		float progress = CurrentTime / TravelTime;

		// Smooth out the progress value
		progress = (1.0f - Mathf.Cos (progress * Mathf.PI)) / 2.0f;

		// work out the new location
		Vector3 newLocation = Vector3.Lerp (startLocation, endLocation, 
		                                    MovingStartToEnd ? progress : (1.0f - progress));

		// Apply the new location
		transform.position = newLocation;
	}
}



