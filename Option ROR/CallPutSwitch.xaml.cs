using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace Option_ROR
{
    public partial class CallPutSwitch : ContentView
    {
        public event EventHandler<bool> Toggled;

        public bool IsCall { get; set; }

        public CallPutSwitch()
        {
            InitializeComponent();
            IsCall = true;
            VisualStateManager.GoToState(Call, "Focused");
            VisualStateManager.GoToState(Put, "Normal");
        }

        private void Call_Clicked(object sender, EventArgs e)
        {
            IsCall = true;
            VisualStateManager.GoToState(Call, "Focused");
            VisualStateManager.GoToState(Put, "Normal");
            Toggled?.Invoke(this, IsCall);
        }

        private void Put_Clicked(object sender, EventArgs e)
        {
            IsCall = false;
            VisualStateManager.GoToState(Put, "Focused");
            VisualStateManager.GoToState(Call, "Normal");
            Toggled?.Invoke(this, IsCall);
        }
    }
}