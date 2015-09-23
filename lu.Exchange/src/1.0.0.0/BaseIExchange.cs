/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using lu.data.ProblemDefinition;
using lu.problem_size.Instance;
using common.problem_size.Class;
using common.topology.Ring;
using common.Buffer;
using environment.MPIDirect;
using lu.datapartition.BlocksInfo;
using lu.exchange.ExchangePattern;
using common.direction.Direction;


namespace lu.Exchange 
{ 
	public interface BaseIExchange<I, C, E, DIS> : IComputationKind 
		where I:IInstance<C>
		where C:IClass 
		where E:IExchangePattern
		where DIS:IDirection
	{
	   IProblemDefinition<I, C> Problem {get;}
	   IBlocksInfo Blocks {get;}
	   ICell Y {get;}
	   ICell X {get;}
	   IMPIDirect Mpi {get;}
	}
}
