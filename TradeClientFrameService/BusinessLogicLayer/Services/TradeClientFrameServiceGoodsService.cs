using Aspose.Svg;
using AutoMapper;
using BusinessLogicLayer.Models;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;
using System;
using System.Drawing.Text;
using System.IO;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class TradeClientFrameServiceGoodsService : ITradeClientFrameServiceGoodsService
    {
        private readonly string SvgNamespace = "http://www.w3.org/2000/svg";
        private readonly string documentPath = Path.Combine("", "PlanShops.svg");

        private readonly IitExecutionPlanShopRepository _iitExecutionPlanShopRepository;
        private readonly ITradeClientFrameService _tradeClientFrameService;
        private readonly IMapper _mapper;

        public TradeClientFrameServiceGoodsService(IitExecutionPlanShopRepository iitExecutionPlanShopRepository, ITradeClientFrameService tradeClientFrameService, IMapper mapper)
        {
            _iitExecutionPlanShopRepository = iitExecutionPlanShopRepository;
            _tradeClientFrameService = tradeClientFrameService;
            _mapper = mapper;
        }

        public async Task getImageColored(int stockId)
        {
            stockId = FirstShop(stockId);

            ItExecutionPlanShop itExecutionPlanShop = await _iitExecutionPlanShopRepository.getInfoForStockId(stockId);

            ItExecutionPlanShopModel itExecutionPlanShopModel = _mapper.Map<ItExecutionPlanShop, ItExecutionPlanShopModel>(itExecutionPlanShop);

            getImage(itExecutionPlanShopModel);
        }

        private int FirstShop(int stockId)
        {
            if (stockId == 1)
            {
                stockId = 100;
            }
            return stockId;
        }

        public void getImage(ItExecutionPlanShopModel itExecutionPlanShopModel)
        {
            PrivateFontCollection pFCollection = new PrivateFontCollection();
            pFCollection.AddFontFile("Montserrat-Black.ttf");
            
            Console.WriteLine(pFCollection.Families[0].Name); 

            using (var document = new SVGDocument())
            {
                var svgElement = document.RootElement;

                svgElement.SetAttribute("height", "1270px");
                svgElement.SetAttribute("width", "450px");

                SVGStyleElement styleElement = (SVGStyleElement)document.CreateElementNS(SvgNamespace, "style");
                styleElement.Type = "text/css";
                //styleElement.SetAttribute("@font-face", "font-family:\"Bitstream Vera Serif Bold\"; src: url(\"https://mdn.mozillademos.org/files/2468/VeraSeBd.ttf\");");

                 // Today          

                SVGTextElement percentForDay = (SVGTextElement)document.CreateElementNS(SvgNamespace, "text");

                percentForDay.SetAttribute("height", "44px");
                percentForDay.SetAttribute("width", "102px");
                percentForDay.SetAttribute("x", "50%");
                percentForDay.SetAttribute("y", "277px");
                percentForDay.SetAttribute("text-anchor", "middle");
                percentForDay.Style.FontFamily = "sans-serif";
                percentForDay.Style.LineHeight = "44px";
                percentForDay.Style.FontSize = "36px";
                percentForDay.Style.FontWeight = "700";
                percentForDay.Style.FontStyle = "normal";

                Decimal decPercentForDay = 0;

                if (itExecutionPlanShopModel != null)
                {
                    decPercentForDay = Convert.ToDecimal(itExecutionPlanShopModel.PercentForDay);
                }

                percentForDay.TextContent = $"{Math.Round(decPercentForDay, 1)}%";
                svgElement.InsertBefore(percentForDay, svgElement.FirstChild);

                SVGTextElement factDayText = (SVGTextElement)document.CreateElementNS(SvgNamespace, "text");

                factDayText.SetAttribute("height", "44px");
                factDayText.SetAttribute("width", "102px");
                factDayText.SetAttribute("x", "180px");
                factDayText.SetAttribute("y", "308px");
                factDayText.Style.FontFamily = "sans-serif";
                factDayText.Style.FontSize = "14px";
                factDayText.Style.FontWeight = "500";
                factDayText.TextContent = $"Факт:";
                svgElement.InsertBefore(factDayText, svgElement.FirstChild);

                SVGTextElement factDay = (SVGTextElement)document.CreateElementNS(SvgNamespace, "text");

                factDay.SetAttribute("height", "44px");
                factDay.SetAttribute("width", "102px");
                factDay.SetAttribute("x", "220px");
                factDay.SetAttribute("y", "309px");
                factDay.Style.FontFamily = "sans-serif";
                factDay.Style.FontSize = "14px";
                factDay.Style.FontWeight = "500";

                Decimal decFactDay = 0;

                if (itExecutionPlanShopModel != null)
                {
                    decFactDay = Convert.ToDecimal(itExecutionPlanShopModel.FactDay);
                }

                string formatFactDay = _tradeClientFrameService.formatDecimal(decFactDay);
                factDay.TextContent = $"{formatFactDay}";

                svgElement.InsertBefore(factDay, svgElement.FirstChild);

                SVGTextElement planDayText = (SVGTextElement)document.CreateElementNS(SvgNamespace, "text");

                planDayText.SetAttribute("height", "44px");
                planDayText.SetAttribute("width", "102px");
                planDayText.SetAttribute("x", "180px");
                planDayText.SetAttribute("y", "328px");
                planDayText.Style.FontFamily = "sans-serif";
                planDayText.Style.FontSize = "14px";
                planDayText.Style.FontWeight = "500";
                planDayText.TextContent = $"План:";
                svgElement.InsertBefore(planDayText, svgElement.FirstChild);

                SVGTextElement planDay = (SVGTextElement)document.CreateElementNS(SvgNamespace, "text");

                planDay.SetAttribute("height", "44px");
                planDay.SetAttribute("width", "102px");
                planDay.SetAttribute("x", "220px");
                planDay.SetAttribute("y", "329px");
                planDay.Style.FontFamily = "sans-serif";
                planDay.Style.FontSize = "14px";
                planDay.Style.FontWeight = "500";

                Decimal decPlanDay = 0;

                if (itExecutionPlanShopModel != null)
                {
                    decPlanDay = Convert.ToDecimal(itExecutionPlanShopModel.PlanDay);
                }

                string formatPlanDay = _tradeClientFrameService.formatDecimal(decPlanDay);
                planDay.TextContent = $"{formatPlanDay}";
                svgElement.InsertBefore(planDay, svgElement.FirstChild);

                SVGCircleElement circleDayStatus = (SVGCircleElement)document.CreateElementNS(SvgNamespace, "circle");

                string colorDay = getColorCircle(decPercentForDay);

                decimal dashDay = 518 - Math.Round(decPercentForDay * 518 / 100);
                decimal dashDayWhite = 0;

                if (dashDay >= 518)
                {
                    dashDayWhite = 518;
                }
                else
                {
                    dashDayWhite = dashDay - 6;
                }
                circleDayStatus.Cx.BaseVal.Value = 220.5F;
                circleDayStatus.Cy.BaseVal.Value = 285.5F;
                circleDayStatus.R.BaseVal.Value = 82.5F;
                circleDayStatus.SetAttribute("fill", "none");
                circleDayStatus.SetAttribute("stroke", colorDay);
                circleDayStatus.SetAttribute("transform", "rotate(-90,220,285)");
                circleDayStatus.SetAttribute("stroke-width", "15");           
                circleDayStatus.SetAttribute("stroke-dasharray", "518");
                circleDayStatus.SetAttribute("stroke-dashoffset", $"{dashDay}");

                svgElement.InsertBefore(circleDayStatus, svgElement.FirstChild);

                SVGCircleElement circleDayWhite = (SVGCircleElement)document.CreateElementNS(SvgNamespace, "circle");

                circleDayWhite.Cx.BaseVal.Value = 220.5F;
                circleDayWhite.Cy.BaseVal.Value = 285.5F;
                circleDayWhite.R.BaseVal.Value = 82.5F;
                circleDayWhite.SetAttribute("fill", "none");
                circleDayWhite.SetAttribute("stroke", "#ffffff");
                circleDayWhite.SetAttribute("transform", "rotate(-92,220,285)");
                circleDayWhite.SetAttribute("stroke-width", "26");
                circleDayWhite.SetAttribute("stroke-dasharray", "518");
                circleDayWhite.SetAttribute("stroke-dashoffset", $"{dashDayWhite}");

                svgElement.InsertBefore(circleDayWhite, svgElement.FirstChild);

                SVGCircleElement circleDay = (SVGCircleElement)document.CreateElementNS(SvgNamespace, "circle");

                circleDay.Cx.BaseVal.Value = 220.5F;
                circleDay.Cy.BaseVal.Value = 285.5F;
                circleDay.R.BaseVal.Value = 82.5F;
                circleDay.SetAttribute("fill", "none");
                circleDay.SetAttribute("stroke", "#38C32133");
                circleDay.SetAttribute("stroke-width", "23");

                svgElement.InsertBefore(circleDay, svgElement.FirstChild);

                //Month

                SVGTextElement percentForMonth = (SVGTextElement)document.CreateElementNS(SvgNamespace, "text");

                percentForMonth.SetAttribute("height", "44px");
                percentForMonth.SetAttribute("width", "102px");
                percentForMonth.SetAttribute("x", "50%");
                percentForMonth.SetAttribute("y", "571px");
                percentForMonth.SetAttribute("text-anchor", "middle");
                percentForMonth.Style.FontFamily = "sans-serif";
                percentForMonth.Style.FontSize = "36px";
                percentForMonth.Style.FontWeight = "700";

                Decimal decPercentForMonth = 0;

                if (itExecutionPlanShopModel != null)
                {
                    decPercentForMonth = Convert.ToDecimal(itExecutionPlanShopModel.PercentForMonth);
                }

                percentForMonth.TextContent = $"{Math.Round(decPercentForMonth, 1)}%";

                svgElement.InsertBefore(percentForMonth, svgElement.FirstChild);

                SVGTextElement factMonthText = (SVGTextElement)document.CreateElementNS(SvgNamespace, "text");

                factMonthText.SetAttribute("height", "44px");
                factMonthText.SetAttribute("width", "102px");
                factMonthText.SetAttribute("x", "175px");
                factMonthText.SetAttribute("y", "600px");
                factMonthText.Style.FontFamily = "sans-serif";
                factMonthText.Style.FontSize = "14px";
                factMonthText.Style.FontWeight = "500";
                factMonthText.TextContent = $"Факт:";
                svgElement.InsertBefore(factMonthText, svgElement.FirstChild);

                SVGTextElement factMonth = (SVGTextElement)document.CreateElementNS(SvgNamespace, "text");

                factMonth.SetAttribute("height", "44px");
                factMonth.SetAttribute("width", "102px");
                factMonth.SetAttribute("x", "215px");
                factMonth.SetAttribute("y", "601px");
                factMonth.Style.FontFamily = "sans-serif";
                factMonth.Style.FontSize = "14px";
                factMonth.Style.FontWeight = "500";

                Decimal decFactMonth = 0;

                if (itExecutionPlanShopModel != null)
                {
                    decFactMonth = Convert.ToDecimal(itExecutionPlanShopModel.FactMonth);
                }

                string formatFactMonth = _tradeClientFrameService.formatDecimal(decFactMonth);
                factMonth.TextContent = $"{formatFactMonth}";

                svgElement.InsertBefore(factMonth, svgElement.FirstChild);

                SVGTextElement planMonthText = (SVGTextElement)document.CreateElementNS(SvgNamespace, "text");

                planMonthText.SetAttribute("height", "44px");
                planMonthText.SetAttribute("width", "102px");
                planMonthText.SetAttribute("x", "175px");
                planMonthText.SetAttribute("y", "620px");
                planMonthText.Style.FontFamily = "sans-serif";
                planMonthText.Style.FontSize = "14px";
                planMonthText.Style.FontWeight = "500";
                planMonthText.TextContent = $"План:";
                svgElement.InsertBefore(planMonthText, svgElement.FirstChild);

                SVGTextElement planMonth = (SVGTextElement)document.CreateElementNS(SvgNamespace, "text");

                planMonth.SetAttribute("height", "44px");
                planMonth.SetAttribute("width", "102px");
                planMonth.SetAttribute("x", "215px");
                planMonth.SetAttribute("y", "621px");
                planMonth.Style.FontFamily = "sans-serif";
                planMonth.Style.FontSize = "14px";
                planMonth.Style.FontWeight = "500";

                Decimal decPlanMonth = 0;

                if (itExecutionPlanShopModel != null)
                {
                    decPlanMonth = Convert.ToDecimal(itExecutionPlanShopModel.PlanMonth);
                }

                string formatPlanMonth = _tradeClientFrameService.formatDecimal(decPlanMonth);
                planMonth.TextContent = $"{formatPlanMonth}";
                svgElement.InsertBefore(planMonth, svgElement.FirstChild);

                SVGCircleElement circleMonthStatus = (SVGCircleElement)document.CreateElementNS(SvgNamespace, "circle");

                string colorMonth = getColorCircle(decPercentForMonth);

                decimal dashMonth = 518 - Math.Round(decPercentForMonth * 518 / 100);
                decimal dashMonthWhite = 0;

                if (dashMonth >= 518)
                {
                    dashMonthWhite = 518;
                }
                else
                {
                    dashMonthWhite = dashMonth - 6;
                }

                circleMonthStatus.Cx.BaseVal.Value = 220.5F;
                circleMonthStatus.Cy.BaseVal.Value = 581.5F;
                circleMonthStatus.R.BaseVal.Value = 82.5F;
                circleMonthStatus.SetAttribute("fill", "none");
                circleMonthStatus.SetAttribute("stroke", colorMonth);
                circleMonthStatus.SetAttribute("transform", "rotate(-90,220,582)");
                circleMonthStatus.SetAttribute("stroke-width", "15");
                circleMonthStatus.SetAttribute("stroke-dasharray", "518");
                circleMonthStatus.SetAttribute("stroke-dashoffset", $"{dashMonth}");

                svgElement.InsertBefore(circleMonthStatus, svgElement.FirstChild);

                SVGCircleElement circleMonthWhite = (SVGCircleElement)document.CreateElementNS(SvgNamespace, "circle");

                circleMonthWhite.Cx.BaseVal.Value = 220.5F;
                circleMonthWhite.Cy.BaseVal.Value = 581.5F;
                circleMonthWhite.R.BaseVal.Value = 82.5F;
                circleMonthWhite.SetAttribute("fill", "none");
                circleMonthWhite.SetAttribute("stroke", "#ffffff");
                circleMonthWhite.SetAttribute("transform", "rotate(-92,220,582)");
                circleMonthWhite.SetAttribute("stroke-width", "26");
                circleMonthWhite.SetAttribute("stroke-dasharray", "518");
                circleMonthWhite.SetAttribute("stroke-dashoffset", $"{dashMonthWhite}");

                svgElement.InsertBefore(circleMonthWhite, svgElement.FirstChild);

                SVGCircleElement circleMonth = (SVGCircleElement)document.CreateElementNS(SvgNamespace, "circle");

                circleMonth.Cx.BaseVal.Value = 220.5F;
                circleMonth.Cy.BaseVal.Value = 581.5F;
                circleMonth.R.BaseVal.Value = 82.5F;
                circleMonth.SetAttribute("fill", "none");
                circleMonth.SetAttribute("stroke", "#38C421");
                circleMonth.SetAttribute("stroke-opacity", "0.2");
                circleMonth.SetAttribute("stroke-width", "23");

                svgElement.InsertBefore(circleMonth, svgElement.FirstChild);

                //Forecast

                SVGTextElement percentForForecast = (SVGTextElement)document.CreateElementNS(SvgNamespace, "text");

                percentForForecast.SetAttribute("height", "44px");
                percentForForecast.SetAttribute("width", "102px");
                percentForForecast.SetAttribute("x", "50%");
                percentForForecast.SetAttribute("y", "874px");
                percentForForecast.SetAttribute("text-anchor", "middle");
                percentForForecast.Style.FontFamily = "sans-serif";
                percentForForecast.Style.FontSize = "36px";
                percentForForecast.Style.FontWeight = "700";

                Decimal decPercentForForecast = 0;

                if (itExecutionPlanShopModel != null)
                {
                    decPercentForForecast = Convert.ToDecimal(itExecutionPlanShopModel.PercentForecast);
                }

                percentForForecast.TextContent = $"{Math.Round(decPercentForForecast, 1)}%";

                svgElement.InsertBefore(percentForForecast, svgElement.FirstChild);
                /*
                SVGCircleElement circleForecastStatus = (SVGCircleElement)document.CreateElementNS(SvgNamespace, "circle");

                string colorFor = getColorCircle(decPercentForForecast);

                decimal dashForecast = 518 - Math.Round(decPercentForForecast * 518 / 100);
                decimal dashForecastWhite = 0;

                if (dashForecast >= 518)
                {
                    dashForecastWhite = 518;
                }
                else
                {
                    dashForecastWhite = dashForecast - 6;
                }

                circleForecastStatus.Cx.BaseVal.Value = 220.5F;
                circleForecastStatus.Cy.BaseVal.Value = 861.5F;
                circleForecastStatus.R.BaseVal.Value = 82.5F;
                circleForecastStatus.SetAttribute("fill", "none");
                circleForecastStatus.SetAttribute("stroke", colorFor);
                //circleForecastStatus.SetAttribute("transform", "rotate(-90,220,885)");
                circleForecastStatus.SetAttribute("stroke-width", "15");
                circleForecastStatus.SetAttribute("stroke-dasharray", "518");
                circleForecastStatus.SetAttribute("stroke-dashoffset", $"{dashForecast}");

                svgElement.InsertBefore(circleForecastStatus, svgElement.FirstChild);

                SVGCircleElement circleForecastWhite = (SVGCircleElement)document.CreateElementNS(SvgNamespace, "circle");

                circleForecastWhite.Cx.BaseVal.Value = 220.5F;
                circleForecastWhite.Cy.BaseVal.Value = 861.5F;
                circleForecastWhite.R.BaseVal.Value = 82.5F;
                circleForecastWhite.SetAttribute("fill", "none");
                circleForecastWhite.SetAttribute("stroke", "#ffffff");
                //circleForecastWhite.SetAttribute("transform", "rotate(-92,220,885)");
                circleForecastWhite.SetAttribute("stroke-width", "26");
                circleForecastWhite.SetAttribute("stroke-dasharray", "518");
                circleForecastWhite.SetAttribute("stroke-dashoffset", $"{dashForecastWhite}");

                svgElement.InsertBefore(circleForecastWhite, svgElement.FirstChild);
                */
                SVGCircleElement circleForecast = (SVGCircleElement)document.CreateElementNS(SvgNamespace, "circle");

                (string, string) colorForecast = getColor(decPercentForForecast);

                circleForecast.Cx.BaseVal.Value = 220.5F;
                circleForecast.Cy.BaseVal.Value = 861.5F;
                circleForecast.R.BaseVal.Value = 82.5F;
                circleForecast.SetAttribute("fill", "none");
                circleForecast.SetAttribute("stroke", "#38C421");
                circleForecast.SetAttribute("stroke-opacity", "0.2");
                circleForecast.SetAttribute("stroke-width", "23");

                svgElement.InsertBefore(circleForecast, svgElement.FirstChild);
               
                //Prize

                decimal percentPrize = 0.0m;

                if (decPercentForMonth <= 80) percentPrize = 0.0m;
                else if (decPercentForMonth > 80 && decPercentForMonth <= 100) percentPrize = 0.3m;
                else if (decPercentForMonth > 100 && decPercentForMonth <= 105) percentPrize = 0.7m;
                else if (decPercentForMonth > 105 && decPercentForMonth <= 110) percentPrize = 0.9m;
                else if (decPercentForMonth > 110 && decPercentForMonth <= 112) percentPrize = 1.1m;
                else if (decPercentForMonth > 112) percentPrize = 1.3m;

                var factPrize = Math.Truncate(decFactMonth / 100 * percentPrize);

                SVGTextElement prize = (SVGTextElement)document.CreateElementNS(SvgNamespace, "text");

                prize.SetAttribute("height", "44px");
                prize.SetAttribute("width", "102px");
                prize.SetAttribute("x", "51%");
                prize.SetAttribute("y", "1035px");
                prize.SetAttribute("text-anchor", "middle");
                prize.Style.FontFamily = "sans-serif";
                prize.Style.FontSize = "36px";
                prize.Style.FontWeight = "700";

                prize.TextContent = $"{factPrize} грн";

                svgElement.InsertBefore(prize, svgElement.FirstChild);

                SVGImageElement goblet = (SVGImageElement)document.CreateElementNS(SvgNamespace, "image");

                goblet.SetAttribute("x", "143px");
                goblet.SetAttribute("y", "1057px");
                goblet.SetAttribute("height", "165px");
                goblet.SetAttribute("width", "165px");
                goblet.SetAttribute("href", colorForecast.Item2);
                svgElement.InsertBefore(goblet, svgElement.FirstChild);
               

                //Backgound

                SVGImageElement backgound = (SVGImageElement)document.CreateElementNS(SvgNamespace, "image");

                backgound.SetAttribute("x", "0px");
                backgound.SetAttribute("y", "0px");
                backgound.SetAttribute("height", "1270px");
                backgound.SetAttribute("width", "450px");
                backgound.SetAttribute("href", "Images//empty.svg");
                svgElement.InsertBefore(backgound, svgElement.FirstChild);
               
                document.Save(documentPath);
            }
        }

        private string getColorCircle(decimal value)
        {
            string color = "#38C421";

            if (value <= 80) color = "#999999";
            if (value > 80 && value <= 100) color = "#E30613";
            if (value > 100 && value <= 105) color = "#FFDD00";
            if (value > 105) color = "#38C321";

            return color;
        }

        private (string, string) getColor(decimal value)
        {
            string color = "#38C421";
            string path = "Images//gobletGray.svg";

            if (value <= 80) { color = "#999999"; path = "Images//gobletGray.svg"; }
            if (value > 80 && value <= 100) { color = "#E30613"; path = "Images//gobletRed.svg"; }
            if (value > 100 && value <= 105) { color = "#FFDD00"; path = "Images//gobletYellow.svg"; }
            if (value > 105) { color = "#38C321"; path = "Images//gobletGreen.svg"; }

            var result = (color, path);
            return result;
        }
    }
}