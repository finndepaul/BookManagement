using Book.Blazor.Dialog;
using Book.Blazor.IServices;
using Book.Models.Requests;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Book.Blazor.Pages.CRUD.Product
{
    public partial class ProductCreatePage
    {
        private ProductCreateRequest request = new ProductCreateRequest();
        [Inject] IProductService _ser { get; set; }
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
                    _navigationManager.NavigateTo("https://localhost:44398/Product");
                }
            }


        }
        private void Back()
        {
            _navigationManager.NavigateTo("https://localhost:44398/Product");
        }
    }
}
