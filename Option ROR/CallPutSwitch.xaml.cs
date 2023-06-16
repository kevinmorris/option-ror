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
            Call.Style = (Style)Resources["Selected"];
            IsCall = true;
        }

        private void Call_Clicked(object sender, EventArgs e)
        {
            IsCall = true;
            Call.Style = (Style)Resources["Selected"];
            Put.Style = null;
            Toggled?.Invoke(this, IsCall);
        }

        private void Put_Clicked(object sender, EventArgs e)
        {
            IsCall = false;
            Put.Style = (Style)Resources["Selected"];
            Call.Style = null;
            Toggled?.Invoke(this, IsCall);
        }
    }
}