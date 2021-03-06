/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using ft.datapartition.BlocksInfo;
using ft.data.ProblemDefinition;
using ft.problem_size.Instance;
using common.problem_size.Class;
using common.axis.Axis;

namespace ft.fft.TransposeGlobal { 
	public interface BaseITransposeGlobal<I, C, DIR> : IComputationKind 
	where I:IInstance<C>
	where C:IClass
	where DIR:IAxis{
	
		IBlocks<I,C> Blocks {get;}
		IProblemDefinition<I, C> Problem {get;}
	}
}
