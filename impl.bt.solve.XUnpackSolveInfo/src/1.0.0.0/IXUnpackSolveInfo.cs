using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using bt.problem_size.Instance_BT;
using common.problem_size.Class;
using common.axis.XAxis;
using bt.solve.BTMethod;
using bt.solve.UnpackSolveInfo;

namespace impl.bt.solve.XUnpackSolveInfo 
{ 
	public class IXUnpackSolveInfo<I, C, DIR, MTH> : BaseIXUnpackSolveInfo<I, C, DIR, MTH>, IUnpackSolveInfo<I, C, DIR, MTH>
		where I:IInstance_BT<C>
		where C:IClass
		where DIR:IX
		where MTH:IBTMethod 
	{
		private int c;
		
		public override void main()   
		{
			lhsc = Lhsc.Field6;
						
			int stage = this.Iteration_control.getCurrentStage();
				
			c = slice[stage,0];
			
            int ptr = 0, istart = 2;
            for(int k = 0; k <= KMAX - 1; k++) 
            {
                for(int j = 0; j <= JMAX - 1; j++) 
                {
                    for(int m = 1; m <= 5; m++) 
                    {
                        for(int n = 0; n < 5; n++) 
                        {
                            lhsc[c, k+2, j+2, istart-1, n, m-1] = out_buffer_x[ptr + n];
                        }
                        ptr = ptr + 5;
                    }
                    
                    for(int n = 0; n < 5; n++) 
                    {
                        rhs[c, k+2, j+2, istart-1, n] = out_buffer_x[ptr + n];
                    }
                    
                    ptr = ptr + 5;
                }                
            }
            
            
		}
	}
}
