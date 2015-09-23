using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using bt.solve.LhsABInit;

namespace impl.bt.solve.LhsABInitImpl 
{
	public class ILhsABInitImpl : BaseILhsABInitImpl, ILhsABInit
	{
		private double[,,] lhsa;
		private double[,,] lhsb;
		private int size;
	
		public void setParameters(double[,,] lhsa, double[,,] lhsb, int size) 
		{
		   this.lhsa = lhsa;
		   this.lhsb = lhsb;
		   this.size = size;
		}
		
		public override void main()   
		{ 
            for(int i = 2; i <= size; i++) 
            {
                for(int m = 0; m < 5; m++) 
                {
                    for(int n = 0; n < 5; n++) 
                    {
                        lhsa[i, n, m] = 0.0d;
                        lhsb[i, n, m] = 0.0d;
                    }
                    lhsb[i, m, m] = 1.0d;
                }
            }
            
            
		}
	}
}
