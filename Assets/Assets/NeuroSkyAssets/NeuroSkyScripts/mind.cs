using UnityEngine;
using System.Collections;

public class mind : MonoBehaviour {

	public Texture2D[] signalIcons;
	private float indexSignalIcons = 1;
	private bool enableAnimation = false;
	private float animationInterval = 0.06f;

	ThinkGearController controller;

	public int poorSignal;
	public int atten;
	public int medit;
	public int Blink;

	// Use this for initialization
	void Start () {
		controller = GameObject.Find ("ThinkGear").GetComponent<ThinkGearController> ();

		controller.UpdatePoorSignalEvent += OnUpdatePoorSignal;
		controller.UpdateAttentionEvent += OnUpdateAttention;
		controller.UpdateMeditationEvent += OnUpdateMeditation;

		controller.UpdateBlinkEvent += OnUpdateBlink;

		UnityThinkGear.StartStream ();
	}

	void OnUpdatePoorSignal(int value) {
		poorSignal = value;
		if(value == 0){
			indexSignalIcons = 0;
			enableAnimation = false;
		}else if(value == 200){
			indexSignalIcons = 1;
			enableAnimation = false;
		}else if(!enableAnimation){
			indexSignalIcons = 2;
			enableAnimation = true;
		}
	}

	void OnUpdateAttention(int value) {
		atten = value;
	}

	void OnUpdateMeditation(int value) {
		medit = value;
	}

	void OnUpdateBlink(int value){
		Blink = value;
	}

	// Update is called once per frame
	void Update () {

	}

	/**
	 *when Fixed Timestep == 0.02 
	 **/
	void FixedUpdate(){
		if(enableAnimation){
			if(indexSignalIcons >= 4.8){
				indexSignalIcons = 2;
			}
			indexSignalIcons += animationInterval;
		}

	}

	void OnGUI(){
		GUILayout.BeginHorizontal ();
		GUILayout.Label ("Debug GUI");
		GUILayout.Space(Screen.width-250);
		GUILayout.Label(signalIcons[(int)indexSignalIcons]);
		GUILayout.EndHorizontal ();

		GUILayout.BeginVertical();
		GUILayout.Label("PoorSignal:" + poorSignal);
		GUILayout.Label("Attention:" + atten);
		GUILayout.Label("Meditation:" + medit);
		GUILayout.Label("Blink:" + Blink);

		GUILayout.EndVertical();
	}
}
