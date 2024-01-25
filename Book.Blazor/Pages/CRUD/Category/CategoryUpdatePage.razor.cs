using Book.Blazor.Dialog;
using Book.Blazor.IServices;
using Book.Models.Requests;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Book.Blazor.Pages.CRUD.Category
{
    public partial class CategoryUpdatePage
    {
        [Parameter]
        public string CategoryId { get; set; }
        [Inject] ICategoryService _ser { get; set; }
        [Inject] NavigationManager _navigationManager { get; set; }
        [Inject] IDialogService DialogService { get; set; }

        public CategoryUpdateRequest request = new CategoryUpdateRequest();

        public async void Update()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true };
            var dialog = DialogService.Show<UpdateDialog>("Do u want to ?", options);
            var resultDialog = await dialog.Result;

            if (!resultDialog.Cancelled)
            {
                var model = await _ser.Update(Guid.Parse(CategoryId), request);
                if (model)
                {
                    _navigationManager.NavigateTo("https://localhost:44398/category"); // url page category ở blazor
                }
            }
        }
        private void Back()
        {
            _navigationManager.NavigateTo("https://localhost:44398/category");
        }
    }
}
