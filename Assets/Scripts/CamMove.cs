using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CamMove : MonoBehaviour {

	Camera camera;
	Transform camtrans;

	void Start () {
		camera = gameObject.GetComponent<Camera>();
		camtrans = gameObject.transform;
	}
	
	void Update () {
		float inpscroll = Input.GetAxis("Mouse ScrollWheel");
		int scrollval = (int) Math.Abs(inpscroll / 0.1f);

		if(inpscroll > 0) {
			camtrans.position *= (float) Math.Pow(1.05f, scrollval);
		}
		if(inpscroll < 0) {
			camtrans.position *= (float) Math.Pow(0.95f, scrollval);
		}	
	}
}
