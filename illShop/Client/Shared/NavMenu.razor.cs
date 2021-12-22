using Microsoft.AspNetCore.Components;

namespace illShop.Client.Shared
{
    public partial class NavMenu
    {
        [Parameter]
        public bool SideBarOpen { get; set; }
    }
}
