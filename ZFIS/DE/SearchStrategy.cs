﻿namespace DE
{
	public abstract class SearchStrategy
	{
		protected Random RNG;

		internal void Initialize(Random r)
		{
			RNG = r;
		}

		abstract public void Apply(
			double f, double cr, int npars, double[] x, double[] best,
			double[] r1, double[] r2, double[] r3
		);

	}
}
