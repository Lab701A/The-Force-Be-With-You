﻿using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class Autowalk : MonoBehaviour {
	private FirstPersonController controller;
	private mind neuroSky;

	// Use this for initialization
	void Start () {
		controller = GameObject.FindObjectOfType<FirstPersonController> ();
		neuroSky = GameObject.Find ("Mind").GetComponent<mind> ();
	}

	// Update is called once per frame
	void Update () {

		if (neuroSky.poorSignal == 0 && neuroSky.atten > 50 ) {
			// Speed Up
			controller.M_WalkSpeed = 2;
		} else {
			//else if(neuroSky.poorSignal == 0 && neuroSky.atten <= 50){
			// Slow Down
			controller.M_WalkSpeed = 0;
		}
	}

	void OnGUI(){
		GUILayout.BeginVertical();
		GUILayout.Space(Screen.height / 2);
		GUILayout.Label("Speed:" + controller.M_WalkSpeed);

		GUILayout.EndVertical();
	}
}
