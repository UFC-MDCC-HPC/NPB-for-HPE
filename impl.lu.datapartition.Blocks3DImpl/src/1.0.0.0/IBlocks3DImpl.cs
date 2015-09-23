using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using lu.problem_size.Instance_LU;
using common.problem_size.Class;
using lu.datapartition.Blocks3D;

namespace impl.lu.datapartition.Blocks3DImpl 
{ 
	public class IBlocks3DImpl<I, C> : BaseIBlocks3DImpl<I, C>, IBlocks3D<I, C>
		where I:IInstance_LU<C>
		where C:IClass 
	{
		
	}
}