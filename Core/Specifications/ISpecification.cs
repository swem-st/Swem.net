 using System.Linq.Expressions;

namespace Core.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria {get;}
        List<Expression<Func<T, object>>> Includes {get; }
        
        //Start. In my practice next 4 fields usually was in helper like one class
        Expression<Func<T, object>> OrderBy { get; }
        Expression<Func<T, object>> OrderByDescending { get; }
        
        int Take { get; }
        int Skip { get; }
        bool IsPagingEnabled { get; }
        //end 
    }
}