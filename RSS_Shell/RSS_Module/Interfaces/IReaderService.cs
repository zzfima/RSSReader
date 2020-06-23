using System.Collections.Generic;

namespace RSS_Module.Interfaces
{
    public interface IWEBReaderService<T>
    {
        IList<T> GetLatest(string url);
    }
}
