using RVTLibrary.Objects;

namespace RVTLBBusinessLayer.Sender
{
    public interface ISender
    {
        string Send(Node node, object package);
    }
}
