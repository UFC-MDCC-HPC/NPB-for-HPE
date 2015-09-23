/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using common.datapartition.MultiPartitionCells;
using adi.data.ProblemDefinition;
using bt.problem_size.Instance_BT;
using common.problem_size.Class;
using bt.solve.BinvRhs;
using bt.solve.BTMethod;
using bt.solve.MatMulSub;
using common.axis.Axis;
using bt.solve.LhsABInit;
using bt.solve.BinvcRhs;
using bt.solve.MatVecSub;
using common.axis.ZAxis;
using bt.solve.SolverCell;
using adi.solve.IterationControl;
using common.direction.Forward;
using common.data.Field;

namespace impl.bt.solve.ZSolverCell { 
	public abstract class BaseIZSolverCell<I, C, DIR, MTH>: Computation, BaseISolverCell<I, C, DIR, MTH>
	where I:IInstance_BT<C>
	where C:IClass
	where DIR:IZ
	where MTH:IBTMethod {
		#region data
		
			protected int MAX_CELL_DIM, KMAX, JMAX, IMAX, maxcells;
			protected int[,] start, end, cell_size, slice;
			protected double[,,,,] rho_i, u, qs, rhs; 
			
			protected double tx1, tx2, tx3, ty1, ty2, ty3, tz1, tz2, tz3,
			                  c1, c2, c3, c4, c5,
			                  c3c4, con43, c1345, dt,
			                  dx1, dx2, dx3, dx4, dx5, dy1, dy2, dy3, dy4, dy5, dz1, dz2, dz3, dz4, dz5;
            protected double[,,] fjac, njac, lhsa, lhsb;
		
			protected double[,,,,,] lhsc;
		
			override public void initialize()
			{
	            start = Cells.cell_start;
				end = Cells.cell_end;
				cell_size = Cells.cell_size;
				slice = Cells.cell_slice;
			
				MAX_CELL_DIM = Problem.MAX_CELL_DIM;
				KMAX = Problem.KMAX;				
	            rho_i = Problem.Field_rho;
				qs = Problem.Field_qs;	            
				u = Problem.Field_u;
				rhs = Problem.Field_rhs;				
				
				tx1 = Constants.tx1;
				tx2 = Constants.tx2;
				tx3 = Constants.tx3;
				ty1 = Constants.ty1;
				ty2 = Constants.ty2;
				ty3 = Constants.ty3;
				tz1 = Constants.tz1;
				tz2 = Constants.tz2;
				tz3 = Constants.tz3;
				
				c1 = Constants.c1;
				c2 = Constants.c2;
				c3 = Constants.c3;
				c4 = Constants.c4;
				c5 = Constants.c5;
				
				c3c4 = Constants.c3c4;
				con43 = Constants.con43;
				c1345 = Constants.c1345;
				dt = Constants.dt;
				
				dx1 = Constants.dx1;
				dx2 = Constants.dx2;
				dx3 = Constants.dx3;
				dx4 = Constants.dx4;
				dx5 = Constants.dx5;
				
				dy1 = Constants.dy1;
				dy2 = Constants.dy2;
				dy3 = Constants.dy3;
				dy4 = Constants.dy4;
				dy5 = Constants.dy5;
				
				dz1 = Constants.dz1;
				dz2 = Constants.dz2;
				dz3 = Constants.dz3;
				dz4 = Constants.dz4;
				dz5 = Constants.dz5;
			
                fjac = new double[MAX_CELL_DIM+5, 5, 5];
                njac = new double[MAX_CELL_DIM+5, 5, 5];
                lhsa = new double[MAX_CELL_DIM+3, 5, 5];
                lhsb = new double[MAX_CELL_DIM+3, 5, 5];			
			
				Iteration_control.setNumberOfStages(Cells.ncells);		

				KMAX = Problem.KMAX;
				JMAX = Problem.JMAX;
				IMAX = Problem.IMAX;
				maxcells = Problem.maxcells;
			
				Lhsc.initialize_field("lhsc", maxcells, KMAX+2, JMAX+2, IMAX+2, 5, 5);
			}
		#endregion
		
		private IField lhsc_ = null;
		
		protected IField Lhsc {
			get {
				if (lhsc_ == null) 
					lhsc_ = (IField) Services.getPort("lhsc");
				return lhsc_;
			}
		}
		
		private IIterationControl<IForwardDirection> iteration_control = null;
		
		public IIterationControl<IForwardDirection> Iteration_control {
			get {
				if (this.iteration_control == null)
					this.iteration_control = (IIterationControl<IForwardDirection>) Services.getPort("iteration_control");
				return this.iteration_control;
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
		
		private IBinvRhs<MTH> binvrhs = null;
		
		protected IBinvRhs<MTH> Binvrhs {
			get {
				if (this.binvrhs == null)
					this.binvrhs = (IBinvRhs<MTH>) Services.getPort("binvrhs");
				return this.binvrhs;
			}
		}
		
		private IMatMulSub<MTH> matmul_sub = null;
		
		protected IMatMulSub<MTH> Matmul_sub {
			get {
				if (this.matmul_sub == null)
					this.matmul_sub = (IMatMulSub<MTH>) Services.getPort("matmulsub");
				return this.matmul_sub;
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
		
		private ILhsABInit lhsabinit = null;
		
		protected ILhsABInit Lhsabinit {
			get {
				if (this.lhsabinit == null)
					this.lhsabinit = (ILhsABInit) Services.getPort("lhsabinit");
				return this.lhsabinit;
			}
		}
		
		private IBinvcRhs<MTH> binvcrhs = null;
		
		protected IBinvcRhs<MTH> Binvcrhs {
			get {
				if (this.binvcrhs == null)
					this.binvcrhs = (IBinvcRhs<MTH>) Services.getPort("binvcrhs");
				return this.binvcrhs;
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
		
		private IMatVecSub<MTH> matvec_sub = null;
		
		protected IMatVecSub<MTH> Matvec_sub {
			get {
				if (this.matvec_sub == null)
					this.matvec_sub = (IMatVecSub<MTH>) Services.getPort("matvecsub");
				return this.matvec_sub;
			}
		}
		
		public static double pow2(double p) { return p * p; }
		
		 
	}
}
