using br.ufc.pargo.hpe.kinds;
using common.problem_size.Instance;
using common.problem_size.Class;
using common.axis.Axis;
using common.solve.SolvingMethod;

namespace bt.solve.PackBackSubInfo { 
	public interface IPackBackSubInfo<I, C, DIR, MTH> : BaseIPackBackSubInfo<I, C, DIR, MTH>
	where I:IInstance<C>
	where C:IClass
	where DIR:IAxis
	where MTH:ISolvingMethod 
	{
	} // end main interface 
} // end namespace 
