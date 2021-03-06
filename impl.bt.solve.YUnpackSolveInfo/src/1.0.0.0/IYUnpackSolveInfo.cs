using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using bt.problem_size.Instance_BT;
using common.problem_size.Class;
using common.axis.YAxis;
using bt.solve.BTMethod;
using bt.solve.UnpackSolveInfo;

namespace impl.bt.solve.YUnpackSolveInfo 
{ 
	public class IYUnpackSolveInfo<I, C, DIR, MTH> : BaseIYUnpackSolveInfo<I, C, DIR, MTH>, IUnpackSolveInfo<I, C, DIR, MTH>
		where I:IInstance_BT<C>
		where C:IClass
		where DIR:IY
		where MTH:IBTMethod 
	{
		private int c;
		
		public override void main()   
		{
			lhsc = Lhsc.Field6;
			
			int stage = this.Iteration_control.getCurrentStage();
				
			c = slice[stage,1];
			
            int ptr = 0, jstart = 2;
            for(int k = 0; k <= KMAX - 1; k++) 
            {
                for(int i = 0; i <= IMAX - 1; i++) 
                {
                    for(int m = 1; m <= 5; m++) 
                    {
                        for(int n = 0; n < 5; n++) 
                        {
                            lhsc[c, k+2, jstart-1, i+2, n, m-1] = out_buffer_y[ptr + n];
                        }
                        ptr = ptr + 5;
                    }
                    for(int n = 0; n < 5; n++) 
                    {
                        rhs[c, k+2, jstart-1, i+2, n] = out_buffer_y[ptr + n];
                    }
                    ptr = ptr + 5;
                }
            }
            
               
		}
	}
}
