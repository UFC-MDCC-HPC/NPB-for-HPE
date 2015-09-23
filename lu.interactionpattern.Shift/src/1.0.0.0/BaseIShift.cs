/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using common.Buffer;
using common.topology.Ring;
using common.direction.Direction;

namespace lu.interactionpattern.Shift { 

public interface BaseIShift<DIR> : ISynchronizerKind 
where DIR:IDirection
{

	IBuffer Output_buffer {get;}
	IBuffer Input_buffer {get;}
	ICell X {get;}
	ICell Y {get;}
	IMPIDirect Mpi {get;}


} // end main interface 

} // end namespace 
