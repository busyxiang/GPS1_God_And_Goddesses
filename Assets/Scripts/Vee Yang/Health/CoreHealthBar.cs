using UnityEngine;
using System.Collections;

public class CoreHealthBar : MonoBehaviour {
	
	private float OriginalScale ;

	// Use this for initialization
	void Start () 
	{
		OriginalScale = gameObject.transform.localScale.x;
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 tmpScale = gameObject.transform.localScale;
		tmpScale.x = GetComponentInParent<CoreHealth>().healthMin/GetComponentInParent<CoreHealth>().healthMax * OriginalScale;
		gameObject.transform.localScale = tmpScale;
	}
}
