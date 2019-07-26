using PCConfigurationTool.Core.Interfaces.Basis;
using System.Windows.Forms;

namespace PCConfigurationTool.Core.Interfaces
{
    public interface IFormManager
    {
        void ShowModelessForm<TForm>() where TForm : IView;
        DialogResult ShowModalForm<TForm>() where TForm : IView;
    }
}
