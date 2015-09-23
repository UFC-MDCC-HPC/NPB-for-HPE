/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using common.interactionpattern.Wavefront;
using lu.ssor.BlockTriangularSolutionWFWork;
using lu.problem_size.Instance;
using common.problem_size.Class;
using common.direction.Backward;
using common.interactionpattern.wavefront.WavefrontWork;
using environment.MPIDirect;
using lu.ssor.BlockTriangularSolutionWF;

namespace impl.lu.ssor.BlockUpperTriangularSolutionWFImpl { 

public abstract class BaseIBTSUpperImpl<I, C, DIR>: Computation, BaseIBlockTriangularSolutionWF<I, C, DIR>
where I:IInstance<C>
where C:IClass
where DIR:IBackwardDirection
{

private IWavefront<IBTSWork<I, C>, DIR> wavefront = null;

protected IWavefront<IBTSWork<I, C>, DIR> Wavefront {
	get {
		if (this.wavefront == null)
			this.wavefront = (IWavefront<IBTSWork<I, C>, DIR>) Services.getPort("wavefront");
		return this.wavefront;
	}
}

private IWavefrontWork wavefront_work = null;

public IWavefrontWork Wavefront_work {
	get {
		if (this.wavefront_work == null)
			this.wavefront_work = (IWavefrontWork) Services.getPort("work");
		return this.wavefront_work;
	}
}

private IMPIDirect mpi = null;

public IMPIDirect Mpi {
	get {
		if (this.mpi == null)
			this.mpi = (IMPIDirect) Services.getPort("mpi");
		return this.mpi;
	}
}


abstract public void go(); 


}

}
