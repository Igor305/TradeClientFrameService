using BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PresentationLayer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class getImagesController : ControllerBase
    {
        private readonly ITradeClientFrameService _tradeClientFrameService;
        private readonly ITradeClientFrameServiceGoodsService _tradeClientFrameServiceGoodsService;
        private readonly IConfiguration _configuration;

        public getImagesController(ITradeClientFrameService tradeClientFrameService, ITradeClientFrameServiceGoodsService tradeClientFrameServiceGoodsService, IConfiguration configuration)
        {
            _tradeClientFrameService = tradeClientFrameService;
            _tradeClientFrameServiceGoodsService = tradeClientFrameServiceGoodsService;
            _configuration = configuration;
        }

        /// <summary>
        /// Данні за день, місяць та прогноз 
        /// </summary>
        /// <param name="id">Номер магазину</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///      http://cash-img.avrora.lan/getImages/5
        /// 
        /// </remarks>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> getAllInOneImage(int id)
        {
            await _tradeClientFrameService.getAllInOneImage(id);

            Byte[] file_path = System.IO.File.ReadAllBytes(@"Plan.png");                                                                                                                                                                 //  FileStream fs = new FileStream(path, FileMode.Open);
            string file_type = "image/png";
            string file_name = "Plan.png";
            return File(file_path, file_type, file_name);
        }

        /// <summary>
        /// Данні за день, місяць та прогноз для Goods
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <param name="id">Номер магазину</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///      http://cash-img.avrora.lan/getImages/goods?key=example&amp;id=35
        /// 
        /// </remarks>
        /// <returns></returns>
        [HttpGet("goods")]
        public async Task<IActionResult> getAllInOneImageForGoods([Required][FromQuery] string key, [Required][FromQuery]int id)
        {
            if (key != _configuration["Api:Key"])
            {
                return StatusCode(500);
            }

            await _tradeClientFrameService.getAllInOneImageForGoods(id);

            Byte[] file_path = System.IO.File.ReadAllBytes(@"Plan.png");                                                                                                                                                                 //  FileStream fs = new FileStream(path, FileMode.Open);
            string file_type = "image/png";
            string file_name = "Plan.png";
            return File(file_path, file_type, file_name);
        }

        /// <summary>
        /// Данні за день
        /// </summary>
        /// <param name="id">Номер магазину</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///      http://cash-img.avrora.lan/getImages/day/5
        /// 
        /// </remarks>
        /// <returns></returns>
        [HttpGet("day/{id}")]
        public async Task<IActionResult> getImagePerDay(int id)
        {
            await _tradeClientFrameService.getImagePerDay(id);

            Byte[] file_path = System.IO.File.ReadAllBytes(@"PlanDay.png");                                                                                                                                                                 //  FileStream fs = new FileStream(path, FileMode.Open);
            string file_type = "image/png";
            string file_name = "PlanDay.png";
            return File(file_path, file_type, file_name);        
        }

        /// <summary>
        /// Данні за місяць
        /// </summary>
        /// <param name="id">Номер магазину</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///      http://cash-img.avrora.lan/getImages/month/5
        /// 
        /// </remarks>
        /// <returns></returns>
        [HttpGet("month/{id}")]
        public async Task<IActionResult> getImagePerMonth(int id)
        {
            await _tradeClientFrameService.getImagePerMonth(id);

            Byte[] file_path = System.IO.File.ReadAllBytes(@"PlanMonth.png");                                                                                                                                                                 //  FileStream fs = new FileStream(path, FileMode.Open);
            string file_type = "image/png";
            string file_name = "PlanMonth.png";
            return File(file_path, file_type, file_name);
        }

        /// <summary>
        /// Прогноз
        /// </summary>
        /// <param name="id">Номер магазину</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///      http://cash-img.avrora.lan/getImages/forecast/5
        /// 
        /// </remarks>
        /// <returns></returns>
        [HttpGet("forecast/{id}")]
        public async Task<IActionResult> getImagePerForecast(int id)
        {
            await _tradeClientFrameService.getImagePerForecast(id);

            Byte[] file_path = System.IO.File.ReadAllBytes(@"PlanForecast.png");                                                                                                                                                                 //  FileStream fs = new FileStream(path, FileMode.Open);
            string file_type = "image/png";
            string file_name = "PlanForecast.png";
            return File(file_path, file_type, file_name);
        }

        /// <summary>
        /// Данні за день, місяць та прогноз для Goods зі зміною кольору
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <param name="id">Номер магазину</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///      http://cash-img.avrora.lan/getImages/goods?key=example&amp;id=35
        /// 
        /// </remarks>
        /// <returns></returns>
        [HttpGet("goods/colored")]
        public async Task<IActionResult> getImageForGoodsColored([Required][FromQuery] string key, [Required][FromQuery] int id)
        {
            if (key != _configuration["Api:Key"])
            {
                return StatusCode(500);
            }

            await _tradeClientFrameServiceGoodsService.getImageColored(id);

            Byte[] file_path = System.IO.File.ReadAllBytes(@"PlanShops.svg");                                                                                                                                                                 //  FileStream fs = new FileStream(path, FileMode.Open);
            string file_type = "image/svg";
            string file_name = "PlanShops.svg";
            return File(file_path, file_type, file_name);
        }
    }
}