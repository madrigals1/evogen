using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MainUI : MonoBehaviour {

	Text EvoSimText, PopulationFixedText, MinFitnessText,
	     PopulationSizeText, GenAmountText,
		 NewGenTimeText, RateOfMutationText, EnvChangeTimeText;
	InputField PopulationSizeIF, GenAmountIF, MinFitnessIF,
		 	   NewGenTimeIF, RateOfMutationIF, EnvChangeTimeIF;
	Toggle PopulationFixedTG;

	int PopulationSize, GenAmount;
	float MinFitness, NewGenTime, RateOfMutation, EnvChangeTime;
	bool PopulationFixed;

	Button BtnRun, BtnTest;

	void Start () {
		EvoSimText = GameObject.Find("EvoSimText").GetComponent<Text>();
		PopulationFixedText = GameObject.Find("PopulationFixedText").GetComponent<Text>();
		MinFitnessText = GameObject.Find("MinFitnessText").GetComponent<Text>();
		PopulationSizeText = GameObject.Find("PopulationSizeText").GetComponent<Text>();
		GenAmountText = GameObject.Find("GenAmountText").GetComponent<Text>();
		NewGenTimeText = GameObject.Find("NewGenTimeText").GetComponent<Text>();
		RateOfMutationText = GameObject.Find("RateOfMutationText").GetComponent<Text>();
		EnvChangeTimeText = GameObject.Find("EnvChangeTimeText").GetComponent<Text>();

		PopulationFixedTG = GameObject.Find("PopulationFixedTG").GetComponent<Toggle>();
		MinFitnessIF = GameObject.Find("MinFitnessIF").GetComponent<InputField>();
		PopulationSizeIF = GameObject.Find("PopulationSizeIF").GetComponent<InputField>();
		GenAmountIF = GameObject.Find("GenAmountIF").GetComponent<InputField>();
		NewGenTimeIF = GameObject.Find("NewGenTimeIF").GetComponent<InputField>();
		RateOfMutationIF = GameObject.Find("RateOfMutationIF").GetComponent<InputField>();
		EnvChangeTimeIF = GameObject.Find("EnvChangeTimeIF").GetComponent<InputField>();

		MinFitnessIF.placeholder.GetComponent<Text>().text = "min:0.0 & max:0.5";
		PopulationSizeIF.placeholder.GetComponent<Text>().text = "min:2 & max:1000";
		GenAmountIF.placeholder.GetComponent<Text>().text = "min:10 & max:100";
		NewGenTimeIF.placeholder.GetComponent<Text>().text = "min:0.05 & max:5";
		RateOfMutationIF.placeholder.GetComponent<Text>().text = "min:0 & max:50 & blank:nomutation";
		EnvChangeTimeIF.placeholder.GetComponent<Text>().text = "min:0.5 & max:100";
		
		BtnRun = GameObject.Find("BtnRun").GetComponent<Button>();
		BtnTest = GameObject.Find("BtnTest").GetComponent<Button>();

		BtnTest.onClick.AddListener(BtnTestPressed);
		BtnRun.onClick.AddListener(BtnRunPressed);

		if(Values.testing) {
			BtnTestPressed();
		}
		
		SetStrings();
	}

	void BtnRunPressed() {

		PopulationFixed = PopulationFixedTG.isOn;
		Int32.TryParse(PopulationSizeIF.text, out PopulationSize);
		Int32.TryParse(GenAmountIF.text, out GenAmount);
		float.TryParse(MinFitnessIF.text, out MinFitness);
		float.TryParse(NewGenTimeIF.text, out NewGenTime);
		float.TryParse(RateOfMutationIF.text, out RateOfMutation);
		float.TryParse(EnvChangeTimeIF.text, out EnvChangeTime);

		// PopulationSize = Int32.Parse(PopulationSizeIF.text);
		// GenAmount = Int32.Parse(GenAmountIF.text);
		// NewGenTime = float.Parse(NewGenTimeIF.text);
		// RateOfMutation = float.Parse(RateOfMutationIF.text);
		// EnvChangeTime = float.Parse(EnvChangeTimeIF.text);

		if(MinFitness < 0 || MinFitness > 0.5f || MinFitness == null) {
			MakeGOred(ref MinFitnessIF);
		} else if(PopulationSize < 2 || PopulationSize > 1000 || PopulationSize == null) {
			MakeGOred(ref PopulationSizeIF);
		} else if(GenAmount < 10 || GenAmount > 100 || GenAmount == null) {
			MakeGOred(ref GenAmountIF);
		} else if(NewGenTime < 0.05f || NewGenTime > 5 || NewGenTime == null) {
			MakeGOred(ref NewGenTimeIF);
		} else if(RateOfMutation < 0 || RateOfMutation > 50 || RateOfMutation == null) {
			MakeGOred(ref RateOfMutationIF);
		} else if(EnvChangeTime < 0.5f || EnvChangeTime > 100 || EnvChangeTime == null) {
			MakeGOred(ref EnvChangeTimeIF);
		} else {
			Dictionary<string, string> arguments = new Dictionary<string, string>();
			arguments.Add("PopulationFixed", "" + PopulationFixed);
			arguments.Add("MinFitness", "" + MinFitness);
			arguments.Add("PopulationSize", "" + PopulationSize);
			arguments.Add("GenAmount", "" + GenAmount );
			arguments.Add("NewGenTime", "" + NewGenTime);
			arguments.Add("RateOfMutation", "" + RateOfMutation/100);
			arguments.Add("EnvChangeTime", "" + EnvChangeTime);
			Scenes.Load("EvoSim", arguments);
		}

		if(!(MinFitness < 0 || MinFitness > 1 || MinFitness == null)) {
			MakeGOwhite(ref MinFitnessIF);
		}
		if(!(PopulationSize < 2 || PopulationSize > 1000 || PopulationSize == null)) {
			MakeGOwhite(ref PopulationSizeIF);
		}
		if(!(GenAmount < 10 || GenAmount > 100 || GenAmount == null)) {
			MakeGOwhite(ref GenAmountIF);
		}
		if(!(NewGenTime < 0.05f || NewGenTime > 5 || NewGenTime == null)) {
			MakeGOwhite(ref NewGenTimeIF);
		}
		if(!(RateOfMutation < 0 || RateOfMutation > 50 || RateOfMutation == null)) {
			MakeGOwhite(ref RateOfMutationIF);
		}
		if(!(EnvChangeTime < 0.5f || EnvChangeTime > 100 || EnvChangeTime == null)) {
			MakeGOwhite(ref EnvChangeTimeIF);
		}

		// Debug.Log("PopulationSize :" + PopulationSize);
		// Debug.Log("GenAmount :" + GenAmount);
		// Debug.Log("NewGenTime :" + NewGenTime);
		// Debug.Log("RateOfMutation :" + RateOfMutation);
		// Debug.Log("EnvChangeTime :" + EnvChangeTime);
	}

	public void BtnTestPressed() {
		Values.testing = true;

		if(Values.minFitnessTestCount < 10){
			Values.testingString = "minFitness";
			if(Values.minTestCount < 10 || Values.maxTestCount < 10 || Values.optTestCount < 10){
				NeuralNet.Test();
			} else {
				Values.minFitnessTestCount++;
				NeuralNet.ChangeValues();
				NeuralNet.Test();
			}
		} else if(Values.newGenTimeTestCount < 10){
			Values.newGenTimeTestCount++;
			Values.testingString = "newGenTime";
			if(Values.minTestCount < 10 || Values.maxTestCount < 10 || Values.optTestCount < 10){
				NeuralNet.Test();
			} else {
				Values.newGenTimeTestCount++;
				NeuralNet.ChangeValues();
				NeuralNet.Test();
			}
		} else if(Values.rateOfMutationTestCount < 10){
			Values.rateOfMutationTestCount++;
			Values.testingString = "rateOfMutation";
			if(Values.minTestCount < 10 || Values.maxTestCount < 10 || Values.optTestCount < 10){
				NeuralNet.Test();
			} else {
				Values.rateOfMutationTestCount++;
				NeuralNet.ChangeValues();
				NeuralNet.Test();
			}
		} else if(Values.envChangeTimeTestCount < 10){
			Values.envChangeTimeTestCount++;
			Values.testingString = "envChangeTime";
			if(Values.minTestCount < 10 || Values.maxTestCount < 10 || Values.optTestCount < 10){
				NeuralNet.Test();
			} else {
				Values.envChangeTimeTestCount++;
				NeuralNet.ChangeValues();
				NeuralNet.Test();
			}
		}
	}

	void SetStrings() {
		EvoSimText.text = LanguageSetter.MainStrings.title;
		PopulationFixedText.text = LanguageSetter.MainStrings.populationFixed;
		MinFitnessText.text = LanguageSetter.MainStrings.minFitness;
		PopulationSizeText .text = LanguageSetter.MainStrings.populationSize;
		GenAmountText.text = LanguageSetter.MainStrings.genAmount;
		NewGenTimeText.text = LanguageSetter.MainStrings.newGenTime;
		RateOfMutationText.text = LanguageSetter.MainStrings.rateOfMutation;
		EnvChangeTimeText.text = LanguageSetter.MainStrings.envChangeTime;
		BtnRun.transform.GetChild(0).GetComponent<Text>().text = LanguageSetter.MainStrings.run;
		BtnTest.transform.GetChild(0).GetComponent<Text>().text = LanguageSetter.MainStrings.test;
	}

	void MakeGOred(ref InputField go) {
		go.gameObject.GetComponent<Image>().color = new Color(1,0,0,0.5f);
		go.text = "";
	}

	void MakeGOwhite(ref InputField go) {
		go.gameObject.GetComponent<Image>().color = Color.white;
	}
}
