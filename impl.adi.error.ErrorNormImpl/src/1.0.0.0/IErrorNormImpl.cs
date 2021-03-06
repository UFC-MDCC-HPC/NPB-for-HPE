using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using adi.error.ErrorNorm;
using common.problem_size.Instance;
using common.problem_size.Class;
using adi.data.ProblemDefinition;
using MPI;



namespace impl.adi.error.ErrorNormImpl { 

public class IErrorNormImpl<I,C> : BaseIErrorNormImpl<I,C>, IErrorNorm<I,C>
		where I:IInstance<C>
		where C:IClass
{
	
	public override  void main() { 

		dnxm1 = Constants.dnxm1;
		dnym1 = Constants.dnym1;
		dnzm1 = Constants.dnzm1;				

		int c, i, j, k, ii, jj, kk, m, d;
        double xi, eta, zeta;
        double[] u_exact = new double[5];
        double add;
        double[] rms_work = new double[5];

        for (m = 0; m < 5; m++)
        {
            rms_work[m] = 0.0d;
        }

        for (c = 0; c < ncells; c++)
        {
            kk = 2;
            for (k = cell_low[c, 2]; k <= cell_high[c, 2]; k++)
            {
                zeta = k * dnzm1;
                jj = 2;
                for (j = cell_low[c, 1]; j <= cell_high[c, 1]; j++)
                {
                    eta = j * dnym1;
                    ii = 2;
                    for (i = cell_low[c, 0]; i <= cell_high[c, 0]; i++)
                    {
                        xi = i * dnxm1;
						
                        Exact_solution.setParameters(xi, eta, zeta, u_exact, 0);
						Exact_solution.go();

                        for (m = 0; m < 5; m++)
                        {
                            add = u[c, kk, jj, ii, m] - u_exact[m];
                            rms_work[m] += add * add;
                        }
                        ii++;
                    }
                    jj++;
                }
                kk++;
            }
        }

        comm_setup.Allreduce<double>(rms_work, Operation<double>.Add, ref rms);

        for (m = 0; m < 5; m++)
        {
            for (d = 0; d < 3; d++)
            {
                rms[m] /= (grid_points[d] - 2);
            }
            rms[m] = Math.Sqrt(rms[m]);
        }
		
	} // end activate method 

}

}
