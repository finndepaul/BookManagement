using Book.Blazor.Dialog;
using Book.Blazor.IServices;
using Book.Models.Dtos;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Book.Blazor.Pages
{
    public partial class ProductPage
    {
        [Inject] IProductService _ser { get; set; }
        [Inject] IDialogService DialogService { get; set; }

        public List<ProductDto> products;

        private MudTable<ProductDto> _table; // để pagination
        protected async override Task OnInitializedAsync()
        {
            products = await _ser.GetAll();
        }
        public async Task Delete(Guid id)
        {
            var options = new DialogOptions { CloseOnEscapeKey = true };
            var dialog = DialogService.Show<DeleteDialog>("Do u want to ?", options);
            var resultDialog = await dialog.Result;

            if (!resultDialog.Cancelled)
            {
                await _ser.Delete(id);
                await LoadTableData();
            }
        }
        private async Task LoadTableData()
        {
            var newData = await _ser.GetAll();
            products = newData;
        }
        private void PageChanged(int i)
        {
            _table.NavigateTo(i - 1);
        }

        
    }
}
