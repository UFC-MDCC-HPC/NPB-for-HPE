/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using common.datapartition.MultiPartitionCells;
using adi.data.ProblemDefinition;
using bt.problem_size.Instance_BT;
using common.problem_size.Class;
using common.axis.Axis;
using common.axis.XAxis;
using bt.solve.BTMethod;
using bt.solve.UnpackSolveInfo;
using common.Buffer;
using adi.solve.IterationControl;
using common.direction.Forward;
using common.data.Field;

namespace impl.bt.solve.XUnpackSolveInfo { 

public abstract class BaseIXUnpackSolveInfo<I, C, DIR, MTH>: Computation, BaseIUnpackSolveInfo<I, C, DIR, MTH>
where I:IInstance_BT<C>
where C:IClass
where DIR:IX
where MTH:IBTMethod
{
#region data
	protected double[,,,,] rhs;
	protected int[,] slice;
	protected int KMAX;
	protected int JMAX;
	protected double[,,,,,] lhsc;
	protected double[] out_buffer_x; 
	
	override public void initialize()
	{
		rhs = Problem.Field_rhs;
		KMAX = Problem.KMAX;
		JMAX = Problem.JMAX;
			
		slice = Cells.cell_slice;
			
		int MAX_CELL_DIM = Problem.MAX_CELL_DIM;				
		int buffer_size = MAX_CELL_DIM * MAX_CELL_DIM * (5 * 5 + 5);
		Buffer.Array = new double[buffer_size]; 
		this.out_buffer_x = Buffer.Array;
	}
#endregion

private IField lhsc_ = null;

protected IField Lhsc {
	get {
		if (lhsc_ == null) 
			lhsc_ = (IField) Services.getPort("lhsc");
		return lhsc_;
	}
}
		
private IIterationControl<IForwardDirection> iteration_control = null;

public IIterationControl<IForwardDirection> Iteration_control {
	get {
		if (this.iteration_control == null)
			this.iteration_control = (IIterationControl<IForwardDirection>) Services.getPort("iteration_control");
		return this.iteration_control;
	}
}

private IBuffer buffer = null;

public IBuffer Buffer {
	get {
		if (this.buffer == null)
			this.buffer = (IBuffer) Services.getPort("buffer");
		return this.buffer;
	}
}

private ICells cells = null;

public ICells Cells {
	get {
		if (this.cells == null)
			this.cells = (ICells) Services.getPort("cells_info");
		return this.cells;
	}
}

private IProblemDefinition<I, C> problem = null;

public IProblemDefinition<I, C> Problem {
	get {
		if (this.problem == null)
			this.problem = (IProblemDefinition<I, C>) Services.getPort("problem_data");
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
