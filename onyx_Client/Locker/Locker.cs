using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Locker
{
    public class Locker
    {
        [StructLayout(LayoutKind.Sequential)]
        private struct KBDLLHOOKSTRUCT
        {
            public Keys key;
            public int scanCode;
            public int flags;
            public int time;
            public IntPtr extra;
        }
        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int id, LowLevelKeyboardProc callback, IntPtr hMod, uint dwThreadId);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool UnhookWindowsHookEx(IntPtr hook);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hook, int nCode, IntPtr wp, IntPtr lp);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string name);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern short GetAsyncKeyState(Keys key);
        private IntPtr ptrHook;
        private LowLevelKeyboardProc objKeyboardProcess;

        private IntPtr captureKey(int nCode, IntPtr wp, IntPtr lp)
        {
            if (nCode >= 0)
            {
                KBDLLHOOKSTRUCT objKeyInfo = (KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lp, typeof(KBDLLHOOKSTRUCT));
                if (objKeyInfo.key == Keys.RWin
                    || objKeyInfo.key == Keys.LWin
                    || objKeyInfo.key == Keys.Tab && HasAltModifier(objKeyInfo.flags)
                    || objKeyInfo.key == Keys.Escape && (System.Windows.Forms.Control.ModifierKeys & Keys.Control) == Keys.Control)
                {
                    return (IntPtr)1; // if 0 is returned then All the above keys will be enabled
                }
            }
            return CallNextHookEx(ptrHook, nCode, wp, lp);
        }

        bool HasAltModifier(int flags)
        {
            return (flags & 0x20) == 0x20;
        }

        private void DisableCtrlAltDelButtons()
        {
            string sk = @"Software\Microsoft\Windows\CurrentVersion\Policies\System";
            string _sk = @"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer";


            var rk = Registry.CurrentUser.CreateSubKey(sk);
            var _rk = Registry.CurrentUser.CreateSubKey(_sk);
            rk.SetValue("DisableChangePassword", 1, RegistryValueKind.DWord);
            rk.SetValue("DisableLockWorkstation", 1, RegistryValueKind.DWord);
            rk.SetValue("DisableTaskMgr", 1, RegistryValueKind.DWord);
            _rk.SetValue("NoLogoff", 1, RegistryValueKind.DWord);
            rk.Close();
            _rk.Close();
        }

        public void Lock()
        {
            ProcessModule objCurrentModule = Process.GetCurrentProcess().MainModule;
            objKeyboardProcess = new LowLevelKeyboardProc(captureKey);
            ptrHook = SetWindowsHookEx(13, objKeyboardProcess, GetModuleHandle(objCurrentModule.ModuleName), 0);
            DisableCtrlAltDelButtons();
        }
    }
}
