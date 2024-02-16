using Book.Blazor.Dialog;
using Book.Blazor.IServices;
using Book.Models.Requests;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Book.Blazor.Pages.CRUD.Order
{
    public partial class OrderCreatePage
    {
        private OrderCreateRequest request = new OrderCreateRequest();
        [Inject] IOrderService _ser { get; set; }
        [Inject] NavigationManager _navigationManager { get; set; }
        [Inject] IDialogService DialogService { get; set; }

        private async void CreateNew()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true };
            var dialog = DialogService.Show<CreateDialog>("Do u want to ?", options);
            var resultDialog = await dialog.Result;
            if (!resultDialog.Cancelled)
            {
                var model = await _ser.CreateNew(request);
                // tạo mới rồi tự trờ về trang
                if (model)
                {
                    _navigationManager.NavigateTo("https://localhost:5001/Order");
                }
            }


        }
        private void Back()
        {
            _navigationManager.NavigateTo("https://localhost:5001/Order");
        }
    }
}
