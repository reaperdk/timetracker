using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.WcfContract;
using System.ServiceModel;

namespace TimeTracker.Wrapper.WcfWrapperConnection
{
    public interface IWcfConnectionService : IDisposable
    {
        /// <summary>
        /// Class that can create channel
        /// </summary>
        ChannelFactory<IWcfContract> RemoteFactory { get; set; }

        /// <summary>
        /// Class that can use Contract's method.
        /// </summary>
        IWcfContract RemoteProxy { get; set; }
    }
}
