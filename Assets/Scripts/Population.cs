using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Population : MonoBehaviour {

	// Population settings variables
	public bool fixedPopulation = false;
	public int populationSizeInitial = 300;
	public int populationSizeCurrent = 0;
	public int generation = 0;
	public int generationMax = 30;

	// Stats settings vairables
	public float newGenerationTime = 0.5f;
	public float rateOfMutation = 0.04f;
	public float environmentChangeTime = 10f;
	public float minFixedFitness = 0.5f;

	// Gameobjecs
	public GameObject environment;
	public GameObject bunnyPrefab;
	GameObject holder;
	
	// BunnyList
	protected List<Bunny> population = new List<Bunny>();

	public int p90 = 0, p75 = 0, p55 = 0, p30 = 0, p0 = 0;
	float magnitude;
	public int magnitudePercent;

	public Color minFitnessColor, maxFitnessColor, averageColor, environmentColor;
	Bounds boundaries;

	void Awake() {
		holder = new GameObject("Holder");
		boundaries = environment.GetComponent<Renderer>().bounds;
	
		Init();
	}

	public void Init() {
		// Parsing settings parameters given in Main scene
		if(!bool.TryParse(Scenes.getParam("PopulationFixed"), out fixedPopulation)) fixedPopulation = false;
		if(!float.TryParse(Scenes.getParam("MinFitness"), out minFixedFitness)) minFixedFitness = 0.5f;
		if(!Int32.TryParse(Scenes.getParam("PopulationSize"), out populationSizeInitial)) populationSizeInitial = 300;
		if(!Int32.TryParse(Scenes.getParam("GenAmount"), out generationMax)) generationMax = 5;
		if(!float.TryParse(Scenes.getParam("NewGenTime"), out newGenerationTime)) newGenerationTime = 0.5f;
		if(!float.TryParse(Scenes.getParam("RateOfMutation"), out rateOfMutation))	rateOfMutation = 0.04f;
		if(!float.TryParse(Scenes.getParam("EnvChangeTime"), out environmentChangeTime)) environmentChangeTime = 3;

		populationSizeCurrent = populationSizeInitial;

		for(int i = 0; i < populationSizeInitial; i++) {
			Bunny bunny = CreateBunny(boundaries);
			population.Add(bunny);
		}

		StartCoroutine(EvaluationLoop());
	}

	void LateUpdate() {
		environmentColor = GameObject.Find("Environment").GetComponent<MeshRenderer>().material.color;
		magnitude = (1 - EvaluateFitness(averageColor, environmentColor)) * 100;
		Int32.TryParse(String.Format("{0:0}", magnitude), out magnitudePercent);
	}

	void Update() {
		if(generation == generationMax && Values.testing) {
			if(Values.testingMMO == "min"){
				Values.minPop += populationSizeCurrent;
			}
			if(Values.testingMMO == "max"){
				Values.maxPop += populationSizeCurrent;
			}
			if(Values.testingMMO == "opt"){
				Values.optPop += populationSizeCurrent;
			}
			Scenes.Load("Main");
		}
	}

	public Bunny CreateBunny(Bounds bounds) {
		Vector3 randomPosition = new Vector3(UnityEngine.Random.Range(-0.5f, 0.5f) * bounds.size.x,
											 UnityEngine.Random.Range(-0.5f, 0.5f) * bounds.size.y,
											 UnityEngine.Random.Range(-0.5f, 0.5f) * bounds.size.z);

		Vector3 worldPosition = environment.transform.position + randomPosition;

		GameObject temp = Instantiate(bunnyPrefab, holder.transform);

		Bunny bunny = temp.AddComponent<Bunny>();

		float height = temp.GetComponent<MeshFilter>().mesh.bounds.size.y;

		worldPosition.y += height / 2.0f;

		temp.transform.position = worldPosition;

		AssignRandomColor(temp);

		return bunny;
	}

	public void AssignRandomColor(GameObject bunny) {
		bunny.GetComponent<Bunny>().SetColor(new Color(UnityEngine.Random.Range(0.0f, 1.0f),
													   UnityEngine.Random.Range(0.0f, 1.0f),
													   UnityEngine.Random.Range(0.0f, 1.0f)));
	}

	float EvaluateFitness(Color environment, Color bunny) {
		float fitness = (new Vector3(environment.r, environment.g, environment.b) 
					   - new Vector3(bunny.r, bunny.g, bunny.b)).magnitude;

		return fitness;
	}

	void EvaluatePopulation(bool fixedsize) {
		
		Vector3 zero = new Vector3(0,0,0);

		float minFitness = 1f;
		float maxFitness = 0f;

		p90 = 0;
		p75 = 0;
		p55 = 0;
		p30 = 0;
		p0 = 0;

		for(int i = 0; i < population.Count; i++) {

			Color thisColor = population[i].GetComponent<MeshRenderer>().material.color;

			float fitness = EvaluateFitness(environment.GetComponent<MeshRenderer>().material.color, 
											thisColor);

			if(fitness < minFitness) {
				minFitness = fitness;
				minFitnessColor = thisColor;
			}

			if(fitness > maxFitness) {
				maxFitness = fitness;
				maxFitnessColor = thisColor;
			}

			if(1 - fitness > 0.90f){
				p90++;
			} else if(1 - fitness > 0.75f){
				p75++;
			} else if(1 - fitness > 0.55f){
				p55++;
			} else if(1 - fitness > 0.30f){
				p30++;
			} else {
				p0++;
			}

			zero += new Vector3(thisColor.r, thisColor.g, thisColor.b);

			population[i].fitnessScore = fitness;
		}

		zero /= population.Count;

		averageColor = new Color(zero.x, zero.y, zero.z); 

		// Sort
		population.Sort( 
			delegate(Bunny bunny1, Bunny bunny2) {
				if(bunny1.fitnessScore > bunny2.fitnessScore)
					return 1;
				else if(bunny1.fitnessScore == bunny2.fitnessScore)
					return 0;
				else
					return -1;
			}
		);

		// Kill some bunnies
		int halfwayMark = (int) population.Count / 2;
		if(!fixedsize) {	
			for(int i = 0; i < population.Count; i++){
				if(population[i].fitnessScore >= minFixedFitness){
					halfwayMark = i;
					break;
				}
			}	 
		}

		if(halfwayMark % 2 != 0)
			halfwayMark++;

		for(int i = halfwayMark; i < population.Count; i++){
			Destroy(population[i].gameObject);
			population[i] = null;
		}

		population.RemoveRange(halfwayMark, population.Count - halfwayMark);

		// Breed
		Breed();

		populationSizeCurrent = population.Count;
	}

	void Breed() {

		// New babies List
		List<Bunny> tempList = new List<Bunny>();

		for(int i = 1; i < population.Count; i+=2) {
			int breeder1Index = i - 1;
			int breeder2Index = i;

			float howGenesAreSplit = UnityEngine.Random.Range(0.0f, 1.0f);

			Bounds bounds = environment.GetComponent<Renderer>().bounds;

			Bunny childBunny1 = CreateBunny(bounds);
			Bunny childBunny2 = CreateBunny(bounds);

			tempList.Add(childBunny1);
			tempList.Add(childBunny2);

			if(howGenesAreSplit < 0.16f) {
				Color tempColor = new Color(population[breeder1Index].color.r, 
											population[breeder1Index].color.g,
											population[breeder2Index].color.b);

				tempColor = EvaluateMutation(tempColor);

				childBunny1.SetColor(tempColor);

				tempColor = new Color(population[breeder2Index].color.r, 
											population[breeder2Index].color.g,
											population[breeder1Index].color.b);

				tempColor = EvaluateMutation(tempColor);

				childBunny2.SetColor(tempColor);

			} else if (howGenesAreSplit < 0.32f) {
				Color tempColor = new Color(population[breeder1Index].color.r, 
											population[breeder2Index].color.g,
											population[breeder1Index].color.b);

				tempColor = EvaluateMutation(tempColor);

				childBunny1.SetColor(tempColor);

				tempColor = new Color(population[breeder2Index].color.r, 
											population[breeder1Index].color.g,
											population[breeder2Index].color.b);

				tempColor = EvaluateMutation(tempColor);

				childBunny2.SetColor(tempColor);

			} else if (howGenesAreSplit < 0.48f) {
				Color tempColor = new Color(population[breeder1Index].color.r, 
											population[breeder2Index].color.g,
											population[breeder2Index].color.b);

				tempColor = EvaluateMutation(tempColor);

				childBunny1.SetColor(tempColor);

				tempColor = new Color(population[breeder2Index].color.r, 
											population[breeder1Index].color.g,
											population[breeder1Index].color.b);

				tempColor = EvaluateMutation(tempColor);

				childBunny2.SetColor(tempColor);

			} else if (howGenesAreSplit < 0.64f) {
				Color tempColor = new Color(population[breeder2Index].color.r, 
											population[breeder1Index].color.g,
											population[breeder1Index].color.b);

				tempColor = EvaluateMutation(tempColor);

				childBunny1.SetColor(tempColor);

				tempColor = new Color(population[breeder1Index].color.r, 
											population[breeder2Index].color.g,
											population[breeder2Index].color.b);

				tempColor = EvaluateMutation(tempColor);

				childBunny2.SetColor(tempColor);

			} else if (howGenesAreSplit < 0.80f) {
				Color tempColor = new Color(population[breeder2Index].color.r, 
											population[breeder2Index].color.g,
											population[breeder1Index].color.b);

				tempColor = EvaluateMutation(tempColor);

				childBunny1.SetColor(tempColor);

				tempColor = new Color(population[breeder1Index].color.r, 
											population[breeder1Index].color.g,
											population[breeder2Index].color.b);

				tempColor = EvaluateMutation(tempColor);

				childBunny2.SetColor(tempColor);

			} else {
				Color tempColor = new Color(population[breeder2Index].color.r, 
											population[breeder1Index].color.g,
											population[breeder2Index].color.b);

				tempColor = EvaluateMutation(tempColor);

				childBunny1.SetColor(tempColor);

				tempColor = new Color(population[breeder1Index].color.r, 
											population[breeder2Index].color.g,
											population[breeder1Index].color.b);

				tempColor = EvaluateMutation(tempColor);

				childBunny2.SetColor(tempColor);
			}
		}

		population.AddRange(tempList);
	}

	public Color EvaluateMutation(Color bunny) {

		Vector3 mutatedColor = new Vector3(bunny.r, bunny.g, bunny.b);

		for(int i = 0; i < 3; i++) {
			if(UnityEngine.Random.Range(0.0f, 1.0f) <= rateOfMutation) {
				mutatedColor[i] = UnityEngine.Random.Range(0.0f, 1.0f);
			}
		}

		return new Color(mutatedColor.x, mutatedColor.y, mutatedColor.z);
	}

	IEnumerator EvaluationLoop() {
		while(generation < generationMax) {
			yield return new WaitForSeconds(newGenerationTime);
			generation++;
			EvaluatePopulation(fixedPopulation);
		}
	}
}
