using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunny : MonoBehaviour {

	public float fitnessScore = 1.0f;
	public Color color = new Color(1.0f,1.0f,1.0f);
	public Material material;

	void Awake () {
		material = gameObject.GetComponent<Renderer>().material;
	}

	public void SetColor(Color color){
		this.color = color;
		material.color = color;
	}
}
