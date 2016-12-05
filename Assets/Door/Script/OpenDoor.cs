using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour, IGvrGazeResponder {

	Animator _animator;
	mind mindObject;
    int blink = 0;
    public bool isLookingAt = false;
	public bool isOpen = false;

	// Use this for initialization
	void Start () {
		_animator = gameObject.GetComponentInParent<Animator> ();
		mindObject = GameObject.Find ("Mind").GetComponent<mind> ();
		blink = mindObject.Blink;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.isLookingAt) {
            if (mindObject.Blink != blink)
            {
				this.isOpen = !_animator.GetBool("isopen");
				_animator.SetBool ("isopen", this.isOpen);
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
