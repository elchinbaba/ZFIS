using ZFIS;

namespace DEandZFIS
{
	public class _Main
	{
		public static void Main()
		{
			//
			_Parameter[] LP = new _Parameter[1]
			{
			new _Parameter("X", new _LinguisticTerm[]{
				new _LinguisticTerm(new _ZNumber3(-0.5, 0.3, 1.5 ), "VERY LOW"),
				new _LinguisticTerm(new _ZNumber3( 1.0, 2.3, 3.0 ), "LOW"),
				new _LinguisticTerm(new _ZNumber3( 2.5, 3.3, 3.8 ), "HIGH"),
				new _LinguisticTerm(new _ZNumber3( 3.6, 3.95, 4.5 ), "VERY HIGH")
			})
			};

			_Parameter[] RP = new _Parameter[1]
			{
			//
			new _Parameter("Y", new _LinguisticTerm[]{
				new _LinguisticTerm(new _ZNumber3( 0.0, 0.0, 0.2 ), "VERY LOW"),
				new _LinguisticTerm(new _ZNumber3( 0, 0.5, 1 ), "LOW"),
				new _LinguisticTerm(new _ZNumber3( 0.6, 2.8, 3.6 ), "HIGH"),
				new _LinguisticTerm(new _ZNumber3( 3.0, 6.25, 7.0 ), "VERY HIGH")
			})
			};

			// Rules:
			// IF X IS "VERY LOW" THEN Y="LOW"
			// IF X IS "LOW" THEN Y="HIGH"
			// IF X IS "HIGH" THEN Y="VERY LOW"
			// IF X IS "VERY HIGH" THEN Y="VERY HIGH"

			// NF.NRules==4
			_Rule[] Rules = new _Rule[]{
			new _Rule(new int[]{ 0 }, new int[]{ 1 }),
			new _Rule(new int[]{ 1 }, new int[]{ 2 }),
			new _Rule(new int[]{ 2 }, new int[]{ 0 }),
			new _Rule(new int[]{ 3 }, new int[]{ 3 })
		};

			_NeuroFuzzy NF = new _NeuroFuzzy(LP, RP, Rules);
			System.Console.WriteLine(NF);
			//System.Console.WriteLine(NF.ToString(new double[1]{1})); System.Console.Read();
			int i;
			double[][] inputs = new double[41][];
			for (i = 0; i < 41; i++) inputs[i] = new double[1];
			double[][] outputs = new double[41][];
			for (i = 0; i < 41; i++) outputs[i] = new double[1];
			double x = 0.0;
			i = 0;
			for (x = 0.0; x < 4.05; x += 0.1)
			{
				inputs[i][0] = x;
				outputs[i][0] = simfun(x);
				System.Console.WriteLine(inputs[i][0] + "\t" + outputs[i][0] + "\t" + NF.DoInference(inputs[i])[0]);
				i++;
			}
			System.Console.WriteLine("\nMSE: " + NF.MSE(inputs, outputs));
			System.Console.WriteLine("\nMax ERROR: " + NF.MaxError(inputs, outputs));
			double[,] lranges = new double[1, 2] { { 0, 5 } };
			double[,] rranges = new double[1, 2] { { 0, 10 } };
			//
			while (NF.MSE(inputs, outputs) > 0.001)
			{
				NF.DoTrain(inputs, outputs, lranges, rranges, 2000, 0);
			}
			//
			//LoadTrainedSystem(out NF);
			//
			System.Console.WriteLine("\nMSE: " + NF.MSE(inputs, outputs));
			System.Console.WriteLine("\nMax ERROR: " + NF.MaxError(inputs, outputs));
			System.Console.WriteLine("\n");
			i = 0;
			for (x = 0.0; x < 4.05; x += 0.1)
			{
				inputs[i][0] = x;
				outputs[i][0] = simfun(x);
				System.Console.WriteLine(inputs[i][0] + "\t" + outputs[i][0] + "\t" + NF.DoInference(inputs[i])[0]);
				i++;
			}
			System.Console.Read();
			//
		}

		static double simfun(double x)
		{
			double y;
			y = (x * x * x * System.Math.Sin(x) / (x + 1) + 2);
			return y * y / 8;
		}

	}
}
