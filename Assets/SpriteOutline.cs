using UnityEngine;

[ExecuteInEditMode]
public class SpriteOutline : MonoBehaviour 
{
	//test
	public Color color = Color.white;

	[Range(0, 16)]
	public int outlineSize = 1;

	public SpriteRenderer spriteRenderer;

	public Material outlineMaterial;

	void OnEnable() 
	{
		spriteRenderer = GetComponentInChildren<SpriteRenderer>();

		for(int i=0; i<transform.childCount; i++)
		{
			transform.GetChild(i).GetComponent<SpriteRenderer>().material = outlineMaterial;
		}

		UpdateOutline(true);
	}

	void OnDisable() 
	{
		UpdateOutline(false);
	}

	void Update() 
	{
		UpdateOutline(true);
	}

	void UpdateOutline(bool outline) 
	{
		MaterialPropertyBlock mpb = new MaterialPropertyBlock();
		spriteRenderer.GetPropertyBlock(mpb);
		mpb.SetFloat("_Outline", outline ? 1f : 0);
		mpb.SetColor("_OutlineColor", color);
		mpb.SetFloat("_OutlineSize", outlineSize);
		spriteRenderer.SetPropertyBlock(mpb);
	}

	void OnMouseOver()
	{
		if(GUIManagerScript.Instance.selectedGO != this.gameObject)
		{
			color = Color.green;
			color.a = 255;
		}
	}

	void OnMouseExit()
	{
		color.a = 0;
	}
}
