using RVTLibrary.Objects;
using System.Threading.Tasks;

namespace RVTLBBusinessLayer.Sender
{
    public interface ISender
    {
        Task<string> Send(Node node, object package);
    }
}
