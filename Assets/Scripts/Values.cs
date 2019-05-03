using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Values {

	public static string testingString = null;
	public static string testingMMO = null;
	public static bool testing = false;

	//public static List<int> testPopSizeFinalList = new List<int>();
	
	public static float minFitnessMin = 0.05f;
	public static float minFitnessMax = 0.5f;
	public static float minFitnessOptimal = 0.3f;

	public static float newGenTimeMin = 0.05f;
	public static float newGenTimeMax = 0.2f;
	public static float newGenTimeOptimal = 0.10f;

	public static float rateOfMutationMin = 0;
	public static float rateOfMutationMax = 50;
	public static float rateOfMutationOptimal = 3;

	public static float envChangeTimeMin = 0.25f;
	public static float envChangeTimeMax = 1;
	public static float envChangeTimeOptimal = 0.5f;

	public static int minFitnessTestCount = 10,
			   		  newGenTimeTestCount = 10,
			          rateOfMutationTestCount = 0,
			          envChangeTimeTestCount = 0;

	public static int minTestCount = 0,
			   		  maxTestCount = 0,
			   		  optTestCount = 0;

	public static int minPop = 0,
					  maxPop = 0,
					  optPop = 0;

	public static void Reset(){
		ResetMinFitness();
		ResetNewGenTime();
		ResetRateOfMutation();
		ResetEnvChangeTime();
	}

	public static void ResetMinFitness() {
		minFitnessMin = 0;
 		minFitnessMax = 0.5f;
	}

	public static void ResetNewGenTime() {
		newGenTimeMin = 0.05f;
 		newGenTimeMax = 5;
	}

	public static void ResetRateOfMutation() {
		rateOfMutationMin = 0;
		rateOfMutationMax = 50;
	}

	public static void ResetEnvChangeTime() {
		envChangeTimeMin = 0.5f;
		envChangeTimeMax = 10;
	}

	public static bool ToBool(string aText) {
        return aText == "true" || aText == "on" || aText == "yes";
    }
}
