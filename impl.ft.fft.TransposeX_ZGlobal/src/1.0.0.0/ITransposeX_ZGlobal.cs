using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using ft.problem_size.Instance_FT;
using common.problem_size.Class;
using common.axis.X_Z_Axis;
using ft.fft.TransposeGlobal;
using MPI;

namespace impl.ft.fft.TransposeX_ZGlobal 
{ 
	public class ITransposeX_ZGlobal<I, C, DIR> : BaseITransposeX_ZGlobal<I, C, DIR>, ITransposeGlobal<I, C, DIR>
		where I:IInstance_FT<C>
		where C:IClass
		where DIR:IX_Z_Axis
	{
	   
	    private int d1, d2, d3;
	    private double[, , ,] xin;
	    private double[, , ,] xout;
	    protected Intracommunicator worldcomm, commslice1;
	
		private double[] src_transpose_x_z_global = null;
		private double[] dst_transpose_x_z_global = null;

		override public void post_initialize()
		{
            worldcomm = this.WorldComm;
		}
		
		public override void main() 
		{ 
            double[] src = src_transpose_x_z_global == null ? src_transpose_x_z_global = new double[d1*d2*d3*2] : src_transpose_x_z_global;
            double[] dst = dst_transpose_x_z_global == null ? dst_transpose_x_z_global = new double[d1*d2*d3*2] : dst_transpose_x_z_global;
            
            setVetor(xin, src);
		    commslice1 = (Intracommunicator)worldcomm.Split(me1, me2);
            commslice1.AlltoallFlattened<double>(src, d1*d2*d3*2/np2, ref dst);
            setVetor(dst, xout);
            
		    
		}
		
		public void setParameters(int d1, int d2, int d3, double[, , ,] xin, double[, , ,] xout) 
		{
		   this.d1 = d1;
		   this.d2 = d2;
		   this.d3 = d3;
		   this.xin = xin;
		   this.xout = xout;
		}
		
        public static unsafe void setVetor(double[, , ,] s, double[] d) 
        {
            int size = s.Length;
            if(size == d.Length) 
            {
                fixed(double* ps = s, pd = d) 
                {
                    double* p1 = ps;
                    double* p2 = pd;
                    for(int n = 0; n < size/2; n++) 
                    {
                        *((decimal*)p2) = *((decimal*)p1);
                        p2 += 2;
                        p1 += 2;
                    }
                }
            }
            else 
            {
                throw new IndexOutOfRangeException();
            }
        }
        
        public static unsafe void setVetor(double[] s, double[, , ,] d) 
        {
            int size = s.Length;
            if(size == d.Length) 
            {
                fixed(double* ps = s, pd = d) 
                {
                    double* p1 = ps;
                    double* p2 = pd;
                    for(int n = 0; n < size / 2; n++) 
                    {
                        *((decimal*)p2) = *((decimal*)p1);
                        p2 += 2;
                        p1 += 2;
                    }
                }
            }
            else 
            {
                throw new IndexOutOfRangeException();
            }
        }
	}
}
