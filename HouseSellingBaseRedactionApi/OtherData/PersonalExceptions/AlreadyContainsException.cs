using System;

namespace HouseSellingBaseRedactionApi.OtherData.PersonalExceptions
{
    /// <summary>
    /// Fires if the object is already in the database.
    /// </summary>
    public class AlreadyContainsException : Exception
    {
        /// <summary>
        /// Fires if the object is already in the database.
        /// </summary>
        public AlreadyContainsException()
        {

        }
    }
}
