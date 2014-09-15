using System.ComponentModel;
using System.Configuration.Install;

namespace uBizSoft.FileCopy.Server
{
    [RunInstaller(true)]
    public partial class MoveInstaller : Installer
    {
        public MoveInstaller()
        {
            InitializeComponent();
        }
    }
}
