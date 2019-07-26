using PCConfigurationTool.Core.Interfaces.ViewModels;
using System.Windows.Forms;
using Unity;

namespace PCConfigurationTool.WinFormsPresentation
{
    public partial class AddComponentForm : Form
    {
        #region Declaration

        IUnityContainer container;
        IAddComponentViewModel addComponentViewModel;

        #endregion

        #region Initialization
        public AddComponentForm(IUnityContainer container)
        {
            this.container = container;
            addComponentViewModel = container.Resolve<IAddComponentViewModel>();
            InitializeComponent();
        }

        #endregion

        #region Properties

        public IAddComponentViewModel AddComponentViewModel
        {
            get
            {                
                return addComponentViewModel;
            }
        }

        #endregion

        #region Methods

        #endregion
    }
}
