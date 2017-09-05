using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DidiDerDenker.BirdsEyeView.Operations
{
    public static class Ensure
    {
        private const string EmptyStringMessage = "Is a Empty String";
        private const string IsNotValueMessage = "The Parameter is the value '{0}'";

        public static void NotNull(object argument, string argumentName = null)
        {
            if (null == argument)
            {
                if (!String.IsNullOrEmpty(argumentName))
                {
                    throw new ArgumentNullException(argumentName);
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }

        public static void NotNullOrEmpty(string argument, string argumentName = null)
        {
            if (String.IsNullOrEmpty(argument))
            {
                if (null == argument)
                {
                    if (!String.IsNullOrEmpty(argumentName)) { throw new ArgumentNullException(argumentName); }
                    else { throw new ArgumentNullException(); }
                }
                else
                {
                    if (!String.IsNullOrEmpty(argumentName)) { throw new ArgumentException(Ensure.EmptyStringMessage, argumentName); }
                    else { throw new ArgumentException(Ensure.EmptyStringMessage); }
                }
            }
        }

        public static void IsType<TType>(object element)
        {
            Ensure.NotNull(element, "element");

            if (!(element is TType))
            {
                throw new ArgumentException();
            }
        }

        public static void IsTrue(bool condition, string message = null)
        {
            if (!condition)
            {
                if (null != message)
                {
                    throw new ArgumentException(message);
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
    }
}
