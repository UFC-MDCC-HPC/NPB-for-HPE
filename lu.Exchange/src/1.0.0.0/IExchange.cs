using br.ufc.pargo.hpe.kinds;
using lu.problem_size.Instance;
using common.problem_size.Class;
using lu.exchange.ExchangePattern;
using common.direction.Direction;

namespace lu.Exchange { 
	public interface IExchange<I, C, E, DIS> : BaseIExchange<I, C, E, DIS>
	where I:IInstance<C>
	where C:IClass 
	where E:IExchangePattern
	where DIS:IDirection
	{
	   void setParameters(double[,,,] g);
	   void setParameters(double[,,,] g, int k);	   
	   void setParameters(double[,] g, int beg, int fin1);
	   void setParameters(double[,] g, double[,] h, int ibeg, int ifin1, int jbeg, int jfin1);
	}
}
