using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using lu.problem_size.Instance;
using common.problem_size.Class;
using common.direction.Backward;
using lu.ssor.BlockTriangularSolutionWF;

namespace impl.lu.ssor.BlockUpperTriangularSolutionWFImpl { 

public class IBTSUpperImpl<I, C, DIR> : BaseIBTSUpperImpl<I, C, DIR>, IBlockTriangularSolutionWF<I, C, DIR>
where I:IInstance<C>
where C:IClass
where DIR:IBackwardDirection
{

public IBTSUpperImpl() { 

} 

public override void go() { 
	#pragma omp parallel sections
	{
		#pragma omp section
		wavefront.go();
	}

} // end activate method 

}

}
