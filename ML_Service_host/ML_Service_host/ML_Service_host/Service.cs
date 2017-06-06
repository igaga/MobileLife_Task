using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ComponentModel;
using System.ServiceProcess;
using System.Configuration;
using System.Configuration.Install;


namespace WCF_Service
{
    [ServiceContract(Namespace = "WCF_Service")]
    public class TaxManagementWindowsService : ServiceBase
    {
        public ServiceHost serviceHost = null;
        public TaxManagementWindowsService()
        {
            ServiceName = "Tax Management Service";
        }

        public static void Main()
        {
            ServiceBase.Run(new TaxManagementWindowsService());
        }

        protected override void OnStart(string[] args)
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
            }

            serviceHost = new ServiceHost(typeof(TaxManagement));
            serviceHost.Open();
        }

        protected override void OnStop()
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
                serviceHost = null;
            }
        }
    }

    [RunInstaller(true)]
    public class ProjectInstaller : Installer
    {
        private ServiceProcessInstaller process;
        private ServiceInstaller service;

        public ProjectInstaller()
        {
            process = new ServiceProcessInstaller();
            process.Account = ServiceAccount.LocalSystem;
            service = new ServiceInstaller();
            service.ServiceName = "Tax Management Service";
            Installers.Add(process);
            Installers.Add(service);
        }
    }
}