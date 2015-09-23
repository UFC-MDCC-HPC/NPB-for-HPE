using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using bt.problem_size.Instance_BT;
using common.problem_size.Class;
using common.axis.XAxis;
using bt.solve.BTMethod;
using bt.solve.PackSolveInfo;

namespace impl.bt.solve.XPackSolveInfo 
{ 
	public class IXPackSolveInfo<I, C, DIR, MTH> : BaseIXPackSolveInfo<I, C, DIR, MTH>, IPackSolveInfo<I, C, DIR, MTH>
		where I:IInstance_BT<C>
		where C:IClass
		where DIR:IX
		where MTH:IBTMethod 
	{
		private int c;
				
		private bool buffers_created = false;

		private void create_buffers()
		{
		}
		
		public override void main()   
		{
			if (!buffers_created)
			{
				this.create_buffers();
				buffers_created = true;
			}
			
			lhsc = Lhsc.Field6;	
						
			int stage = this.Iteration_control.getCurrentStage();
				
			c = slice[stage,0];
			
			int isize, ptr=0;
			isize = cell_size[c, 0] + 1;
			for(int k = 0; k <= KMAX - 1; k++) 
			{
			    for(int j = 0; j <= JMAX - 1; j++) 
			    {
			        for(int m = 1; m <= 5; m++) 
			        {
			            for(int n = 0; n < 5; n++) 
			            {
			                in_buffer_x[ptr + n] = lhsc[c, k+2, j+2, isize, n, m-1];
			            }
			            ptr = ptr + 5;
			        }
			        
			        for(int n = 0; n < 5; n++) 
			        {
			            in_buffer_x[ptr + n] = rhs[c, k+2, j+2, isize, n];
			        }
			        ptr = ptr + 5;
			    }
			}
			
			
		}
	}
}
