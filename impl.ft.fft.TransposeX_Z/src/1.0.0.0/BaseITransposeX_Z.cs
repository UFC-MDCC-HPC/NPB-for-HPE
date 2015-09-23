/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using ft.datapartition.BlocksInfo;
using ft.fft.TransposeLocal;
using ft.problem_size.Instance_FT;
using common.problem_size.Class;
using common.axis.X_Z_Axis;
using ft.data.ProblemDefinition;
using ft.fft.TransposeGlobal;
using ft.fft.TransposeFinish;
using ft.fft.Transpose;

namespace impl.ft.fft.TransposeX_Z { 
	public abstract class BaseITransposeX_Z<I, C, DIR>: Computation, BaseITranspose<I, C, DIR>
	where I:IInstance_FT<C>
	where C:IClass
	where DIR:IX_Z_Axis{
	   
		#region data
			protected int[,] dims;
			override public void initialize(){
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
		
		private ITransposeLocal<I, C, DIR> transpose_local = null;
		
		protected ITransposeLocal<I, C, DIR> Transpose_local {
			get {
				if (this.transpose_local == null)
					this.transpose_local = (ITransposeLocal<I, C, DIR>) Services.getPort("transpose_local");
				return this.transpose_local;
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
		
		private ITransposeGlobal<I, C, DIR> transpose_global = null;
		
		protected ITransposeGlobal<I, C, DIR> Transpose_global {
			get {
				if (this.transpose_global == null)
					this.transpose_global = (ITransposeGlobal<I, C, DIR>) Services.getPort("transpose_global");
				return this.transpose_global;
			}
		}
		
		private ITransposeFinish<I, C, DIR> transpose_finish = null;
		
		protected ITransposeFinish<I, C, DIR> Transpose_finish {
			get {
				if (this.transpose_finish == null)
					this.transpose_finish = (ITransposeFinish<I, C, DIR>) Services.getPort("transpose_finish");
				return this.transpose_finish;
			}
		}
		 
	}
}
