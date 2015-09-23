using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using common.direction.Forward;
using common.axis.YAxis;
using lu.exchange.Exchange3_WriteBuffer;

namespace impl.lu.exchange.Exchange3_YForwardWriteBufferImpl { 

	public class IExchange3_YForwardWriteBufferImpl<DIR, O> : BaseIExchange3_YForwardWriteBufferImpl<DIR, O>, IExchange3_WriteBuffer<DIR, O>
		where DIR:IForwardDirection
		where O:IY
	{
		public override void main() { 
			
            int j, k0;
            int ipos1, ipos2;
            int bsize = 10*ny*nz;
            int size2 = bsize / 5;
            double[] buf = Buffer.Array  = new double[bsize];
			
            for(k0 = 1; k0<=nz; k0++) 
			{
                for(j = 1; j<=ny; j++) 
				{
                    ipos1 = (k0-1)*ny+j - 1;
                    ipos2 = ipos1 + ny*nz;
					
                    buf[0*size2+ipos1] = g[k0-1, j+1, nx, 0];
                    buf[1*size2+ipos1] = g[k0-1, j+1, nx, 1];
                    buf[2*size2+ipos1] = g[k0-1, j+1, nx, 2];
                    buf[3*size2+ipos1] = g[k0-1, j+1, nx, 3];
                    buf[4*size2+ipos1] = g[k0-1, j+1, nx, 4];

                    buf[0*size2+ipos2] = g[k0-1, j+1, nx+1, 0];
                    buf[1*size2+ipos2] = g[k0-1, j+1, nx+1, 1];
                    buf[2*size2+ipos2] = g[k0-1, j+1, nx+1, 2];
                    buf[3*size2+ipos2] = g[k0-1, j+1, nx+1, 3];
                    buf[4*size2+ipos2] = g[k0-1, j+1, nx+1, 4];
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
