using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LanguageSetter {

	public static class MainStrings {
		public static string title = "Evolution Simulator";
		public static string populationFixed = "Population fixed";
		public static string minFitness = "Min fitness";
		public static string populationSize = "Population size";
		public static string genAmount = "Gen amount";
		public static string newGenTime = "New gen time";
		public static string rateOfMutation = "% of mutation";
		public static string envChangeTime = "Env change time";
		public static string run = "Run Demo";
		public static string test = "Neural Net";
	}

	public static class EvoSimStrings {
		public static string generation = "Generation : ";
		public static string min = "MIN";
		public static string max = "MAX";
		public static string avg = "AVG";
		public static string env = "ENV";
		public static string others = "Others";
	}

	public static class GraphsStrings {
		public static string populationSizeFinal = "Population size final";
	}

	public static void SetLanguage (string lang){
		if(lang == "en"){
			MainStrings.title = "Evolution Simulator";
			MainStrings.populationFixed = "Population fixed";
			MainStrings.minFitness = "Minimal fitness";
			MainStrings.populationSize = "Population size";
			MainStrings.genAmount = "Generation amount";
			MainStrings.newGenTime = "New generation time";
			MainStrings.rateOfMutation = "% of mutation";
			MainStrings.envChangeTime = "Environment change time";
			MainStrings.run = "Run Demo";
			MainStrings.test = "Neural Net";

			EvoSimStrings.generation = "Generation : ";
			EvoSimStrings.min = "MIN";
			EvoSimStrings.max = "MAX";
			EvoSimStrings.avg = "AVG";
			EvoSimStrings.env = "ENV";
			EvoSimStrings.others = "Others";
			GraphsStrings.populationSizeFinal = "Population size final";
		}
		if(lang == "ru"){
			MainStrings.title = "Симулятор эволюции";
			MainStrings.populationFixed = "Популяция фиксирована";
			MainStrings.minFitness = "Минимальная схожесть";
			MainStrings.populationSize = "Размер популяции";
			MainStrings.genAmount = "Количество генерации";
			MainStrings.newGenTime = "Время новой генерации";
			MainStrings.rateOfMutation = "% мутации";
			MainStrings.envChangeTime = "Время смены окружения";
			MainStrings.run = "Запуск Демо";
			MainStrings.test = "Нейросеть";

			EvoSimStrings.generation = "Генерация : ";
			EvoSimStrings.min = "МИН";
			EvoSimStrings.max = "МАКС";
			EvoSimStrings.avg = "СРЕД";
			EvoSimStrings.env = "ОКР";
			EvoSimStrings.others = "Другие";

			GraphsStrings.populationSizeFinal = "Конечный размер популяции";
		}
		if(lang == "kz"){
			MainStrings.title = "Эволюция симуляторы";
			MainStrings.populationFixed = "Популяция саны шектелген";
			MainStrings.minFitness = "Минимальді ұқсастық";
			MainStrings.populationSize = "Популяция мөлшері";
			MainStrings.genAmount = "Генерация саны";
			MainStrings.newGenTime = "Жаңа генерация уақыты";
			MainStrings.rateOfMutation = "Мутация %";
			MainStrings.envChangeTime = "Ортаның ауысу уақыты";
			MainStrings.run = "Демоны Іске қосу";
			MainStrings.test = "Нейронды желі";

			EvoSimStrings.generation = "Генерация : ";
			EvoSimStrings.min = "МИН";
			EvoSimStrings.max = "МАКС";
			EvoSimStrings.avg = "ОРТ";
			EvoSimStrings.env = "ҚОР";
			EvoSimStrings.others = "Басқа";

			GraphsStrings.populationSizeFinal = "Популяцияның ақырғы мөлшері";
		}
	}
}
