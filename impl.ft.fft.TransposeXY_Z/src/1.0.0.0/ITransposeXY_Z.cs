using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using ft.problem_size.Instance_FT;
using common.problem_size.Class;
using common.axis.XY_Z_Axes;
using ft.fft.Transpose;

namespace impl.ft.fft.TransposeXY_Z { 
	public class ITransposeXY_Z<I, C, DIR> : BaseITransposeXY_Z<I, C, DIR>, ITranspose<I, C, DIR>
	where I:IInstance_FT<C>
	where C:IClass
	where DIR:IXY_Z_Axes
	{
	   
	    private int l1, l2;
	    private double[, , ,] xin;
	    private double[, , ,] xout;
		
		public override void main() 
		{
           Transpose_local.go();
           Transpose_global.go();
           Transpose_finish.go();
		   
		}
		
		public void setParameters(int l1, int l2, double[, , ,] xin, double[, , ,] xout)
		{
		   this.l1   = l1;
		   this.l2   = l2;
		   this.xin  = xin;
		   this.xout = xout;
           Transpose_local.setParameters(dims[0, l1], dims[1, l1], dims[2, l1], xin, xout);
           Transpose_global.setParameters(dims[1, 0], dims[2, 0], dims[0, 0], xout, xin);
           Transpose_finish.setParameters(dims[0, l1],dims[1, l1], dims[2, l1], xin, xout);
		}
	}
}
