using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading.Tasks;

namespace AllowPermissions
{
    [RunInstaller(true)]
    public partial class Installer1 : System.Configuration.Install.Installer
    {
        public Installer1()
        {
            InitializeComponent();
        }

        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);
        }

        public void RecurseSecurity(FileSystemAccessRule rule, DirectoryInfo din)
        {
            DirectorySecurity fsecurity = Directory.GetAccessControl(din.FullName);
            // Add the new rule to the ACL
            fsecurity.AddAccessRule(rule);
            // Set the ACL back to the file
            Directory.SetAccessControl(din.FullName, fsecurity);

            foreach (FileInfo fin in din.GetFiles())
            {
                FileSecurity fileSec = File.GetAccessControl(fin.FullName);
                fileSec.AddAccessRule(rule);
                File.SetAccessControl(fin.FullName, fileSec);
            }

            foreach (DirectoryInfo rDin in din.GetDirectories())
            {
                RecurseSecurity(rule, rDin);
            }

        }

        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Commit(IDictionary savedState)
        {
            base.Commit(savedState);
            string folder = Context.Parameters["folder"];
            string run_folder = Context.Parameters["run_folder"];
            // This gets the "Authenticated Users" group, no matter what it's called
            SecurityIdentifier sid = new SecurityIdentifier(WellKnownSidType.AuthenticatedUserSid, null);

            // Create the rules
            FileSystemAccessRule writerule = new FileSystemAccessRule(sid, FileSystemRights.Write, AccessControlType.Allow);

            if (!string.IsNullOrEmpty(folder) && Directory.Exists(folder))
            {
                RecurseSecurity(writerule, new DirectoryInfo(folder));

            }
            //System.Windows.Forms.MessageBox.Show("Walla");
            ProcessStartInfo psi = new ProcessStartInfo();
            //System.Windows.Forms.MessageBox.Show(run_folder);
            //psi.WorkingDirectory = @"C:\Program Files (x86)\HAMENAJESET";
            psi.WorkingDirectory = run_folder;
            psi.FileName = "HAMENAJESET.exe";
            Process.Start(psi);
            //System.Windows.Forms.MessageBox.Show("Walla2");
        }

        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Rollback(IDictionary savedState)
        {
            base.Rollback(savedState);
        }

        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState);
        }

    }
}
