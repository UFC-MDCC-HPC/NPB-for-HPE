using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using bt.problem_size.Instance_BT;
using common.problem_size.Class_A;
using common.problem_size.Instance;

namespace impl.bt.problem_size.Instance_BT_A { 

public class IInstance_BT_A_Impl<C> : BaseIInstance_BT_A_Impl<C>, IInstance_BT<C>
        where C:IClass_A
{

public IInstance_BT_A_Impl() { 

} 

private int _problem_size = 64;
private int _niter_default = 200;
private	double _dt_default = 0.0008;	
private PROBLEM_CLASS _CLASS_ = PROBLEM_CLASS.A;
		
public int problem_size { get { return _problem_size; } }
public int niter_default { get { return _niter_default; } }
public double dt_default { get { return _dt_default; } }		
public PROBLEM_CLASS CLASS { get { return _CLASS_; } }		

private	double[] _xcrref_ = {1.0806346714637264E+02d, 1.1319730901220813E+01d, 2.5974354511582465E+01d, 2.3665622544678910E+01d, 2.5278963211748344E+02d}; //    Reference values of RMS-norms of residual.
private double[] _xceref_ = {4.2348416040525025E+00d, 4.4390282496995698E-01d, 9.6692480136345650E-01d, 8.8302063039765474E-01d, 9.7379901770829278E+00d}; //    Reference values of RMS-norms of solution error.
private	double _dtref_ = 0.0008;

public double[] xcrref { get { return _xcrref_; } } 
public double[] xceref { get { return _xceref_; } }
public double dtref { get { return _dtref_; } }

}

}
