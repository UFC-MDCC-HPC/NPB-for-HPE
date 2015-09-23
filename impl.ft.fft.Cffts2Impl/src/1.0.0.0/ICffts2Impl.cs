using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using ft.problem_size.Instance_FT;
using common.problem_size.Class;
using common.axis.YAxis;
using ft.fft.Cffts;

namespace impl.ft.fft.Cffts2Impl 
{ 
	public class ICffts2Impl<I, C, DIR> : BaseICffts2Impl<I, C, DIR>, ICffts<I, C, DIR>
		where I:IInstance_FT<C>
		where C:IClass
		where DIR:IY
	{
	   
	    private int dir, d1, d2, d3;
	    private double[, , ,] x;
	    private double[, , ,] xout;
	
		private double[,,,] y_cffts2 = null;

		public override void main() 
		{ 
            int logd2;
            double[,,,] y = y_cffts2 == null ? y_cffts2 = new double[2, d2, fftblockpad, 2] : y_cffts2; 

            int i, j, k, ii, io;
            logd2 = ilog2(d2);
            for(k = 0; k < d3; k++) 
			{
                for(ii = 0; ii <= d1 - fftblock; ii = ii + fftblock) 
				{
                    for(j = 0; j < d2; j++) 
					{
                        for(i = 0; i < fftblock; i++) 
						{
                            io = ((k*d2+j)*d1+(i+ii))*2;

                            int m1 = (io % size1);
                            int m2 = (m1 % size2);
                            int _i = io/size1;
                            int _j = m1/size2;
                            int _k = m2/2;

                            y[0, j, i, REAL] = x[_i, _j, _k, REAL];
                            y[0, j, i, IMAG] = x[_i, _j, _k, IMAG];
                        }
                    }

                    Cfftz.setParameters(dir, logd2, d2, y);
                    Cfftz.go();

                    for(j = 0; j < d2; j++) 
					{
                        for(i = 0; i < fftblock; i++) 
						{
                            io = ((k * d2 + j) * d1 + (i + ii)) * 2;

                            int m1 = (io % size1);
                            int m2 = (m1 % size2);
                            int _i = io/size1;
                            int _j = m1/size2;
                            int _k = m2/2;

                            xout[_i, _j, _k, REAL] = y[0, j, i, REAL];
                            xout[_i, _j, _k, IMAG] = y[0, j, i, IMAG];
                        }
                    }
                }
            }
		    
		}
		
        public int ilog2(int n) {
            int nn, lg;
            if(n == 1) {
                
            }
            lg = 1;
            nn = 2;
            while(nn < n) {
                nn = nn * 2;
                lg = lg + 1;
            }
            return lg;
        }
		public void setParameters(int dir, int d1, int d2, int d3, double[, , ,] x, double[, , ,] xout){
		    this.dir  = dir;
		    this.d1   = d1;
		    this.d2   = d2;
		    this.d3   = d3;
		    this.x    = x;
		    this.xout = xout;
		}
	}
}
