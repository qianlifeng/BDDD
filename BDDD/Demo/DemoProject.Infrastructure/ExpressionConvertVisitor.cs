using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DemoProject.Infrastructure
{
    public class ExpressionConvertVisitor<TOld,TNew> : ExpressionVisitor
    {
        public ParameterExpression NewParameterExp { get; set; }

        public ExpressionConvertVisitor(ParameterExpression newParameterExp)
        {
            NewParameterExp = newParameterExp;
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            return NewParameterExp;
        }

        protected override Expression VisitMemberAccess(MemberExpression node)
        {
            if (node.Member.DeclaringType == typeof (TOld))
            {
                return Expression.MakeMemberAccess(Visit(node.Expression),
                                                   typeof (TNew).GetMember(node.Member.Name).FirstOrDefault());
            }
            return base.VisitMemberAccess(node);
        }


    }
}
