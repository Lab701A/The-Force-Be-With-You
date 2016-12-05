using UnityEngine;
using System.Collections;
using System;

public class LightController : MonoBehaviour, IGvrGazeResponder {

    Light[] lights;
    mind mindObject;
    public bool isLookingAt = false;
    public int blink = 0;


    // Use this for initialization
    void Start () {
        lights = gameObject.GetComponentsInChildren<Light>();
        mindObject = GameObject.Find("Mind").GetComponent<mind>();
    }
	
	// Update is called once per frame
	void Update () {
        if (this.isLookingAt)
        {
            if (mindObject.Blink != blink)
            {
                foreach(Light light in lights){
                    light.enabled = !light.enabled;
                }
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
        // Do nothing.
    }
}
