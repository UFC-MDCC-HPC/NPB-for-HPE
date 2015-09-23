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
using bt.solve.UnpackBackSubInfo;
using common.Buffer;
using common.direction.Backward;
using adi.solve.IterationControl;
using common.data.Field;

namespace impl.bt.solve.XUnpackBackSubInfo { 

public abstract class BaseIXUnpackBackSubInfo<I, C, DIR, MTH>: Computation, BaseIUnpackBackSubInfo<I, C, DIR, MTH>
where I:IInstance_BT<C>
where C:IClass
where DIR:IX
where MTH:IBTMethod
{
#region data
	protected int KMAX;
	protected int JMAX;
	protected int[,] slice;
	protected double[,,,,] backsub_info;
	protected double[] out_buffer_x;
		
	override public void initialize()
	{
		KMAX = Problem.KMAX;
		JMAX = Problem.JMAX;
			
		slice = Cells.cell_slice;
			
		int MAX_CELL_DIM = Problem.MAX_CELL_DIM;
		int buffer_size = MAX_CELL_DIM * MAX_CELL_DIM * 5;
		Buffer.Array = new double[buffer_size];
		out_buffer_x = Buffer.Array;
	}
#endregion
		
private IField backsub_info_ = null;

protected IField Backsub_info {
	get {
		if (backsub_info_ == null) 
			backsub_info_ = (IField) Services.getPort("backsub_info");
		return backsub_info_;
	}
}
		
private IIterationControl<IBackwardDirection> iteration_control = null;

public IIterationControl<IBackwardDirection> Iteration_control {
	get {
		if (this.iteration_control == null)
			this.iteration_control = (IIterationControl<IBackwardDirection>) Services.getPort("iteration_control");
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
