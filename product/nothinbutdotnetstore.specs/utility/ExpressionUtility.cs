using System;
using System.Linq.Expressions;
using System.Reflection;
using Machine.Specifications.DevelopWithPassion.Extensions;

namespace nothinbutdotnetstore.specs.utility
{
    public class ExpressionUtility
    {
        public static ConstructorInfo get_constructor<Item>(Expression<Func<Item>> ctor)
        {
            return ctor.Body.downcast_to<NewExpression>().Constructor;
        }
    }
}