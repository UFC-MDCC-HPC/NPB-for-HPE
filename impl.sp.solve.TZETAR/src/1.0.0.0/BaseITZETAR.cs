/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using common.datapartition.MultiPartitionCells;
using adi.data.ProblemDefinition;
using common.problem_size.Instance;
using common.problem_size.Class;
using sp.solve.BlockDiagonalMatVecProduct;
using common.axis.Axis;
using common.axis.ZAxis;
using sp.solve.SPMethod;

namespace impl.sp.solve.TZETAR { 

public abstract class BaseITZETAR<I,C,DIR,MTH>: Computation, BaseIBlockDiagonalMatVecProduct<I,C,DIR,MTH>
	where I:IInstance<C>
	where C:IClass
	where DIR:IZ
	where MTH:ISPMethod
{
		
#region data		
		
protected int[,] start, end, cell_size, slice;
protected double[,,,,] rhs, rho_i, us, vs, ws, qs, speed, ainv, u ;
protected double bt, c2iv;
protected int ncells;
		
override public void initialize()
{
	start = Cells.cell_start;
	end = Cells.cell_end;
	cell_size = Cells.cell_size;
	slice = Cells.cell_slice;
	
	rhs = Problem.Field_rhs;
	rho_i = Problem.Field_rho;
	us = Problem.Field_us;
	vs = Problem.Field_vs;
	ws = Problem.Field_ws;
	qs = Problem.Field_qs;
	speed = Problem.Field_speed;
	ainv = Problem.Field_ainv;
    u = Problem.Field_u;
			
			
	bt = Constants.bt;
	c2iv = Constants.c2iv;
			
	ncells = Problem.NCells;
}
		
#endregion
		
private ICells cells = null;

public ICells Cells {
	get {
		if (this.cells == null)
		{
			this.cells = (ICells) Services.getPort("cells_info");
		}
		return this.cells;
	}
}

private IProblemDefinition<I,C> problem = null;

public IProblemDefinition<I,C> Problem {
	get {
		if (this.problem == null) 
		{
			this.problem = (IProblemDefinition<I,C>) Services.getPort("problem_data");
		}
		return this.problem;
	}
}
		
private DIR axis = default(DIR);

protected DIR Axis {
	get {
		if (this.axis == null)
			this.axis = (DIR) Services.getPort("axis");
		return this.axis;
	}
}

private MTH method = default(MTH);

protected MTH Method {
	get {
		if (this.method == null)
			this.method = (MTH) Services.getPort("method");
		return this.method;
	}
}
		
		
 


}

}
