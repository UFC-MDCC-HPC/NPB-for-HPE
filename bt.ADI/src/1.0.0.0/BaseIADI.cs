 /* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using common.topology.Ring;
using common.datapartition.MultiPartitionCells;
using environment.MPIDirect;
using adi.data.ProblemDefinition;
using bt.problem_size.Instance_BT;
using common.problem_size.Class;

namespace bt.ADI { 

public interface BaseIADI<C> : IComputationKind 
where C:IClass
{

	ICell Cell {get;}
	ICell Z {get;}
	ICell Y {get;}
	ICell X {get;}
	ICells Cells {get;}
	IMPIDirect Mpi {get;}
	IProblemDefinition<IInstance_BT<C>, C> Problem {get;}


} // end main interface 

} // end namespace 
