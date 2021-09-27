using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Data;
using System.Runtime.InteropServices;
using System.IO;

namespace onyx_Client_UI.ViewModel
{
    public class ServiceBaseVM : PageBaseVM
    {
        //hierarhy purpose only
    }
    public class SystemVM : ServiceBaseVM
    {

        public string Logo
        {
            get
            {
                //Надо ли?

                return string.Empty;
            }
        }


        [DllImport("advapi32.dll", EntryPoint = "InitiateSystemShutdownEx")]
        static extern int InitiateSystemShutdown(string lpMachineName, string lpMessage, int dwTimeout, bool bForceAppsClosed, bool bRebootAfterShutdown);

        [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
        internal static extern bool AdjustTokenPrivileges(IntPtr htok, bool disall,
        ref TokPriv1Luid newst, int len, IntPtr prev, IntPtr relen);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        internal static extern IntPtr GetCurrentProcess();

        [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
        internal static extern bool OpenProcessToken(IntPtr h, int acc, ref IntPtr phtok);

        [DllImport("advapi32.dll", SetLastError = true)]
        internal static extern bool LookupPrivilegeValue(string host, string name, ref long pluid);

        [DllImport("user32.dll", EntryPoint = "LockWorkStation")]
        static extern bool LockWorkStation();

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct TokPriv1Luid
        {
            public int Count;
            public long Luid;
            public int Attr;
        }

        internal const int SE_PRIVILEGE_ENABLED = 0x00000002;
        internal const int TOKEN_QUERY = 0x00000008;
        internal const int TOKEN_ADJUST_PRIVILEGES = 0x00000020;
        internal const string SE_SHUTDOWN_NAME = "SeShutdownPrivilege";

        // public System.Activities.Bookmark BmCommand = null;

      

      

        void Alert(string text)
        {
            throw new NotImplementedException();
        }

        ICommand _cmdAppExit = null;
        public ICommand CmdAppExit
        {
            get
            {
                return _cmdAppExit ?? (_cmdAppExit = new Command(() =>
                {
                    throw new NotImplementedException();

                }
                ));
            }
        }

        ICommand _cmdSystemRestart = null;
        public ICommand CmdSystemRestart
        {
            get
            {
                return _cmdSystemRestart ?? (_cmdSystemRestart = new Command(() =>
                {
                    throw new NotImplementedException();
                }));
            }
        }

        ICommand _cmdSystemShutdown = null;
        public ICommand CmdSystemShutdown
        {
            get
            {
                return _cmdSystemShutdown ?? (_cmdSystemShutdown = new Command(() =>
                {
                    throw new NotImplementedException();
                }));
            }
        }


    }
}
