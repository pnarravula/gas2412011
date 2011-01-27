using System;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public class DependencyCreationException : Exception
    {
        public DependencyCreationException(Type dependency, Exception innerException):base(string.Empty,innerException)
        {
            type_that_could_not_be_created_correctly = dependency;
        }
        public Type type_that_could_not_be_created_correctly { get; private set; }
    }
}