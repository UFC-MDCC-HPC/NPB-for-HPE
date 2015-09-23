using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using common.direction.Backward;
using common.axis.XAxis;
using lu.exchange.Exchange3_WriteBuffer;

namespace impl.lu.exchange.Exchange3_XBackwardWriteBufferImpl { 

	public class IExchange3_XBackwardWriteBufferImpl<DIR, O> : BaseIExchange3_XBackwardWriteBufferImpl<DIR, O>, IExchange3_WriteBuffer<DIR, O>
	where DIR:IBackwardDirection
	where O:IX
	{
		public override void main() 
		{			
            int i, k0;
            int ipos1, ipos2;            
            int bsize = 10*nx*nz;
            int size2 = bsize/5;
            double[] buf  = Buffer.Array = new double[bsize];
			
            for(k0 = 1; k0<=nz; k0++) 
			{
                for(i = 1; i<=nx; i++) 
				{
                    ipos1 = (k0-1)*nx + i - 1;
                    ipos2 = ipos1 + nx*nz;
					
                    buf[0*size2+ipos1] = g[k0-1, 3, i+1, 0];
                    buf[1*size2+ipos1] = g[k0-1, 3, i+1, 1];
                    buf[2*size2+ipos1] = g[k0-1, 3, i+1, 2];
                    buf[3*size2+ipos1] = g[k0-1, 3, i+1, 3];
                    buf[4*size2+ipos1] = g[k0-1, 3, i+1, 4];

                    buf[0*size2+ipos2] = g[k0-1, 2, i+1, 0];
                    buf[1*size2+ipos2] = g[k0-1, 2, i+1, 1];
                    buf[2*size2+ipos2] = g[k0-1, 2, i+1, 2];
                    buf[3*size2+ipos2] = g[k0-1, 2, i+1, 3];
                    buf[4*size2+ipos2] = g[k0-1, 2, i+1, 4];
                }
            }
		
		    
		} // end activate method 	

		private double[,,,] g;
		private int  nx, ny, nz;
		
		public void setParameters(double[,,,] g, int nx, int ny, int nz)
		{
			this.g = g;
			this.nx = nx;
			this.ny = ny;
			this.nz = nz;
		}
	}

}
