namespace RFQ.Service.Artifacts
{
    using System.Runtime.InteropServices;
    using Options;

    [return: MarshalAs(UnmanagedType.Bool)]
    internal delegate bool ConsoleRoutineHandler([In][MarshalAs(UnmanagedType.U4)]ConsoleEvent dwCtrlType);
}
