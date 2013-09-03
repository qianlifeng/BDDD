using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DemoProject.Infrastructure
{
   public static class ExpressionConvertor<TOld,TNew>
   {
       private static Expression<Func<TNew, bool>> newExpression;

       public static Expression<Func<TNew, bool>> Convert(Expression<Func<TOld, bool>> oldExpression)
       {
           if (newExpression == null)
           {
               var visitor = new ExpressionConvertVisitor<TOld, TNew>(Expression.Parameter(typeof (TNew),oldExpression.Parameters[0].Name));
               newExpression = Expression.Lambda<Func<TNew, bool>>(visitor.Visit(oldExpression.Body), visitor.NewParameterExp);
           }

           return newExpression;
       }
    }
}
