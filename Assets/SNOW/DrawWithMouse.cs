using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawWithMouse : MonoBehaviour {

	public Shader drawShader;

	[Range(1, 200)]
	public float brushSize = 10;
	[Range(0, 1)]
	public float brushStrength = 1;

	private RenderTexture splatmap;
	private Material snowMaterial, drawMaterial;

	private Camera viewCamera;
	private RaycastHit hit;


	// Use this for initialization
	void Start () {
		viewCamera = Camera.main;
		drawMaterial = new Material(drawShader);
		drawMaterial.SetVector("_Color", Color.red);

		snowMaterial = GetComponent<MeshRenderer>().material;
		splatmap = new RenderTexture(2048, 2048, 0, RenderTextureFormat.ARGBFloat);
		snowMaterial.SetTexture("_SplatMap", splatmap);
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetMouseButton(0)) {
			if (Physics.Raycast(viewCamera.ScreenPointToRay(Input.mousePosition), out hit)) {
				drawMaterial.SetVector("_Coordinate", new Vector4(hit.textureCoord.x, hit.textureCoord.y, 0, 0));
				drawMaterial.SetFloat("_BrushSize", brushSize);
				drawMaterial.SetFloat("_BrushStrength", brushStrength);
				RenderTexture temp = RenderTexture.GetTemporary(splatmap.height, splatmap.width, 0 , RenderTextureFormat.ARGBFloat);
				Graphics.Blit(splatmap, temp);
				Graphics.Blit(temp, splatmap, drawMaterial);
				RenderTexture.ReleaseTemporary(temp);
			}
		}
	}

	// private void OnGUI() {
	// 	GUI.DrawTexture(new Rect(0,0, 256, 256), splatmap, ScaleMode.ScaleToFit, false, 0);
	// }
}
