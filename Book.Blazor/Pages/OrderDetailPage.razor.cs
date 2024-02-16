using Book.Blazor.Dialog;
using Book.Blazor.IServices;
using Book.Models.Dtos;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Book.Blazor.Pages
{
    public partial class OrderDetailPage
    {
        [Parameter]
        public string OrderId { get; set; }
        [Inject] IOrderDetailService _ser { get; set; }
        [Inject] IDialogService DialogService { get; set; }
        [Inject] NavigationManager _navigationManager { get; set; }

        public List<OrderDetailDto> orderDetails;

        private MudTable<OrderDetailDto> _table; // để pagination

        protected async override Task OnInitializedAsync()
        {
            orderDetails = await _ser.GetAll(Guid.Parse(OrderId));
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
            var newData = await _ser.GetAll(Guid.Parse(OrderId));
            orderDetails = newData;
        }
        private void PageChanged(int i)
        {
            _table.NavigateTo(i - 1);
        }
        private void Back()
        {
            _navigationManager.NavigateTo("https://localhost:5001/Order");
        }

    }
}
