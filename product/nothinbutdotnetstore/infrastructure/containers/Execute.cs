using System;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public static class Execute
    {
        public delegate ReturnType BlockOfCode<out ReturnType>();
        public delegate void NonValueReturningBlockOfCode();
        public delegate Exception ExceptionFactory(Exception ex);


        public static void with_custom_exception_throwing(NonValueReturningBlockOfCode block_of_code, 
            ExceptionFactory exception_factory)
        {
            try
            {
                block_of_code();
            }
            catch (Exception ex)
            {
                throw exception_factory(ex);
            }
        }

        public static ReturnType with_custom_exception_throwing<ReturnType>(BlockOfCode<ReturnType> t_block_of_code, 
            ExceptionFactory exception_factory)
        {
            ReturnType return_value = default(ReturnType);

            with_custom_exception_throwing(() =>
            {
                return_value = t_block_of_code();
            },exception_factory);

            return return_value;

        }
    }

}