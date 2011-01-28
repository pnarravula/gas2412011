using System;
using System.Linq;
using System.Linq.Expressions;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Extensions;
using Machine.Specifications.DevelopWithPassion.Rhino;

namespace nothinbutdotnetstore.specs.infrastructure
{
    public class ExpressionSpecs
    {
        public abstract class concern : Observes
        {
        }

        public class when_playing_with_expression : concern
        {
            It should_find_all_even_numbers = () =>
            {
                ParameterExpression parameter = Expression.Parameter(typeof(int), "x");
                ConstantExpression number_2 = Expression.Constant(2);
                BinaryExpression modulo = Expression.Modulo(parameter, number_2);
                BinaryExpression equals = Expression.Equal(modulo, Expression.Constant(0));
                var is_even = Expression.Lambda<Func<int, bool>>(equals, parameter);

                Func<int, bool> generated = is_even.Compile();
                Func<int,bool> explicit_block = x => x%2 == 0;

                Enumerable.Range(1, 100).Where(generated).Count().ShouldEqual(50);
                Enumerable.Range(1, 100).Where(explicit_block).Count().ShouldEqual(50);

            };

            It should_be_able_to_get_the_name_of_property_pointed_at = () =>
            {
                get_property_name_on<Person, string>(x => x.name)
                    .ShouldEqual("name");
            };
        }

        public static string get_property_name_on<Item, PropertyType>(Expression<Func<Item, PropertyType>> accessor)
        {
            return accessor.Body.downcast_to<MemberExpression>().Member.Name;
        }

        public class Person
        {
            public string name { get; set; }
            public int age { get; set; }
            public DateTime birthday { get; set; }
        }
    }
}