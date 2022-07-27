using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Client.Helpers
{
    public class MostrarMensajes : IMostrarMensajes
    {
        private readonly IJSRuntime js;

        public MostrarMensajes(IJSRuntime js)
        {
            this.js = js;
        }

        public async Task MostrarMensajeError(string mensaje)
        {
            await MostrarMensaje("Error", mensaje, "error");
        }

        public async Task MostrarMensajeExitoso(string mensaje)
        {
            await MostrarMensaje("Exitoso", mensaje, "success");
        }

        private async ValueTask MostrarMensaje(string titulo, string mensaje, string tipoMensaje)
        {
            await js.InvokeVoidAsync("swal.fire", titulo, mensaje, tipoMensaje);
        }
        public async Task MostrarMensajeBase(string titulo, string mensaje, string tipoMensaje)
        {
            await js.InvokeVoidAsync("Swal.fire", titulo, mensaje, tipoMensaje);
        }

       
        //public async static ValueTask<string> MostrarMensajeConfimacion(this IJSRuntime js,string titulo, string mensaje, string tipoMensaje)
        //{
        //    return await js.InvokeAsync<string>("Swal.fire", titulo, mensaje, tipoMensaje);
        //}

        public async Task MostrarMensajeConImagen(string mensaje)
        {
          await js.InvokeVoidAsync("Swal.fire({title: 'Sweet!',text: 'Modal with a custom image.',imageUrl: '/images/Coberturas/a.png',imageWidth: 400,imageHeight: 200,imageAlt: 'Custom image',})");
        }

       
    }
}
