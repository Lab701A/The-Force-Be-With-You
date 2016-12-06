using UnityEngine;
using System.Collections;

public class PickupObject : MonoBehaviour {
	GameObject mainCamera;
	bool carrying;
	GameObject carriedObject;
	public float distance;
	public float smooth;
	// Mindwave
	mind mindObject;
	int blink = 0;
	// Use this for initialization
	void Start () {
		mainCamera = GameObject.FindWithTag ("MainCamera");
		mindObject = GameObject.Find ("Mind").GetComponent<mind> ();
		blink = mindObject.Blink;
	}
	
	// Update is called once per frame
	void Update () {
		if (carrying) {
			carry (carriedObject);
			checkDrop ();
		} else {
			pickup ();
		}
	}

	void carry(GameObject o) {
		// Use Vector3.Lerp to move smoothly
		//o.transform.position = mainCamera.transform.position + mainCamera.transform.forward * distance;
		o.transform.position = Vector3.Lerp(o.transform.position, mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime * smooth);
	}

	void checkDrop() {
		if (Input.GetKeyDown (KeyCode.E) || mindObject.Blink != blink) {
			dropObject ();
			blink = mindObject.Blink;
		}
	}

	void dropObject() {
		carrying = false;
		carriedObject.GetComponent<Rigidbody>().isKinematic = false;
		carriedObject = null;
	}

	void pickup() {
		if (Input.GetKeyDown (KeyCode.E) || mindObject.Blink != blink) {
			int x = Screen.width / 2;
			int y = Screen.height / 2;

			Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay (new Vector3 (x, y));
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit)) {
				Pickupable p = hit.collider.GetComponent<Pickupable>();
				if(p != null) {
					carrying = true;
					carriedObject = p.gameObject;
					p.gameObject.GetComponent<Rigidbody>().isKinematic = true;
				}
			}
			blink = mindObject.Blink;
		}
	}
}
