using UnityEngine;
using System.Collections;

public class Pickupable : MonoBehaviour, IGvrGazeResponder {
	// GvrGaze & Mindwave
	mind mindObject;
	public int blink = 0;
	public bool isLookingAt = false;
	//
	GameObject FPS;

	// Use this for initialization
	void Start () {
		// Mindwave
		mindObject = GameObject.Find ("Mind").GetComponent<mind> ();
		blink = mindObject.Blink;
		FPS = GameObject.Find ("FPSController");
	}

	// Update is called once per frame
	void Update () {
		if (this.isLookingAt) {
			if (mindObject.Blink != blink) // Has blinked
			{
				if (FPS.GetComponent<PickupObject>().carrying) {
					FPS.GetComponent<PickupObject>().dropObject ();
				} else {
					FPS.GetComponent<PickupObject> ().pickup (this.gameObject);
				}
			}
			blink = mindObject.Blink;
		}
	}

	public void setGazeAt(bool lookingAt){
		isLookingAt = lookingAt;
	}


	public void OnGazeEnter(){
		setGazeAt (true);
		blink = mindObject.Blink;
	}

	public void OnGazeExit(){
		setGazeAt (false);
	}

	public void OnGazeTrigger() {
	}
}
