using Book.Blazor.Dialog;
using Book.Blazor.IServices;
using Book.Models.Requests;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Book.Blazor.Pages.CRUD.Product
{
    public partial class ProductUpdatePage
    {
        [Parameter]
        public string ProductId { get; set; }
        [Inject] IProductService _ser { get; set; }
        [Inject] NavigationManager _navigationManager { get; set; }
        [Inject] IDialogService DialogService { get; set; }

        public ProductUpdateRequest request = new ProductUpdateRequest();

        public async void Update()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true };
            var dialog = DialogService.Show<UpdateDialog>("Do u want to ?", options);
            var resultDialog = await dialog.Result;

            if (!resultDialog.Cancelled)
            {
                var model = await _ser.Update(Guid.Parse(ProductId), request);
                if (model)
                {
                    _navigationManager.NavigateTo("https://localhost:44398/Product"); // url page category ở blazor
                }
            }
        }
        private void Back()
        {
            _navigationManager.NavigateTo("https://localhost:44398/Product");
        }
    }
}
