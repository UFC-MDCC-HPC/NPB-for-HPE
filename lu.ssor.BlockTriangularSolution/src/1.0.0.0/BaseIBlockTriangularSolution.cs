/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using lu.data.ProblemDefinition;
using lu.problem_size.Instance;
using common.problem_size.Class;
using lu.datapartition.BlocksInfo;
using common.topology.Ring;
using common.direction.Direction;
using environment.MPIDirect;

namespace lu.ssor.BlockTriangularSolution { 
	public interface BaseIBlockTriangularSolution<DIS, I, C> : IComputationKind 
	where I:IInstance<C>
	where C:IClass
	where DIS:IDirection{
		IProblemDefinition<I, C> Problem {get;}
		IBlocksInfo Blocks {get;}
		ICell X {get;}
		ICell Y {get;}
		IMPIDirect Mpi {get;}
	}
}
