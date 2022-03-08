namespace RFQ.Service.Utils
{
    using System.Runtime.InteropServices;
    using Artifacts;

    internal static class Win32API
    {
        /// <summary> Adds or removes an action which will handle incoming console signals.</summary>
        /// <param name="handler"> The console events handler.</param>
        /// <param name="actionFlag"> true will add handler; false will remove it.</param>
        /// <returns> true if the function succeeds; otherwise, false.</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetConsoleCtrlHandler(
            [In]
            [Optional]
            [MarshalAs(UnmanagedType.FunctionPtr)] 
            ConsoleRoutineHandler handler,
            [In]
            [MarshalAs(UnmanagedType.Bool)] 
            bool actionFlag);
    }
}
