/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using lu.data.ProblemDefinition;
using lu.problem_size.Instance;
using common.problem_size.Class;
using lu.datapartition.BlocksInfo;
using common.Buffer;
using common.direction.Direction;
using common.direction.Forward;
using lu.ssor.BlockTriangularSolutionWFWork;
using common.topology.Ring;

namespace impl.lu.ssor.BlockLowerTriangularSolutionWFWork { 

public abstract class BaseIBTSLowerWork<DIR, I, C>: Computation, BaseIBTSWork<DIR, I, C>
where DIR:IForwardDirection
where I:IInstance<C>
where C:IClass
{

	#region data
	
		protected int nx,ny,nz;
		protected int north, south, east, west;
		protected int ist,jst,iend,jend;
		protected double [,,,] rsd,d;

		protected double[,,,] ldx;
	    protected double[,,,] ldy;
	    protected double[,,,] ldz;
		
		override public void initialize()
		{            			
			nx = Blocks.nx;
			ny = Blocks.ny;
			nz = Blocks.nz;
            ist  = Blocks.ist;
            jst  = Blocks.jst;                
            iend = Blocks.iend;
            jend = Blocks.jend;
            
            rsd  = Problem.Field_rsd;
            d = Problem.Field_d;
		
			ldx = Problem.Field_c;
			ldy = Problem.Field_b;
			ldz = Problem.Field_a;
			
            X_buffer.Array = new double[5*(iend-ist+1)];
            Y_buffer.Array = new double[5*(jend-jst+1)];
		}
		
		override public void post_initialize()
		{
            north = Y.predecessor;//Blocks.north;
            south = Y.successor;//Blocks.south;
            east  = X.successor;//Blocks.east;
            west  = X.predecessor;//Blocks.west;
		}
		
	#endregion

private IProblemDefinition<I, C> problem = null;

public IProblemDefinition<I, C> Problem {
	get {
		if (this.problem == null)
			this.problem = (IProblemDefinition<I, C>) Services.getPort("problem_data");
		return this.problem;
	}
}

private IBlocksInfo<I,C> blocks = null;

public IBlocksInfo<I,C> Blocks {
	get {
		if (this.blocks == null)
			this.blocks = (IBlocksInfo<I,C>) Services.getPort("blocks_info");
		return this.blocks;
	}
}

private ICell y = null;

public ICell Y {
	get {
		if (this.y == null)
			this.y = (ICell) Services.getPort("y");
		return this.y;
	}
}

private ICell x = null;

public ICell X {
	get {
		if (this.x == null)
			this.x = (ICell) Services.getPort("x");
		return this.x;
	}
}
		
private IBuffer x_buffer = null;

public IBuffer X_buffer {
	get {
		if (this.x_buffer == null)
			this.x_buffer = (IBuffer) Services.getPort("x_buffer");
		return this.x_buffer;
	}
}

private IBuffer y_buffer = null;

public IBuffer Y_buffer {
	get {
		if (this.y_buffer == null)
			this.y_buffer = (IBuffer) Services.getPort("y_buffer");
		return this.y_buffer;
	}
}

private DIR direction = default(DIR);

protected DIR Direction {
	get {
		if (this.direction == null)
			this.direction = (DIR) Services.getPort("direction");
		return this.direction;
	}
}


 


}

}
