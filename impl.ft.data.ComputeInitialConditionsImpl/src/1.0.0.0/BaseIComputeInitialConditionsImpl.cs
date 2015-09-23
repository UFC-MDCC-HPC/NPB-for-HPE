/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using ft.datapartition.BlocksInfo;
using ft.data.ProblemDefinition;
using ft.problem_size.Instance_FT;
using common.problem_size.Class;
using ft.problem_size.Instance;
using ft.data.ComputeInitialConditions;

namespace impl.ft.data.ComputeInitialConditionsImpl { 
	public abstract class BaseIComputeInitialConditionsImpl<I, C>: Computation, BaseIComputeInitialConditions<I, C>
	where I:IInstance_FT<C>
	where C:IClass{
	   
		#region data
		    protected double[, , ,] u1;
			protected int nx, ny, nz, size1, size2, REAL, IMAG;
			protected int[] ystart, zstart;
			protected int[,] dims;
			override public void initialize(){
			    u1 = Problem.Field_u1;
				nx = Instance.nx;
				ny = Instance.ny;
				nz = Instance.nz;
				size1 = Blocks.size1;
				size2 = Blocks.size2;
				REAL = Constants.REAL;
				IMAG = Constants.IMAG;
				ystart = Blocks.ystart;
				zstart = Blocks.zstart;
				dims = Blocks.dims;
			}
		#endregion
	
		private IBlocks<I,C> blocks = null;
		
		public IBlocks<I,C> Blocks {
			get {
				if (this.blocks == null)
					this.blocks = (IBlocks<I,C>) Services.getPort("blocks_info");
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
		
		private I instance = default(I);
		
		protected I Instance {
			get {
				if (this.instance == null)
					this.instance = (I) Services.getPort("instance_type");
				return this.instance;
			}
		}
		 
	}
}
