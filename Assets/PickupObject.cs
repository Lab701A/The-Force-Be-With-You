using UnityEngine;
using System.Collections;

public class PickupObject : MonoBehaviour {
	GameObject mainCamera;
	public bool carrying;
	GameObject carriedObject;
	public float distance;
	public float smooth;
	public int rotateSpeed;
	// Mindwave
	mind mindObject;

	// Use this for initialization
	void Start () {
		mainCamera = GameObject.FindWithTag ("MainCamera");
		mindObject = GameObject.Find ("Mind").GetComponent<mind> ();
	}

	// Update is called once per frame
	void Update () {
		if (carrying) {
			carry (carriedObject);
			rotate (carriedObject);
		}
	}

	void carry(GameObject o) {
		// Use Vector3.Lerp to move smoothly
		//o.transform.position = mainCamera.transform.position + mainCamera.transform.forward * distance;
		o.transform.position = Vector3.Lerp(o.transform.position, mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime * smooth);
	}

	public void dropObject() {
		carrying = false;
		carriedObject.GetComponent<Rigidbody>().isKinematic = false;
		carriedObject = null;
	}

	public void pickup(GameObject o) {
		carrying = true;
		carriedObject = o;
		o.GetComponent<Rigidbody>().isKinematic = true;
	}

	public void rotate(GameObject o) {
		if (mindObject.poorSignal == 0 && mindObject.medit > 50) {
			// Rotate
			rotateSpeed = mindObject.medit;
			o.transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed, Space.World);
		} else {
			// Stop
		}
	}
}
