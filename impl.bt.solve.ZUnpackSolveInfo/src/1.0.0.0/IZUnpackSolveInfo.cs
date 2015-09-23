using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using bt.problem_size.Instance_BT;
using common.problem_size.Class;
using common.axis.ZAxis;
using bt.solve.BTMethod;
using bt.solve.UnpackSolveInfo;

namespace impl.bt.solve.ZUnpackSolveInfo { 
	public class IZUnpackSolveInfo<I, C, DIR, MTH> : BaseIZUnpackSolveInfo<I, C, DIR, MTH>, IUnpackSolveInfo<I, C, DIR, MTH>
	where I:IInstance_BT<C>
	where C:IClass
	where DIR:IZ
	where MTH:IBTMethod {
		
		private int c;
		
		public override void main()   
		{
			lhsc = Lhsc.Field6;
			
			int stage = this.Iteration_control.getCurrentStage();
				
			c = slice[stage,2];
			
            int ptr = 0, kstart = 2;
            for(int j = 0; j <= JMAX - 1; j++) 
            {
                for(int i = 0; i <= IMAX - 1; i++) 
                {
                    for(int m = 1; m <= 5; m++) 
                    {
                        for(int n = 0; n < 5; n++) 
                        {
                            lhsc[c, kstart-1, j+2, i+2, n, m-1] = out_buffer_z[ptr + n];
                        }
                        ptr = ptr + 5;
                    }
                    
                    for(int n = 0; n < 5; n++) 
                    {
                        rhs[c, kstart-1, j+2, i+2, n] = out_buffer_z[ptr + n];
                    }
                    ptr = ptr + 5;
                }
            }
            
            
		}
	}
}
