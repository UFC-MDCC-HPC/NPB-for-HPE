/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using common.datapartition.MultiPartitionCells;
using common.topology.Ring;
using adi.data.ProblemDefinition;
using sp.problem_size.Instance_SP;
using common.problem_size.Class;
using common.Buffer;
using sp.solve.Forward;
using sp.solve.SPMethod;
using common.axis.Axis;
using sp.solve.BlockDiagonalMatVecProduct;
using common.interactionpattern.Shift;
using common.direction.Forward;
using common.direction.Backward;
using sp.solve.LHS;
using environment.MPIDirect;
using common.problem_size.Instance;
using sp.solve.Backward;
using sp.solve.Solver;
using sp.solve.shift.ReadBuffer;
using sp.solve.shift.WriteBuffer;

namespace impl.sp.solve.SolverImpl { 

public abstract class BaseISolverImpl<I, C, MTH, DIR>: Computation, BaseISPSolver<I, C, MTH, DIR>
where I:IInstance_SP<C>
where C:IClass
where MTH:ISPMethod
where DIR:IAxis
{
		
#region data
		
protected int[,] start, end, slice, cell_size;
protected double[,,,,] lhs, rhs;
protected int ncells;
				
		
override public void initialize()
{
	start = Cells_info.cell_start;
	end = Cells_info.cell_end;
	slice = Cells_info.cell_slice;
	cell_size = Cells_info.cell_size;
	
	ncells = Problem_data.NCells;
	lhs = Problem_data.Field_lhs;
	rhs = Problem_data.Field_rhs;
}		
		
#endregion
		
//private ICells cells_info = null;

public ICells Cells_info {
	get {
		//if (this.cells_info == null)
		//{
		//	this.cells_info = (ICells) Services.getPort("cells_info");
		//}
		return (ICells)  Slice["cells_info"];//this.cells_info;
	}
}

//private ICell topology = null;

public ICell Topology {
	get {
		//if (this.topology == null)
		//	this.topology = (ICell) Services.getPort("topology");
		return (ICell) Slice["topology"]; //this.topology;
	}
}

//private IProblemDefinition<I, C> problem_data = null;

public IProblemDefinition<I, C> Problem_data {
	get {
		//if (this.problem_data == null)
		//{
		//	this.problem_data = (IProblemDefinition<I, C>) Services.getPort("problem_data");
		//}
		return (IProblemDefinition<I, C>) Slice["problem_data"]; // this.problem_data;
	}
}

//private IBuffer output_buffer_forward = null;

protected IBuffer Output_buffer_forward {
	get {
		//if (this.output_buffer_forward == null)
		//	this.output_buffer_forward = (IBuffer) Services.getPort("output_buffer_forward");
		return (IBuffer) Slice["output_buffer_forward"]; //this.output_buffer_forward;
	}
}

//private IBuffer input_buffer_forward = null;

protected IBuffer Input_buffer_forward {
	get {
		//if (this.input_buffer_forward == null)
		//	this.input_buffer_forward = (IBuffer) Services.getPort("input_buffer_forward");
		return (IBuffer) Slice["input_buffer_forward"] ;//this.input_buffer_forward;
	}
}

//private IBuffer output_buffer_backward = null;

protected IBuffer Output_buffer_backward {
	get {
		//if (this.output_buffer_backward == null)
		//	this.output_buffer_backward = (IBuffer) Services.getPort("output_buffer_backward");
		return (IBuffer) Slice["output_buffer_backward"]; //this.output_buffer_backward;
	}
}

//private IBuffer input_buffer_backward = null;

protected IBuffer Input_buffer_backward {
	get {
	//	if (this.input_buffer_backward == null)
		//	this.input_buffer_backward = (IBuffer) Services.getPort("input_buffer_backward");
		return (IBuffer) Slice["input_buffer_backward"]; // this.input_buffer_backward;
	}
}

//private IForward<I, C, MTH, DIR> forward = null;

protected IForward<I, C, MTH, DIR> Forward {
	get {
		//if (this.forward == null)
		//	this.forward = (IForward<I, C, MTH, DIR>) Services.getPort("forward");
		return (IForward<I, C, MTH, DIR>) Slice["forward"] ; // this.forward;
	}
}

//private IBlockDiagonalMatVecProduct<I, C, DIR, MTH> matvecproduct = null;

protected IBlockDiagonalMatVecProduct<I, C, DIR, MTH> Matvecproduct {
	get {
	//	if (this.matvecproduct == null)
		//	this.matvecproduct = (IBlockDiagonalMatVecProduct<I, C, DIR, MTH>) Services.getPort("matvecproduct");
		return (IBlockDiagonalMatVecProduct<I, C, DIR, MTH>) Slice["matvecproduct"] ; //this.matvecproduct;
	}
}

//private IShift<IForwardDirection> shift_forward = null;

protected IShift<IForwardDirection> Shift_forward {
	get {
	//	if (this.shift_forward == null)
		//	this.shift_forward = (IShift<IForwardDirection>) Services.getPort("shift_forward");
		return (IShift<IForwardDirection>) Slice["shift_forward"]; //this.shift_forward;
	}
}

//private IShift<IBackwardDirection> shift_backward = null;

protected IShift<IBackwardDirection> Shift_backward {
	get {
	//	if (this.shift_backward == null)
		//	this.shift_backward = (IShift<IBackwardDirection>) Services.getPort("shift_backward");
		return (IShift<IBackwardDirection>) Slice["shift_backward"]; // this.shift_backward;
	}
}

//private ILHS<I, C, DIR, MTH> lhs_ = null;

protected ILHS<I, C, DIR, MTH> Lhs {
	get {
	//	if (this.lhs_ == null)
		//	this.lhs_ = (ILHS<I, C, DIR, MTH>) Services.getPort("lhs");
		return (ILHS<I, C, DIR, MTH>) Slice["lhs"];
	}
}

//private IMPIDirect mpi = null;

public IMPIDirect Mpi {
	get {
	//	if (this.mpi == null)
		//	this.mpi = (IMPIDirect) Services.getPort("mpi");
		return (IMPIDirect) Slice["mpi"]; // this.mpi;
	}
}


//private IBackward<I, C, DIR, MTH> backward = null;

protected IBackward<I, C, DIR, MTH> Backward {
	get {
	//	if (this.backward == null)
		//	this.backward = (IBackward<I, C, DIR, MTH>) Services.getPort("backward");
		return (IBackward<I, C, DIR, MTH>) Slice["backward"]; //this.backward;
	}
}

//private IWriteBuffer<I, C, IBackwardDirection, DIR> write_buffer_backward = null;

protected IWriteBuffer<I, C, IBackwardDirection, DIR> Write_buffer_backward {
	get {
	//	if (this.write_buffer_backward == null)
		//	this.write_buffer_backward = (IWriteBuffer<I, C, IBackwardDirection, DIR>) Services.getPort("write_buffer_backward");
		return (IWriteBuffer<I, C, IBackwardDirection, DIR>) Slice["write_buffer_backward"]; //this.write_buffer_backward;
	}
}

//private IReadBuffer<I, C, IBackwardDirection, DIR> read_buffer_backward = null;

protected IReadBuffer<I, C, IBackwardDirection, DIR> Read_buffer_backward {
	get {
	//	if (this.read_buffer_backward == null)
		//	this.read_buffer_backward = (IReadBuffer<I, C, IBackwardDirection, DIR>) Services.getPort("read_buffer_backward");
		return (IReadBuffer<I, C, IBackwardDirection, DIR>) Slice["read_buffer_backward"]; //this.read_buffer_backward;
	}
}

//private IWriteBuffer<I, C, IForwardDirection, DIR> write_buffer_forward = null;

protected IWriteBuffer<I, C, IForwardDirection, DIR> Write_buffer_forward {
	get {
		//if (this.write_buffer_forward == null)
			//this.write_buffer_forward = (IWriteBuffer<I, C, IForwardDirection, DIR>) Services.getPort("write_buffer_forward");
		return (IWriteBuffer<I, C, IForwardDirection, DIR>) Slice["write_buffer_forward"]; //this.write_buffer_forward;
	}
}

//private IReadBuffer<I, C, IForwardDirection, DIR> read_buffer_forward = null;

protected IReadBuffer<I, C, IForwardDirection, DIR> Read_buffer_forward {
	get {
		//if (this.read_buffer_forward == null)
			//this.read_buffer_forward = (IReadBuffer<I, C, IForwardDirection, DIR>) Services.getPort("read_buffer_forward");
		return (IReadBuffer<I, C, IForwardDirection, DIR>) Slice["read_buffer_forward"]; //this.read_buffer_forward;
	}
}

 


}

}
