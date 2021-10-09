using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using BikeSharing.Application;
using BikeSharing.Application.DTOs.Bicycles;
using BikeSharing.Application.Services.IServices;
using BikeSharingAPI.Enums;
using BikeSharingAPI.Helpers;
using BikeSharingAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace BikeSharingAPI.Controllers
{

    [Route("api/v1/Bicycles")]
    [ApiController]
    public class BicycleController : ControllerBase
    {
        private readonly IBicycleService _BicycleService;

        public BicycleController(IBicycleService bicycleService)
        {
            this._BicycleService = bicycleService;
        }

        /// <summary>
        /// Tum bicyclelarin bir listesini doner.
        /// </summary>
        /// <returns>Json formatinda kullanici listesi.</returns>
        [HttpGet]
        public async Task<IActionResult> GetBicycleList(
            string filter = "",
            string orderByParams = "",
            string fields = ""
            )
        {
            Log.Information(SharedData.LogMessageRequestReceived);

            try
            {
                List<BicycleReadDTO> bicycleReadDTOs = _BicycleService.GetBicycles(filter, orderByParams, fields);
                if (bicycleReadDTOs != null && bicycleReadDTOs.Count > 0)
                {
                    return HelperResponse.GenerateResponse(
                        EnumResponseFormat.JSON,
                        HttpStatusCode.OK,
                        bicycleReadDTOs
                        );
                }
                else
                {
                    Log.Error(SharedData.MessageBicyclesNotFound);

                    return HelperResponse.GenerateResponse(
                        EnumResponseFormat.JSON,
                        HttpStatusCode.NotFound,
                        new ErrorModel { ErrorMessage = SharedData.MessageBicyclesNotFound }
                        );
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);

                return HelperResponse.GenerateResponse(
                    EnumResponseFormat.JSON,
                    HttpStatusCode.InternalServerError,
                    new ErrorModel { ErrorMessage = ex.Message}
                    );
            }
        }

        /// <summary>
        /// Id'si verilen bicyclei doner.
        /// </summary>
        /// <param name="id">Kullanici id'si</param>
        /// <returns>Eger bulursa, bicycle bilgileri json formatinda.</returns>
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetBicycle([FromRoute] Guid id)
        {
            Log.Information(SharedData.LogMessageRequestReceived);

            try
            {
                BicycleReadDTO bicycleReadDTO = _BicycleService.GetBicycle(id);

                if (bicycleReadDTO != null)
                {
                    return HelperResponse.GenerateResponse(
                        EnumResponseFormat.JSON,
                        HttpStatusCode.OK,
                        bicycleReadDTO
                        );
                }
                else
                {
                    Log.Error(SharedData.MessageBicycleNotFound);

                    return HelperResponse.GenerateResponse(
                        EnumResponseFormat.JSON,
                        HttpStatusCode.NotFound,
                        new ErrorModel { ErrorMessage = SharedData.MessageBicycleNotFound }
                        );
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);

                return HelperResponse.GenerateResponse(
                    EnumResponseFormat.JSON,
                    HttpStatusCode.InternalServerError,
                    new ErrorModel { ErrorMessage = ex.Message }
                    );
            }
        }

        /// <summary>
        /// Body'den okudugu model ile yeni bir bicycle yaratir.
        /// </summary>
        /// <param name="bicycleCreateDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateBicycle(
            [FromBody] BicycleCreateDTO bicycleCreateDTO
            )
        {
            Log.Information(SharedData.LogMessageRequestReceived);

            if (_BicycleService.CreateBicycle(bicycleCreateDTO))
            {
                return HelperResponse.GenerateResponse(HttpStatusCode.NoContent);
            }
            else
            {
                Log.Error(SharedData.MessageCantCreateBicycle);

                return HelperResponse.GenerateResponse(
                    EnumResponseFormat.JSON,
                    HttpStatusCode.InternalServerError,
                    new ErrorModel { ErrorMessage = SharedData.MessageCantCreateBicycle }
                    );
            }
        }

        /// <summary>
        /// Id ile eşleştirdiği kaydi verilen degerler ile veritabanında gunceller. Degeri belirtilmeyen
        /// alanlara o alanlarin default degeri atanir.
        /// </summary>
        /// <param name="bicycleUpdateDTO"></param>
        /// <returns>if succeeds 204; if fails 400 or 500</returns>
        [HttpPut]
        public async Task<IActionResult> PutBicycle([FromBody]BicycleUpdateDTO bicycleUpdateDTO)
        {
            Log.Information(SharedData.LogMessageRequestReceived);

            if (_BicycleService.UpdateBicycle(bicycleUpdateDTO, true))
            {
                return HelperResponse.GenerateResponse(HttpStatusCode.NoContent);
            }
            else
            {
                Log.Error(SharedData.MessageCantUpdateBicycle);

                return HelperResponse.GenerateResponse(
                    EnumResponseFormat.JSON,
                    HttpStatusCode.InternalServerError,
                    new ErrorModel { ErrorMessage = SharedData.MessageCantUpdateBicycle }
                    );
            }
        }

        /// <summary>
        /// Id ile eşleştirdiği kaydi verilen degerler ile veritabanında gunceller.
        /// </summary>
        /// <param name="bicycleUpdateDTO"></param>
        /// <returns>if succeeds 204; if fails 400 or 500</returns>
        [HttpPatch]
        public async Task<IActionResult> PatchBicycle([FromBody] BicycleUpdateDTO bicycleUpdateDTO)
        {
            Log.Information(SharedData.LogMessageRequestReceived);

            if (_BicycleService.UpdateBicycle(bicycleUpdateDTO))
            {
                return HelperResponse.GenerateResponse(HttpStatusCode.NoContent);
            }
            else
            {
                Log.Error(SharedData.MessageCantUpdateBicycle);

                return HelperResponse.GenerateResponse(
                    EnumResponseFormat.JSON,
                    HttpStatusCode.InternalServerError,
                    new ErrorModel { ErrorMessage = SharedData.MessageCantUpdateBicycle }
                    );
            }
        }

        /// <summary>
        /// Id'si verilen Bicycle icin veritabanindan silme islemi yapar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteBicycle([FromRoute] Guid id)
        {
            Log.Information(SharedData.LogMessageRequestReceived);

            _BicycleService.DeleteBicycle(id);

            return HelperResponse.GenerateResponse(HttpStatusCode.NoContent);
        }
    }
}