using UnityEngine;
using System.Collections;
using System;

public class ChangePic : MonoBehaviour, IGvrGazeResponder {

    private SpriteRenderer spriteRenderer;
    mind mindObject;
    int blink = 0;
    public bool isLookingAt = false;
    public bool isOpen = false;

    // Use this for initialization
    void Start () {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        mindObject = GameObject.Find("Mind").GetComponent<mind>();
    }
	
	// Update is called once per frame
	void Update () {
        if(this.isLookingAt) {
            if (mindObject.Blink != blink)
            {
                spriteRenderer.enabled = !this.isOpen;
                this.isOpen = !this.isOpen;
            }
            blink = mindObject.Blink;
        }
    }

    public void setGazeAt(bool lookingAt)
    {
        isLookingAt = lookingAt;
    }

    public void OnGazeEnter()
    {
        setGazeAt(true);
        blink = mindObject.Blink;
    }

    public void OnGazeExit()
    {
        setGazeAt(false);
    }

    public void OnGazeTrigger()
    {
        throw new NotImplementedException();
    }
}
