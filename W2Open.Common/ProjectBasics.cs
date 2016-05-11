using System;

namespace W2Open.Common
{
    /// <summary>
    /// Contains all the basic definitions related to the project.
    /// Mostly, lower level definitions about the patterns used in the code.
    /// </summary>
    public static class ProjectBasics
    {
        /// <summary>
        /// Memory pack layout used to correctly Marshals the raw data into structures.
        /// This is the memory pack alignment used in the game's client, so we have to respect that.
        /// </summary>
        public const int DEFAULT_PACK = 8;

        public const String ROOT_PATH = @"C:\WYD2\W2Open\W2Open Server\";
    }
}