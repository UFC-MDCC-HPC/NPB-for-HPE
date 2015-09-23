using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using bt.problem_size.Instance_BT;
using common.problem_size.Class;
using common.axis.ZAxis;
using bt.solve.BTMethod;
using bt.solve.BackSubstitute;

namespace impl.bt.solve.ZBackSubstitute 
{ 
	public class IZBackSubstituteImpl<I, C, DIR, MTH> : BaseIZBackSubstituteImpl<I, C, DIR, MTH>, IBackSubstitute<I, C, DIR, MTH>
		where I:IInstance_BT<C>
		where C:IClass
		where DIR:IZ
		where MTH:IBTMethod
	{
		private int last, c;
		
		
	    public override void main() 
		{ 
			backsub_info = Backsub_info.Field;
			lhsc = Lhsc.Field6;

			int stage = this.Iteration_control.getCurrentStage();
			last = this.Iteration_control.is_last_stage() ? 1 : 0;
				
			c = slice[stage,2];		
			
			int i, k;
			int m, n, j, jsize, isize, ksize, kstart;
			
			kstart = 2;
			isize = cell_size[c, 0] - end[c, 0] + 1;
			jsize = cell_size[c, 1] - end[c, 1] + 1;
			ksize = cell_size[c, 2] + 1;
			
			if(last == 0) {
			    for(j = start[c, 1]; j <= jsize; j++) 
			    {
			        for(i = start[c, 0]; i <= isize; i++) 
			        {
			            //---------------------------------------------------------------------
			            //     U[jsize] uses info from previous cell if not last cell
			            //---------------------------------------------------------------------
			            for(m = 0; m < 5; m++) 
			            {
			                for(n = 0; n < 5; n++) 
			                { //rhs[m,i,j,ksize,c] = rhs[m,i,j,ksize,c] - lhsc[m,n,i,j,ksize,c]*backsub_info[n,i,j,c]
			                    rhs[c, ksize, j, i, m] = rhs[c, ksize, j, i, m] - lhsc[c, ksize, j, i, n, m] * backsub_info[c, j, i, n, 0];
			                }
			            }
			        }
			    }
			}
			
			for(k = ksize-1; k >= kstart; k--) 
			{  //for(k=ksize-1,kstart,-1;
			    for(j = start[c, 1]; j <= jsize; j++) 
			    {
			        for(i = start[c, 0]; i <= isize; i++) 
			        {
			            for(m = 0; m < 5; m++) 
			            {
			                for(n = 0; n < 5; n++) 
			                {  //rhs[m,i,j,k,c] = rhs[m,i,j,k,c] - lhsc[m,n,i,j,k,c]*rhs[n,i,j,k+1,c];
			                    rhs[c, k, j, i, m] = rhs[c, k, j, i, m] - lhsc[c, k, j, i, n, m] * rhs[c, k+1, j, i, n];
			                }
			            }
			        }
			    }
			}
			
			
		} // end activate method 
	
	}

}
