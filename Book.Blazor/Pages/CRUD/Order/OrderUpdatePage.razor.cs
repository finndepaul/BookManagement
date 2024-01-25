using Book.Blazor.Dialog;
using Book.Blazor.IServices;
using Book.Models.Requests;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Book.Blazor.Pages.CRUD.Order
{
    public partial class OrderUpdatePage
    {
        [Parameter]
        public string OrderId { get; set; }
        [Inject] IOrderService _ser { get; set; }
        [Inject] NavigationManager _navigationManager { get; set; }
        [Inject] IDialogService DialogService { get; set; }

        public OrderUpdateRequest request = new OrderUpdateRequest();

        public async void Update()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true };
            var dialog = DialogService.Show<UpdateDialog>("Do u want to ?", options);
            var resultDialog = await dialog.Result;

            if (!resultDialog.Cancelled)
            {
                var model = await _ser.Update(Guid.Parse(OrderId), request);
                if (model)
                {
                    _navigationManager.NavigateTo("https://localhost:44398/Order"); // url page category ở blazor
                }
            }
        }
        private void Back()
        {
            _navigationManager.NavigateTo("https://localhost:44398/Order");
        }
    }
}
