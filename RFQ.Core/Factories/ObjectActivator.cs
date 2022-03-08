namespace RFQ.Core.Factories
{
    delegate TObject ObjectActivator<out TObject>(params object[] args);
}
