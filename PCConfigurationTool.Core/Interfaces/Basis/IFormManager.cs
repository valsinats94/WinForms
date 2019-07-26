using PCConfigurationTool.Core.Interfaces.Basis;
using System.Windows.Forms;

namespace PCConfigurationTool.Core.Interfaces
{
    public interface IFormManager
    {
        void ShowModelessForm<TForm>(Form formParam = null) where TForm : Form;
        DialogResult ShowModalForm<TForm>(Form formParam = null) where TForm : Form;
    }
}
