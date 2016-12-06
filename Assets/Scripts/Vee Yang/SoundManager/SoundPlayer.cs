using UnityEngine;
using System.Collections;

public class SoundPlayer : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		SoundManagerScript.Instance.PlayLoopingBGM (AudioClipID.BGM_MAIN_MENU);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
