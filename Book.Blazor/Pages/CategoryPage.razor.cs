using Book.Blazor.Dialog;
using Book.Blazor.IServices;
using Book.Models.Dtos;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using static MudBlazor.CategoryTypes;

namespace Book.Blazor.Pages
{
    public partial class CategoryPage // thêm partial vào tk đần
    {
        [Inject] ICategoryService _ser {  get; set; }
        [Inject] IDialogService DialogService { get; set; }

        public List<CategoryDto> categories;

        private MudTable<CategoryDto> _table; // để pagination
        protected override async Task OnInitializedAsync()
        {
            categories = await _ser.GetAll();           
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
            categories = newData;
        }
        private void PageChanged(int i)
        {
            _table.NavigateTo(i - 1);
        }
        
    }
}
