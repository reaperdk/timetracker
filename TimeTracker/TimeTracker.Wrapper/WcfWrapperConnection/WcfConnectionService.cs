﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.WcfContract;
using System.ServiceModel;

namespace TimeTracker.Wrapper.WcfWrapperConnection
{
    public class WcfConnectionService : IWcfConnectionService
    {
        private ChannelFactory<IWcfContract> _remoteFactory;
        private IWcfContract _remoteProxy;

        public ChannelFactory<IWcfContract> RemoteFactory
        {
            get { return _remoteFactory; }
            set { _remoteFactory = value; }
        }

        public IWcfContract RemoteProxy
        {
            get { return _remoteProxy; }
            set { _remoteProxy = value; }
        }

        public void SetConnection()
        {
            if (_remoteFactory != null)
            {
                throw new Exception("Connection is not null. Did you closed connection?");
            }

            _remoteFactory = new ChannelFactory<IWcfContract>("TimeTrackerWcfConfiguration");
            _remoteProxy = _remoteFactory.CreateChannel();
        }

        public void CloseConnection()
        {
            try
            {
                _remoteFactory.Close();
                _remoteFactory = null;
            }
            catch
            {
                if (_remoteFactory != null)
                {
                    _remoteFactory.Abort();
                    _remoteFactory = null;
                }
            }
        }
    }
}
