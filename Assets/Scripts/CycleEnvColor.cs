using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleEnvColor : MonoBehaviour {

	Material environmentMaterial;
	float colorTransitionTime;

	void Start () {
		colorTransitionTime = GameObject.Find("PopulationManager").GetComponent<Population>().environmentChangeTime;
		environmentMaterial = GameObject.Find("Environment").GetComponent<Renderer>().material;
		StartCoroutine(CycleColors());
	}

	IEnumerator CycleColors() {
 
		Vector3 previousColor = new Vector3(environmentMaterial.color.r,
											environmentMaterial.color.g,
											environmentMaterial.color.b);
		
		Vector3 currentColor = previousColor;

		while(true) {
			Vector3 newColor = new Vector3(UnityEngine.Random.Range(0.0f, 1.0f),
										   UnityEngine.Random.Range(0.0f, 1.0f),
										   UnityEngine.Random.Range(0.0f, 1.0f));

			Vector3 deltaColor = (newColor - previousColor) * (1.0f / colorTransitionTime);

			while(true) {
				currentColor = currentColor + deltaColor * Time.deltaTime;
				environmentMaterial.color = new Color(currentColor.x,
												currentColor.y, 
												currentColor.z);

				yield return null;
			}

			previousColor = newColor;
		}
	}
}
