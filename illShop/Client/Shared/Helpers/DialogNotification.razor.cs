﻿using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace illShop.Client.Shared.Helpers
{
    public partial class DialogNotification
    {
        [CascadingParameter]
        public MudDialogInstance MudDialog { get; set; }
        [Parameter]
        public string Content { get; set; }
        [Parameter]
        public string ButtonText { get; set; }
        [Parameter]
        public Color ButtonColor { get; set; }
        private void Submit() =>
            MudDialog.Close(DialogResult.Ok(true));
        private void Cancel() =>
            MudDialog.Close(DialogResult.Ok(false));
    }
}
