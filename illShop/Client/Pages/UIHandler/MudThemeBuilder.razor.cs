using MudBlazor;
using MudBlazor.Utilities;

namespace illShop.Client.Pages.UIHandler
{
    public partial class MudThemeBuilder
    {
        public MudColor _gradientPrimary = "#594AE2";
        public MudColor _gradientSecondary = "#FF4081";
        public MudColor _pickerColor = "#594AE2";

        int degrees = 90;

        bool _isFirstColor = true;

        public void ChangeSelectedColor(MudListItem item)
        {
            if (item.Text == "1")
            {
                _isFirstColor = true;
                _pickerColor = _gradientPrimary;
                UpdateSelectedColor(_gradientPrimary);
            }
            else if (item.Text == "2")
            {
                _isFirstColor = false;
                _pickerColor = _gradientSecondary;
                UpdateSelectedColor(_gradientSecondary);
            }
        }

        public void UpdateSelectedColor(MudColor value)
        {
            _pickerColor = value;

            if (_isFirstColor)
            {
                _gradientPrimary = value;
            }
            else
            {
                _gradientSecondary = value;
            }
        }
    }
}
