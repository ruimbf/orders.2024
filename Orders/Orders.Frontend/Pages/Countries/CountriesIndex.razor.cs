﻿using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Orders.Frontend.Repositories;
using Orders.Shared.Entities;
using System.Net;

namespace Orders.Frontend.Pages.Countries
{
    public partial class CountriesIndex
    {
        [Inject] private IRepository Repository { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;

        public List<Country>? Countries { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadAsync();
        }

        private async Task LoadAsync()
        {
            var responseHttp = await Repository.GetAsync<List<Country>>("api/countries");
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Erro", message, SweetAlertIcon.Error);
                return;
            }
            Countries = responseHttp.Response;
        }


        private async Task DeleteAsync(Country country)
        {
            var result = await SweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = "Confirmação",
                Text = $"Deseja eliminar o país {country.Name}?",
                Icon = SweetAlertIcon.Question,
                ShowCancelButton = true,
            });
            if (result.IsDismissed)
            {
                return;
            }
            var responseHttp = await Repository.DeleteAsync<Country>($"/api/countries/{country.Id}");
            if (responseHttp.Error)
            {
                var messageError = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Erro", messageError, SweetAlertIcon.Error);
                return;
            }

            await LoadAsync();
            var toast = SweetAlertService.Mixin(new SweetAlertOptions
            {
                Toast = true,
                Position = SweetAlertPosition.BottomEnd,
                ShowConfirmButton = true,
                Timer = 1500,
            });
            await toast.FireAsync(icon: SweetAlertIcon.Success, message: "Registo eliminado com êxito.");
        }
    }
}