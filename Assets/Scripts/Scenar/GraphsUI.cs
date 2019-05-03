using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphsUI : MonoBehaviour {

	Dropdown ddX, ddY;
	List<string> dropOptions = new List<string>();

	void Start () {
		ddX = GameObject.Find("xPanel").transform.GetChild(1).GetComponent<Dropdown>();
		ddY = GameObject.Find("yPanel").transform.GetChild(1).GetComponent<Dropdown>();

		dropOptions.Add(LanguageSetter.MainStrings.minFitness);
		dropOptions.Add(LanguageSetter.MainStrings.populationSize);
		dropOptions.Add(LanguageSetter.MainStrings.genAmount);
		dropOptions.Add(LanguageSetter.MainStrings.newGenTime);
		dropOptions.Add(LanguageSetter.MainStrings.rateOfMutation);
		dropOptions.Add(LanguageSetter.MainStrings.envChangeTime);
		dropOptions.Add(LanguageSetter.GraphsStrings.populationSizeFinal);

		ddX.AddOptions(dropOptions);
		ddY.AddOptions(dropOptions);
	}
}
