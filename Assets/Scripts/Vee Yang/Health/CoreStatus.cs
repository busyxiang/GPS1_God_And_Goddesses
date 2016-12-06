using UnityEngine;
using System.Collections;

public class CoreStatus : MonoBehaviour {

	public Transform child1;
	public Transform child2;

	// Use this for initialization
	void Start () {
		child1 = this.gameObject.transform.GetChild(1);
		child2 = this.gameObject.transform.GetChild(2);
		child1.GetComponent<SpriteRenderer>().enabled = false;
		child2.GetComponent<SpriteRenderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
	void OnMouseEnter()
	{
		child1.GetComponent<SpriteRenderer>().enabled = true;
		child2.GetComponent<SpriteRenderer>().enabled = true;
	}
	void OnMouseExit()
	{
		child1.GetComponent<SpriteRenderer>().enabled = false;
		child2.GetComponent<SpriteRenderer>().enabled = false;
	}

}
