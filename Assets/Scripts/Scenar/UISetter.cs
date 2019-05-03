using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISetter : MonoBehaviour {

	Text currentGenText, magnitudeText, othersText, bunnyAmountText;
	Image minFitnessImage, maxFitnessImage, averageColorImage, environmentColorImage;
	Text minFitnessText, maxFitnessText, averageColorText, environmentColorText;

	InputField p90, p75, p55, p30, p0;
	Population population;
	GameObject environment;

	Text ROPopulationFixedText, ROMinFitnessText, ROPopulationSizeText, ROGenAmountText, 
			   RONewGenTimeText, RORateOfMutationText, ROEnvChangeTimeText;

	InputField ROMinFitnessIF, ROPopulationSizeIF, ROGenAmountIF, 
			   RONewGenTimeIF, RORateOfMutationIF, ROEnvChangeTimeIF;

	Text minPop, maxPop, optPop;
	Text minPopCount, maxPopCount, optPopCount;

	Transform minPopPanel, maxPopPanel, optPopPanel;

	Toggle ROPopulationFixedTG;
	
	void Start () {
		population = GameObject.Find("PopulationManager").GetComponent<Population>();

		p90 = GameObject.Find("P90IF").GetComponent<InputField>();
		p75 = GameObject.Find("P75IF").GetComponent<InputField>();
		p55 = GameObject.Find("P55IF").GetComponent<InputField>();
		p30 = GameObject.Find("P30IF").GetComponent<InputField>();
		p0 = GameObject.Find("P0IF").GetComponent<InputField>();

		currentGenText = GameObject.FindWithTag("CurrentGen").GetComponent<Text>();
		magnitudeText = GameObject.Find("MagnitudeText").GetComponent<Text>();
		othersText = GameObject.Find("P0").GetComponent<Text>();
		bunnyAmountText = GameObject.Find("BunnyAmountText").GetComponent<Text>();

		minFitnessImage = GameObject.Find("MinFitness").GetComponent<Image>();
		maxFitnessImage = GameObject.Find("MaxFitness").GetComponent<Image>();
		averageColorImage = GameObject.Find("AverageColor").GetComponent<Image>();
		environmentColorImage = GameObject.Find("EnvironmentColor").GetComponent<Image>();

		minFitnessText = GameObject.Find("MinFitness").GetComponentInChildren<Text>();
		maxFitnessText = GameObject.Find("MaxFitness").GetComponentInChildren<Text>();
		averageColorText = GameObject.Find("AverageColor").GetComponentInChildren<Text>();
		environmentColorText = GameObject.Find("EnvironmentColor").GetComponentInChildren<Text>();

		ROPopulationFixedText = GameObject.Find("PopulationFixedText").GetComponent<Text>();
		ROMinFitnessText = GameObject.Find("ROMinFitnessText").GetComponent<Text>();
		ROPopulationSizeText = GameObject.Find("PopulationSizeText").GetComponent<Text>();
		ROGenAmountText = GameObject.Find("GenAmountText").GetComponent<Text>();
		RONewGenTimeText = GameObject.Find("NewGenTimeText").GetComponent<Text>();
		RORateOfMutationText = GameObject.Find("RateOfMutationText").GetComponent<Text>();
		ROEnvChangeTimeText = GameObject.Find("EnvChangeTimeText").GetComponent<Text>();
		
		environment = GameObject.Find("Environment");

		ROPopulationFixedTG = GameObject.Find("PopulationFixedTG").GetComponent<Toggle>();
		ROMinFitnessIF = GameObject.Find("MinFitnessIF").GetComponent<InputField>();
		ROPopulationSizeIF = GameObject.Find("PopulationSizeIF").GetComponent<InputField>();
		ROGenAmountIF = GameObject.Find("GenAmountIF").GetComponent<InputField>();
		RONewGenTimeIF = GameObject.Find("NewGenTimeIF").GetComponent<InputField>();
		RORateOfMutationIF = GameObject.Find("RateOfMutationIF").GetComponent<InputField>();
		ROEnvChangeTimeIF = GameObject.Find("EnvChangeTimeIF").GetComponent<InputField>();

		minPop = GameObject.Find("MinPop").GetComponent<Text>();
		maxPop = GameObject.Find("MaxPop").GetComponent<Text>();
		optPop = GameObject.Find("OptPop").GetComponent<Text>();

		minPopCount = GameObject.Find("MinPopCount").GetComponent<Text>();
		maxPopCount = GameObject.Find("MaxPopCount").GetComponent<Text>();
		optPopCount = GameObject.Find("OptPopCount").GetComponent<Text>();

		minPopPanel = GameObject.Find("MinPopPanel").transform;
		maxPopPanel = GameObject.Find("MaxPopPanel").transform;
		optPopPanel = GameObject.Find("OptPopPanel").transform;

		SetStrings();
	}
	
	void Update () {
		currentGenText.text = LanguageSetter.EvoSimStrings.generation + population.generation;
		magnitudeText.text = "" + population.magnitudePercent + "%";
		bunnyAmountText.text = "" + population.populationSizeCurrent;

		if(population.magnitudePercent >= 90){
			magnitudeText.color = new Color(0,1,0,1);
		} else if(population.magnitudePercent >= 75){
			magnitudeText.color = new Color(0.8f,1,0,1);
		} else if(population.magnitudePercent >= 55){
			magnitudeText.color = new Color(0.72f,0.61f,0,1);
		} else if(population.magnitudePercent >= 30){
			magnitudeText.color = new Color(0.72f,0.298f,0,1);
		} else {
			magnitudeText.color = new Color(1,0,0,1);
		}

		minFitnessImage.color = population.minFitnessColor;
		maxFitnessImage.color = population.maxFitnessColor;
		averageColorImage.color = population.averageColor;
		environmentColorImage.color = population.environmentColor;

		p90.text = "" + population.p90;
		p75.text = "" + population.p75;
		p55.text = "" + population.p55;
		p30.text = "" + population.p30;
		p0.text = "" + population.p0;

		minPop.text = "" + Values.minPop;
		maxPop.text = "" + Values.maxPop;
		optPop.text = "" + Values.optPop;

		minPopCount.text = "" + Values.minTestCount;
		maxPopCount.text = "" + Values.maxTestCount;
		optPopCount.text = "" + Values.optTestCount;

		if(Values.testingMMO == "min"){
			minPopPanel.GetChild(0).GetComponent<Image>().color = new Color(1,0,0,0.39f);
			minPopPanel.GetChild(1).GetComponent<Image>().color = new Color(1,0,0,0.39f);
		} else {
			minPopPanel.GetChild(0).GetComponent<Image>().color = new Color(1,1,1,0.39f);
			minPopPanel.GetChild(1).GetComponent<Image>().color = new Color(1,1,1,0.39f);
		}

		if(Values.testingMMO == "max"){
			maxPopPanel.GetChild(0).GetComponent<Image>().color = new Color(1,0,0,0.39f);
			maxPopPanel.GetChild(1).GetComponent<Image>().color = new Color(1,0,0,0.39f);
		} else {
			maxPopPanel.GetChild(0).GetComponent<Image>().color = new Color(1,1,1,0.39f);
			maxPopPanel.GetChild(1).GetComponent<Image>().color = new Color(1,1,1,0.39f);
		}

		if(Values.testingMMO == "opt"){
			optPopPanel.GetChild(0).GetComponent<Image>().color = new Color(1,0,0,0.39f);
			optPopPanel.GetChild(1).GetComponent<Image>().color = new Color(1,0,0,0.39f);
		} else {
			optPopPanel.GetChild(0).GetComponent<Image>().color = new Color(1,1,1,0.39f);
			optPopPanel.GetChild(1).GetComponent<Image>().color = new Color(1,1,1,0.39f);
		}
	}

	void SetStrings() {
		Debug.Log(Values.minFitnessTestCount);

		minFitnessText.text = LanguageSetter.EvoSimStrings.min;
		maxFitnessText.text = LanguageSetter.EvoSimStrings.max;
		averageColorText.text = LanguageSetter.EvoSimStrings.avg;
		environmentColorText.text = LanguageSetter.EvoSimStrings.env;
		othersText.text = LanguageSetter.EvoSimStrings.others;

		ROPopulationFixedText.text = LanguageSetter.MainStrings.populationFixed;
		ROMinFitnessText.text = LanguageSetter.MainStrings.minFitness;
		ROPopulationSizeText.text = LanguageSetter.MainStrings.populationSize;
		ROGenAmountText.text = LanguageSetter.MainStrings.genAmount;
		RONewGenTimeText.text = LanguageSetter.MainStrings.newGenTime;
		RORateOfMutationText.text = LanguageSetter.MainStrings.rateOfMutation;
		ROEnvChangeTimeText.text = LanguageSetter.MainStrings.envChangeTime;

		ROPopulationFixedTG.isOn = Values.ToBool(Scenes.getParam("PopulationFixed"));
		ROMinFitnessIF.text = "" + Scenes.getParam("MinFitness");
		ROPopulationSizeIF.text = "" + Scenes.getParam("PopulationSize");
		ROGenAmountIF.text = "" + Scenes.getParam("GenAmount");
		RONewGenTimeIF.text = "" + Scenes.getParam("NewGenTime");
		RORateOfMutationIF.text = "" + Scenes.getParam("RateOfMutation");
		ROEnvChangeTimeIF.text = "" + Scenes.getParam("EnvChangeTime");
	}
}
