/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using bt.solve.BTMethod;
using bt.solve.BinvcRhs;

namespace impl.bt.solve.BinvcRhsImpl { 

public abstract class BaseIBinvcRhsImpl<MTH>: Computation, BaseIBinvcRhs<MTH>
where MTH:IBTMethod
{
		
/*		
private IBlocks blocks = null;

public IBlocks Blocks {
	get {
		if (this.blocks == null)
			this.blocks = (IBlocks) Services.getPort("blocks_info");
		return this.blocks;
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
		 
		 */
		
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
