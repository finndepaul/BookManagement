using Book.Blazor.Dialog;
using Book.Blazor.IServices;
using Book.Models.Dtos;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Book.Blazor.Pages
{
    public partial class OrderPage
    {
        [Inject] IOrderService _ser { get; set; }
        [Inject] IDialogService DialogService { get; set; }

        public List<OrderDto> orders;

        private MudTable<OrderDto> _table; // để pagination
        protected async override Task OnInitializedAsync()
        {
            orders = await _ser.GetAll();
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
            orders = newData;
        }
        private void PageChanged(int i)
        {
            _table.NavigateTo(i - 1);
        }

        
    }
}
