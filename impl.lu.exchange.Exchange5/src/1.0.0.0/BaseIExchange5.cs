/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using lu.data.ProblemDefinition;
using lu.problem_size.Instance_LU;
using common.problem_size.Class;
using lu.datapartition.BlocksInfo;
using common.topology.Ring;
using environment.MPIDirect;
using lu.exchange.ExchangePattern5;
using lu.exchange.Exchange2D;
using MPI;

namespace impl.lu.exchange.Exchange5 { 
	public abstract class BaseIExchange5<I, C, E>: Synchronizer, BaseIExchange2D<I, C, E>
	where I:IInstance_LU<C>
	where C:IClass 
	where E:IExchangePattern5
	{	   
		#region data
			protected int nx,ny,nz;
			protected int east, west, south, north;
		    protected Intracommunicator worldcomm;
			override public void initialize(){
				nx = Blocks.nx;
				ny = Blocks.ny;
				nz = Blocks.nz;
			
				worldcomm = this.WorldComm;
			}
		
			override public void post_initialize()
			{
			   east = X.successor;
			   west = X.predecessor;
			   south = Y.successor;
			   north = Y.predecessor;
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
				
		private IBlocksInfo<I, C> blocks = null;
		
		public IBlocksInfo<I, C> Blocks {
			get {
				if (this.blocks == null)
					this.blocks = (IBlocksInfo<I, C>) Services.getPort("blocks_info");
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
		
		private IMPIDirect mpi = null;
		
		public IMPIDirect Mpi {
			get {
				if (this.mpi == null) 
				{
					this.mpi = (IMPIDirect) Services.getPort("mpi");
				}
				return this.mpi;
			}
		}
		
		
		 
	}
}
