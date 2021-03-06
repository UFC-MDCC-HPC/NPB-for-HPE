using br.ufc.pargo.hpe.kinds;
using common.problem_size.Instance;
using common.problem_size.Class;

namespace adi.error.RHSNorm { 

public interface IRHSNorm<I,C> : BaseIRHSNorm<I,C>
where I:IInstance<C>
where C:IClass
{
	double[] xcr { get; }

} // end main interface 

} // end namespace 
