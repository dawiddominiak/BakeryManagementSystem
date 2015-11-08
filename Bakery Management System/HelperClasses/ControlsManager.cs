using System.Collections.Generic;
using System.Windows.Forms;

namespace BakeryManagementSystem.HelperClasses
{
    public static class ControlsManager
    {
        public static void SwitchButtons(IEnumerable<Control> controlList, bool enabled)
        {
            foreach (var control in controlList)
            {
                control.Enabled = enabled;
            }
        }

        public static void EmptyButtons(IEnumerable<Control> controlList)
        {
            foreach (var control in controlList)
            {
                control.Text = "";
            }
        }
    }
}
