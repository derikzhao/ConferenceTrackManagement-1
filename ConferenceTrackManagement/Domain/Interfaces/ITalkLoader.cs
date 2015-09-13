using System.Collections.Generic;

namespace ConferenceTrackManagement.Domain.Interfaces
{
    public interface ITalkLoader
    {
        IEnumerable<Talk> Load();
    }
}
