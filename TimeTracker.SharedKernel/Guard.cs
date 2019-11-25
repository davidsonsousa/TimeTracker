using System;

namespace TimeTracker.SharedKernel
{
    public static class Guard
    {
        /// <summary>
        /// Throws exception when value is less or equal zero
        /// </summary>
        /// <param name="value"></param>
        /// <param name="parameterName"></param>
        public static void ForLessEqualZero(int value, string parameterName)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(parameterName);
            }
        }

        /// <summary>
        /// Throws exception when value is greater or equal dateToPrecede
        /// </summary>
        /// <param name="value"></param>
        /// <param name="dateToPrecede"></param>
        /// <param name="parameterName"></param>
        public static void ForPrecedesDate(DateTime value, DateTime dateToPrecede, string parameterName)
        {
            if (value >= dateToPrecede)
            {
                throw new ArgumentOutOfRangeException(parameterName);
            }
        }

        /// <summary>
        /// Throws exception when value is null or empty
        /// </summary>
        /// <param name="value"></param>
        /// <param name="parameterName"></param>
        public static void ForNullOrEmpty(string value, string parameterName)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentOutOfRangeException(parameterName);
            }
        }

        /// <summary>
        /// Throws exception when value is null or white space
        /// </summary>
        /// <param name="value"></param>
        /// <param name="parameterName"></param>
        public static void ForNullOrWhiteSpace(string value, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentOutOfRangeException(parameterName);
            }
        }
    }
}
