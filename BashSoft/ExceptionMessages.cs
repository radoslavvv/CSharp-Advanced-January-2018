using System;
using System.Collections.Generic;
using System.Text;

namespace BashSoft
{
    public static class ExceptionMessages
    {
        public const string ExampleExceptionMessage = "Example message!";

        public const string DataAlreadyInitializedException = "Data already initialized!";

        public const string DataNotInitializedExceptionMessage =
            "The data structure must be initialized first in order to make any operations with it.";

        public const string InexistingCourseInDataBase = "The course you are trying to get does not exist in the data base!";

        public const string InexistingStudentInDataBase =
            "The user name for the student you are trying to get does not exist!";
    }
}
