using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LangUI : MonoBehaviour {

	Button btnEN, btnRU, btnKZ;

	void Start () {
		btnEN = GameObject.Find("btnEN").GetComponent<Button>();
		btnRU = GameObject.Find("btnRU").GetComponent<Button>();
		btnKZ = GameObject.Find("btnKZ").GetComponent<Button>();

		btnEN.onClick.AddListener(() => SetLanguage("en"));
		btnRU.onClick.AddListener(() => SetLanguage("ru"));
		btnKZ.onClick.AddListener(() => SetLanguage("kz"));
	}

	void SetLanguage(string lang) {
		LanguageSetter.SetLanguage(lang);
		Scenes.Load("Main", null);
	}
}
