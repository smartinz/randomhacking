using System;
using System.Linq.Expressions;

namespace SpikeWpf
{
	static public class Member
	{
		static private string GetMemberName(Expression expression)
		{
			switch(expression.NodeType)
			{
				case ExpressionType.MemberAccess:
					var memberExpression = (MemberExpression)expression;
					string supername = GetMemberName(memberExpression.Expression);

					if(String.IsNullOrEmpty(supername))
					{
						return memberExpression.Member.Name;
					}

					return String.Concat(supername, '.', memberExpression.Member.Name);

				case ExpressionType.Call:
					var callExpression = (MethodCallExpression)expression;
					return callExpression.Method.Name;

				case ExpressionType.Convert:
					var unaryExpression = (UnaryExpression)expression;
					return GetMemberName(unaryExpression.Operand);

				case ExpressionType.Parameter:
					return String.Empty;

				default:
					throw new ArgumentException("The expression is not a member access or method call expression");
			}
		}

		static public string Name<T>(Expression<Func<T, object>> expression)
		{
			return GetMemberName(expression.Body);
		}

		static public string Name<T>(Expression<Action<T>> expression)
		{
			return GetMemberName(expression.Body);
		}

		public static string Name<T>(Expression<Func<T>> expression)
		{
			return GetMemberName(expression.Body);
		}
	}
}