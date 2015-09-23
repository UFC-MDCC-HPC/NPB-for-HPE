using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using ft.problem_size.Instance_FT;
using common.problem_size.Class;
using common.axis.XAxis;
using ft.fft.Cffts;

namespace impl.ft.fft.Cffts1Impl 
{ 
	public class ICffts1Impl<I, C, DIR> : BaseICffts1Impl<I, C, DIR>, ICffts<I, C, DIR>
		where I:IInstance_FT<C>
		where C:IClass
		where DIR:IX
	{
	   
	    private int dir, d1, d2, d3;
	    private double[, , ,] x;
	    private double[, , ,] xout;

		private double[,,,] y_cffts1 = null;

		public override void main() 
		{ 	
            int logd1;
            double[,,,] y = y_cffts1 == null ? y_cffts1 = new double[2, d1, fftblockpad, 2] : y_cffts1;

            int i, j, k, jj, io;
            logd1 = ilog2(d1);
            for(k = 0; k < d3; k++) 
			{
                for(jj = 0; jj <= (d2-fftblock); jj = jj + fftblock) 
				{
                    for(j = 0; j < fftblock; j++) 
					{
                        for(i = 0; i < d1; i++) 
						{
                            io = ((k*d2+(j+jj))*d1+i)*2;

                            int m1 = (io % size1);
                            int m2 = (m1 % size2);
                            int _i = io/size1;
                            int _j = m1/size2;
                            int _k = m2/2;

                            y[0, i, j, REAL] = x[_i, _j, _k, REAL];
                            y[0, i, j, IMAG] = x[_i, _j, _k, IMAG];
                        }
                    }
					
					Cfftz.setParameters(dir, logd1, d1, y);
                    Cfftz.go();

                    for(j = 0; j < fftblock; j++) 
					{
                        for(i = 0; i < d1; i++) 
						{
                            io  = (((k*d2+(j+jj))*d1+i)*2);

                            int m1 = (io % size1);
                            int m2 = (m1 % size2);
                            int _i = io/size1;
                            int _j = m1/size2;
                            int _k = m2/2;

                            xout[_i, _j, _k, REAL] = y[0, i, j, REAL];
                            xout[_i, _j, _k, IMAG] = y[0, i, j, IMAG];
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
