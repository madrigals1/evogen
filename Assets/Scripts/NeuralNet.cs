using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NeuralNet {
	
	public static void Test() {
		if(Values.minTestCount < 10){
			Values.testingMMO = "min";
			TestMin();
		} else if(Values.maxTestCount < 10){
			Values.testingMMO = "max";
			TestMax();
		} else if(Values.optTestCount < 10){
			Values.testingMMO = "opt";
			TestOpt();
		}
	}

	static void TestMin() {
		if(Values.testingString == "minFitness"){
			Values.minTestCount++;

			Dictionary<string, string> arguments = new Dictionary<string, string>();
			arguments.Add("PopulationFixed", "" + false);
			arguments.Add("MinFitness", "" + Values.minFitnessMin);
			arguments.Add("PopulationSize", "" + 750);
			arguments.Add("GenAmount", "" + 10);
			arguments.Add("NewGenTime", "" + Values.newGenTimeOptimal);
			arguments.Add("RateOfMutation", "" + Values.rateOfMutationOptimal);
			arguments.Add("EnvChangeTime", "" + Values.envChangeTimeOptimal);
			Scenes.Load("EvoSim", arguments);
		}

		if(Values.testingString == "newGenTime"){
			Values.minTestCount++;

			Dictionary<string, string> arguments = new Dictionary<string, string>();
			arguments.Add("PopulationFixed", "" + false);
			arguments.Add("MinFitness", "" + Values.minFitnessOptimal);
			arguments.Add("PopulationSize", "" + 750);
			arguments.Add("GenAmount", "" + 10);
			arguments.Add("NewGenTime", "" + Values.newGenTimeMin);
			arguments.Add("RateOfMutation", "" + Values.rateOfMutationOptimal);
			arguments.Add("EnvChangeTime", "" + Values.envChangeTimeOptimal);
			Scenes.Load("EvoSim", arguments);
		}

		if(Values.testingString == "rateOfMutation"){
			Values.minTestCount++;
			
			Dictionary<string, string> arguments = new Dictionary<string, string>();
			arguments.Add("PopulationFixed", "" + false);
			arguments.Add("MinFitness", "" + Values.minFitnessOptimal);
			arguments.Add("PopulationSize", "" + 750);
			arguments.Add("GenAmount", "" + 10);
			arguments.Add("NewGenTime", "" + Values.newGenTimeOptimal);
			arguments.Add("RateOfMutation", "" + Values.rateOfMutationMin);
			arguments.Add("EnvChangeTime", "" + Values.envChangeTimeOptimal);
			Scenes.Load("EvoSim", arguments);
		}

		if(Values.testingString == "envChangeTime"){
			Values.minTestCount++;
			
			Dictionary<string, string> arguments = new Dictionary<string, string>();
			arguments.Add("PopulationFixed", "" + false);
			arguments.Add("MinFitness", "" + Values.minFitnessOptimal);
			arguments.Add("PopulationSize", "" + 750);
			arguments.Add("GenAmount", "" + 10);
			arguments.Add("NewGenTime", "" + Values.newGenTimeOptimal);
			arguments.Add("RateOfMutation", "" + Values.rateOfMutationOptimal);
			arguments.Add("EnvChangeTime", "" + Values.envChangeTimeMin);
			Scenes.Load("EvoSim", arguments);
		}
	}

	static void TestMax() {
		if(Values.testingString == "minFitness"){
			Values.maxTestCount++;

			Dictionary<string, string> arguments = new Dictionary<string, string>();
			arguments.Add("PopulationFixed", "" + false);
			arguments.Add("MinFitness", "" + Values.minFitnessMax);
			arguments.Add("PopulationSize", "" + 750);
			arguments.Add("GenAmount", "" + 10);
			arguments.Add("NewGenTime", "" + Values.newGenTimeOptimal);
			arguments.Add("RateOfMutation", "" + Values.rateOfMutationOptimal);
			arguments.Add("EnvChangeTime", "" + Values.envChangeTimeOptimal);
			Scenes.Load("EvoSim", arguments);
		}

		if(Values.testingString == "newGenTime"){
			Values.maxTestCount++;

			Dictionary<string, string> arguments = new Dictionary<string, string>();
			arguments.Add("PopulationFixed", "" + false);
			arguments.Add("MinFitness", "" + Values.minFitnessOptimal);
			arguments.Add("PopulationSize", "" + 750);
			arguments.Add("GenAmount", "" + 10);
			arguments.Add("NewGenTime", "" + Values.newGenTimeMax);
			arguments.Add("RateOfMutation", "" + Values.rateOfMutationOptimal);
			arguments.Add("EnvChangeTime", "" + Values.envChangeTimeOptimal);
			Scenes.Load("EvoSim", arguments);
		}

		if(Values.testingString == "rateOfMutation"){
			Values.maxTestCount++;
			
			Dictionary<string, string> arguments = new Dictionary<string, string>();
			arguments.Add("PopulationFixed", "" + false);
			arguments.Add("MinFitness", "" + Values.minFitnessOptimal);
			arguments.Add("PopulationSize", "" + 750);
			arguments.Add("GenAmount", "" + 10);
			arguments.Add("NewGenTime", "" + Values.newGenTimeOptimal);
			arguments.Add("RateOfMutation", "" + Values.rateOfMutationMax);
			arguments.Add("EnvChangeTime", "" + Values.envChangeTimeOptimal);
			Scenes.Load("EvoSim", arguments);
		}

		if(Values.testingString == "envChangeTime"){
			Values.maxTestCount++;

			Dictionary<string, string> arguments = new Dictionary<string, string>();
			arguments.Add("PopulationFixed", "" + false);
			arguments.Add("MinFitness", "" + Values.minFitnessOptimal);
			arguments.Add("PopulationSize", "" + 750);
			arguments.Add("GenAmount", "" + 10);
			arguments.Add("NewGenTime", "" + Values.newGenTimeOptimal);
			arguments.Add("RateOfMutation", "" + Values.rateOfMutationOptimal);
			arguments.Add("EnvChangeTime", "" + Values.envChangeTimeMax);
			Scenes.Load("EvoSim", arguments);
		}
	}

	static void TestOpt() {
		if(Values.testingString == "minFitness"){
			Values.optTestCount++;

			Dictionary<string, string> arguments = new Dictionary<string, string>();
			arguments.Add("PopulationFixed", "" + false);
			arguments.Add("MinFitness", "" + Values.minFitnessOptimal);
			arguments.Add("PopulationSize", "" + 750);
			arguments.Add("GenAmount", "" + 10);
			arguments.Add("NewGenTime", "" + Values.newGenTimeOptimal);
			arguments.Add("RateOfMutation", "" + Values.rateOfMutationOptimal);
			arguments.Add("EnvChangeTime", "" + Values.envChangeTimeOptimal);
			Scenes.Load("EvoSim", arguments);
		}

		if(Values.testingString == "newGenTime"){
			Values.optTestCount++;

			Dictionary<string, string> arguments = new Dictionary<string, string>();
			arguments.Add("PopulationFixed", "" + false);
			arguments.Add("MinFitness", "" + Values.minFitnessOptimal);
			arguments.Add("PopulationSize", "" + 750);
			arguments.Add("GenAmount", "" + 10);
			arguments.Add("NewGenTime", "" + Values.newGenTimeOptimal);
			arguments.Add("RateOfMutation", "" + Values.rateOfMutationOptimal);
			arguments.Add("EnvChangeTime", "" + Values.envChangeTimeOptimal);
			Scenes.Load("EvoSim", arguments);
		}

		if(Values.testingString == "rateOfMutation"){
			Values.optTestCount++;

			Dictionary<string, string> arguments = new Dictionary<string, string>();
			arguments.Add("PopulationFixed", "" + false);
			arguments.Add("MinFitness", "" + Values.minFitnessOptimal);
			arguments.Add("PopulationSize", "" + 750);
			arguments.Add("GenAmount", "" + 10);
			arguments.Add("NewGenTime", "" + Values.newGenTimeOptimal);
			arguments.Add("RateOfMutation", "" + Values.rateOfMutationOptimal);
			arguments.Add("EnvChangeTime", "" + Values.envChangeTimeOptimal);
			Scenes.Load("EvoSim", arguments);
		}

		if(Values.testingString == "envChangeTime"){
			Values.optTestCount++;
			
			Dictionary<string, string> arguments = new Dictionary<string, string>();
			arguments.Add("PopulationFixed", "" + false);
			arguments.Add("MinFitness", "" + Values.minFitnessOptimal);
			arguments.Add("PopulationSize", "" + 750);
			arguments.Add("GenAmount", "" + 10);
			arguments.Add("NewGenTime", "" + Values.newGenTimeOptimal);
			arguments.Add("RateOfMutation", "" + Values.rateOfMutationOptimal);
			arguments.Add("EnvChangeTime", "" + Values.envChangeTimeOptimal);
			Scenes.Load("EvoSim", arguments);
		}
	}

	public static void ChangeValues() {
		Values.minTestCount = 0;
		Values.maxTestCount = 0;
		Values.optTestCount = 0;

		Values.minPop = 0;
		Values.maxPop = 0;
		Values.optPop = 0;

		if(Mathf.Abs(Values.minPop - Values.optPop) >= Mathf.Abs(Values.maxPop - Values.optPop)){
			if(Values.testingString == "minFitness"){
				Values.minFitnessMin = Values.minFitnessOptimal;
				Values.minFitnessOptimal = (Values.minFitnessOptimal + Values.minFitnessMax) / 2;
			}
			if(Values.testingString == "newGenTime"){
				Values.newGenTimeMin = Values.newGenTimeOptimal;
				Values.newGenTimeOptimal = (Values.newGenTimeOptimal + Values.newGenTimeMax) / 2;
			}
			if(Values.testingString == "rateOfMutation"){
				Values.rateOfMutationMin = Values.rateOfMutationOptimal;
				Values.rateOfMutationOptimal = (Values.rateOfMutationOptimal + Values.rateOfMutationMax) / 2;
			}
			if(Values.testingString == "envChangeTime"){
				Values.envChangeTimeMin = Values.envChangeTimeOptimal;
				Values.envChangeTimeOptimal = (Values.envChangeTimeOptimal + Values.envChangeTimeMax) / 2;
			}
		} else {
			if(Values.testingString == "minFitness"){
				Values.minFitnessMax = Values.minFitnessOptimal;
				Values.minFitnessOptimal = (Values.minFitnessOptimal + Values.minFitnessMin) / 2;
			}
			if(Values.testingString == "newGenTime"){
				Values.newGenTimeMax = Values.newGenTimeOptimal;
				Values.newGenTimeOptimal = (Values.newGenTimeOptimal + Values.newGenTimeMin) / 2;
			}
			if(Values.testingString == "rateOfMutation"){
				Values.rateOfMutationMax = Values.rateOfMutationOptimal;
				Values.rateOfMutationOptimal = (Values.rateOfMutationOptimal + Values.rateOfMutationMin) / 2;
			}
			if(Values.testingString == "envChangeTime"){
				Values.envChangeTimeMax = Values.envChangeTimeOptimal;
				Values.envChangeTimeOptimal = (Values.envChangeTimeOptimal + Values.envChangeTimeMin) / 2;
			}
		}
	}
}
