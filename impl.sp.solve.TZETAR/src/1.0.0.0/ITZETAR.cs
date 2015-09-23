using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using sp.solve.BlockDiagonalMatVecProduct;
using common.problem_size.Instance;
using common.problem_size.Class;
using adi.data.ProblemDefinition;
using common.axis.Axis;
using sp.solve.SPMethod;
using common.axis.ZAxis;

namespace impl.sp.solve.TZETAR { 

	public class ITZETAR<I,C,DIR,MTH> : BaseITZETAR<I,C,DIR,MTH>, IBlockDiagonalMatVecProduct<I,C,DIR,MTH>
			where I:IInstance<C>
			where C:IClass
			where DIR:IZ
			where MTH:ISPMethod
	{		
		private int stage = -1;
		
		public void begin()
		{
			stage = ncells-1;
		}
				
		
		public bool finished()
		{
			return stage < 0;
		}
		
		public void advance()			
		{
			stage--;
		}
				
		
		public override void main() 
		{ 
		    int c;
			
		    c = slice[stage, 2];		
			
		    int i, j, k;
		    int ksize, jsize, isize;
		    double t1, t2, t3, ac, xvel, yvel, zvel,
		           r1, r2, r3, r4, r5, btuz, acinv, ac2u, uzik1;
		
		    ksize = cell_size[c, 2] + 2;
		    jsize = cell_size[c, 1] + 2;
		    isize = cell_size[c, 0] + 2;
		
		    for (k = start[c, 2]; k < ksize - end[c, 2]; k++)
		    {
		        for (j = start[c, 1]; j < jsize - end[c, 1]; j++)
		        {
		            for (i = start[c, 0]; i < isize - end[c, 0]; i++)
		            {
		                xvel = us[c, k, j, i, 0];
		                yvel = vs[c, k, j, i, 0];
		                zvel = ws[c, k, j, i, 0];
		                ac = speed[c, k, j, i, 0];
		                acinv = ainv[c, k, j, i, 0];
		
		                ac2u = ac * ac;
		
		                r1 = rhs[c, k, j, i, 0];
		                r2 = rhs[c, k, j, i, 1];
		                r3 = rhs[c, k, j, i, 2];
		                r4 = rhs[c, k, j, i, 3];
		                r5 = rhs[c, k, j, i, 4];
		
		                uzik1 = u[c, k, j, i, 0];
		                btuz = bt * uzik1;
		
		                t1 = btuz * acinv * (r4 + r5);
		                t2 = r3 + t1;
		                t3 = btuz * (r4 - r5);
		
		                rhs[c, k, j, i, 0] = t2;
		                rhs[c, k, j, i, 1] = -uzik1 * r2 + xvel * t2;
		                rhs[c, k, j, i, 2] = uzik1 * r1 + yvel * t2;
		                rhs[c, k, j, i, 3] = zvel * t2 + t3;
		                rhs[c, k, j, i, 4] = uzik1 * (-xvel * r2 + yvel * r1) +
		                      qs[c, k, j, i, 0] * t2 + c2iv * ac2u * t1 + zvel * t3;
		                      
                 //      for (int m=0;m<5;m++)		                
		         //           Console.WriteLine("tzetar - rhs" + "[" + c + "," + k + "," + j + "," + i + "," + m + "] = " + rhs[c, k, j, i, m]);
		
		            }
		        }
		    }
		
			
		} // end activate method 
	
	}

}
