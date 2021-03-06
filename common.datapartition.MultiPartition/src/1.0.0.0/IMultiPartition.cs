using br.ufc.pargo.hpe.kinds;
using common.problem_size.Class;
using common.problem_size.Instance;

namespace common.datapartition.MultiPartition { 

public interface IMultiPartition<I,C> : BaseIMultiPartition<I,C>
		where I:IInstance<C>
		where C:IClass
{

} // end main interface 

} // end namespace 
