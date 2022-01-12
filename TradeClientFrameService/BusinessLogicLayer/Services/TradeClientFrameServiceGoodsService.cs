using Aspose.Svg;
using AutoMapper;
using BusinessLogicLayer.Models;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            try
            {


                using (var document = new SVGDocument())
                {
                    var svgElement = document.RootElement;

                    svgElement.SetAttribute("height", "1190px");
                    svgElement.SetAttribute("width", "450px");

                    // Today          

                    SVGTextElement percentForDay = (SVGTextElement)document.CreateElementNS(SvgNamespace, "text");

                    percentForDay.SetAttribute("height", "44px");
                    percentForDay.SetAttribute("width", "102px");
                    percentForDay.SetAttribute("x", "50%");
                    percentForDay.SetAttribute("y", "208px");
                    percentForDay.SetAttribute("text-anchor", "middle");
                    percentForDay.Style.FontFamily = "Montserrat";
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

                    SVGTextElement factDayText = (SVGTextElement)document.CreateElementNS(SvgNamespace, "text");

                    factDayText.SetAttribute("height", "44px");
                    factDayText.SetAttribute("width", "102px");
                    factDayText.SetAttribute("x", "175px");
                    factDayText.SetAttribute("y", "240px");
                    factDayText.Style.FontFamily = "Montserrat";
                    factDayText.Style.FontSize = "16px";
                    factDayText.Style.FontWeight = "500";
                    factDayText.TextContent = $"Факт:";

                    SVGTextElement factDay = (SVGTextElement)document.CreateElementNS(SvgNamespace, "text");

                    factDay.SetAttribute("height", "44px");
                    factDay.SetAttribute("width", "102px");
                    factDay.SetAttribute("x", "225px");
                    factDay.SetAttribute("y", "241px");
                    factDay.Style.FontFamily = "Montserrat";
                    factDay.Style.FontSize = "16px";
                    factDay.Style.FontWeight = "500";

                    Decimal decFactDay = 0;

                    if (itExecutionPlanShopModel != null)
                    {
                        decFactDay = Convert.ToDecimal(itExecutionPlanShopModel.FactDay);
                    }

                    string formatFactDay = _tradeClientFrameService.formatDecimal(decFactDay);
                    factDay.TextContent = $"{formatFactDay}";

                    SVGTextElement planDayText = (SVGTextElement)document.CreateElementNS(SvgNamespace, "text");

                    planDayText.SetAttribute("height", "44px");
                    planDayText.SetAttribute("width", "102px");
                    planDayText.SetAttribute("x", "170px");
                    planDayText.SetAttribute("y", "258px");
                    planDayText.Style.FontFamily = "Montserrat";
                    planDayText.Style.FontSize = "16px";
                    planDayText.Style.FontWeight = "500";
                    planDayText.TextContent = $"План:";

                    SVGTextElement planDay = (SVGTextElement)document.CreateElementNS(SvgNamespace, "text");

                    planDay.SetAttribute("height", "44px");
                    planDay.SetAttribute("width", "102px");
                    planDay.SetAttribute("x", "225px");
                    planDay.SetAttribute("y", "259px");
                    planDay.Style.FontFamily = "Montserrat";
                    planDay.Style.FontSize = "16px";
                    planDay.Style.FontWeight = "500";

                    Decimal decPlanDay = 0;

                    if (itExecutionPlanShopModel != null)
                    {
                        decPlanDay = Convert.ToDecimal(itExecutionPlanShopModel.PlanDay);
                    }

                    string formatPlanDay = _tradeClientFrameService.formatDecimal(decPlanDay);
                    planDay.TextContent = $"{formatPlanDay}";

                    SVGCircleElement circleDayStatus = (SVGCircleElement)document.CreateElementNS(SvgNamespace, "circle");

                    string colorDay = getColorCircle(decPercentForDay);

                    decimal dashDay = 597 - Math.Round(decPercentForDay * 597 / 100);
                    decimal dashDayWhite = 0;

                    circleDayStatus.Cx.BaseVal.Value = 285.5F;
                    circleDayStatus.Cy.BaseVal.Value = 285.5F;
                    circleDayStatus.R.BaseVal.Value = 95F;
                    circleDayStatus.SetAttribute("fill", "none");
                    circleDayStatus.SetAttribute("stroke", colorDay);
                    circleDayStatus.SetAttribute("transform", "rotate(-90,220,285)");
                    circleDayStatus.SetAttribute("stroke-width", "17");
                    circleDayStatus.SetAttribute("stroke-dasharray", "597");

                    if (dashDay >= 597)
                    {
                        dashDayWhite = 0;
                    }
                    else if (dashDay < 0)
                    {
                        dashDayWhite = 597 + dashDay;
                        dashDay -= 4;
                        circleDayStatus.SetAttribute("transform", "rotate(-92,219,286)");
                    }
                    else
                    {
                        dashDayWhite = dashDay - 604;
                    }

                    circleDayStatus.SetAttribute("stroke-dashoffset", $"{dashDay}");

                    SVGCircleElement circleDay = (SVGCircleElement)document.CreateElementNS(SvgNamespace, "circle");

                    circleDay.Cx.BaseVal.Value = 285.5F;
                    circleDay.Cy.BaseVal.Value = 285.5F;
                    circleDay.R.BaseVal.Value = 95F;
                    circleDay.SetAttribute("fill", "none");
                    circleDay.SetAttribute("stroke", "#38C32133");
                    circleDay.SetAttribute("stroke-width", "23");
                    circleDay.SetAttribute("transform", "rotate(-92,220,285)");
                    circleDay.SetAttribute("stroke-dasharray", "597");
                    circleDay.SetAttribute("stroke-dashoffset", $"{dashDayWhite}");

                    //Month

                    SVGTextElement percentForMonth = (SVGTextElement)document.CreateElementNS(SvgNamespace, "text");

                    percentForMonth.SetAttribute("height", "44px");
                    percentForMonth.SetAttribute("width", "102px");
                    percentForMonth.SetAttribute("x", "50%");
                    percentForMonth.SetAttribute("y", "506px");
                    percentForMonth.SetAttribute("text-anchor", "middle");
                    percentForMonth.Style.FontFamily = "Montserrat";
                    percentForMonth.Style.FontSize = "36px";
                    percentForMonth.Style.FontWeight = "700";

                    Decimal decPercentForMonth = 0;

                    if (itExecutionPlanShopModel != null)
                    {
                        decPercentForMonth = Convert.ToDecimal(itExecutionPlanShopModel.PercentForMonth);
                    }

                    percentForMonth.TextContent = $"{Math.Round(decPercentForMonth, 1)}%";

                    SVGTextElement factMonthText = (SVGTextElement)document.CreateElementNS(SvgNamespace, "text");

                    factMonthText.SetAttribute("height", "44px");
                    factMonthText.SetAttribute("width", "102px");
                    factMonthText.SetAttribute("x", "160px");
                    factMonthText.SetAttribute("y", "540px");
                    factMonthText.Style.FontFamily = "Montserrat";
                    factMonthText.Style.FontSize = "16px";
                    factMonthText.Style.FontWeight = "500";
                    factMonthText.TextContent = $"Факт:";

                    SVGTextElement factMonth = (SVGTextElement)document.CreateElementNS(SvgNamespace, "text");

                    factMonth.SetAttribute("height", "44px");
                    factMonth.SetAttribute("width", "102px");
                    factMonth.SetAttribute("x", "215px");
                    factMonth.SetAttribute("y", "541px");
                    factMonth.Style.FontFamily = "Montserrat";
                    factMonth.Style.FontSize = "16px";
                    factMonth.Style.FontWeight = "500";

                    Decimal decFactMonth = 0;

                    if (itExecutionPlanShopModel != null)
                    {
                        decFactMonth = Convert.ToDecimal(itExecutionPlanShopModel.FactMonth);
                    }

                    string formatFactMonth = _tradeClientFrameService.formatDecimal(decFactMonth);
                    factMonth.TextContent = $"{formatFactMonth}";

                    SVGTextElement planMonthText = (SVGTextElement)document.CreateElementNS(SvgNamespace, "text");

                    planMonthText.SetAttribute("height", "44px");
                    planMonthText.SetAttribute("width", "102px");
                    planMonthText.SetAttribute("x", "160px");
                    planMonthText.SetAttribute("y", "560px");
                    planMonthText.Style.FontFamily = "Montserrat";
                    planMonthText.Style.FontSize = "16px";
                    planMonthText.Style.FontWeight = "500";
                    planMonthText.TextContent = $"План:";

                    SVGTextElement planMonth = (SVGTextElement)document.CreateElementNS(SvgNamespace, "text");

                    planMonth.SetAttribute("height", "44px");
                    planMonth.SetAttribute("width", "102px");
                    planMonth.SetAttribute("x", "215px");
                    planMonth.SetAttribute("y", "561px");
                    planMonth.Style.FontFamily = "Montserrat";
                    planMonth.Style.FontSize = "16px";
                    planMonth.Style.FontWeight = "500";

                    Decimal decPlanMonth = 0;

                    if (itExecutionPlanShopModel != null)
                    {
                        decPlanMonth = Convert.ToDecimal(itExecutionPlanShopModel.PlanMonth);
                    }

                    string formatPlanMonth = _tradeClientFrameService.formatDecimal(decPlanMonth);
                    planMonth.TextContent = $"{formatPlanMonth}";

                    SVGCircleElement circleMonthStatus = (SVGCircleElement)document.CreateElementNS(SvgNamespace, "circle");

                    string colorMonth = getColorCircle(decPercentForMonth);

                    decimal dashMonth = 597 - Math.Round(decPercentForMonth * 597 / 100);
                    decimal dashMonthWhite = 0;

                    circleMonthStatus.Cx.BaseVal.Value = 285.5F;
                    circleMonthStatus.Cy.BaseVal.Value = 581.5F;
                    circleMonthStatus.R.BaseVal.Value = 95F;
                    circleMonthStatus.SetAttribute("fill", "none");
                    circleMonthStatus.SetAttribute("stroke", colorMonth);
                    circleMonthStatus.SetAttribute("transform", "rotate(-90,220,582)");
                    circleMonthStatus.SetAttribute("stroke-width", "17");
                    circleMonthStatus.SetAttribute("stroke-dasharray", "597");

                    if (dashMonth >= 597)
                    {
                        dashMonthWhite = 0;
                    }
                    else if (dashMonth < 0)
                    {
                        dashMonthWhite = 597 + dashMonth;
                        dashMonth -= 4;
                        circleMonthStatus.SetAttribute("transform", "rotate(-92,219,583)");
                    }
                    else
                    {
                        dashMonthWhite = dashMonth - 604;
                    }

                    circleMonthStatus.SetAttribute("stroke-dashoffset", $"{dashMonth}");

                    SVGCircleElement circleMonth = (SVGCircleElement)document.CreateElementNS(SvgNamespace, "circle");

                    circleMonth.Cx.BaseVal.Value = 285.5F;
                    circleMonth.Cy.BaseVal.Value = 581.5F;
                    circleMonth.R.BaseVal.Value = 95F;
                    circleMonth.SetAttribute("fill", "none");
                    circleMonth.SetAttribute("stroke", "#38C421");
                    circleMonth.SetAttribute("stroke-opacity", "0.2");
                    circleMonth.SetAttribute("stroke-width", "23");
                    circleMonth.SetAttribute("transform", "rotate(-92,220,582)");
                    circleMonth.SetAttribute("stroke-dasharray", "597");
                    circleMonth.SetAttribute("stroke-dashoffset", $"{dashMonthWhite}");

                    //Forecast

                    SVGTextElement percentForForecast = (SVGTextElement)document.CreateElementNS(SvgNamespace, "text");

                    percentForForecast.SetAttribute("height", "44px");
                    percentForForecast.SetAttribute("width", "102px");
                    percentForForecast.SetAttribute("x", "50%");
                    percentForForecast.SetAttribute("y", "814px");
                    percentForForecast.SetAttribute("text-anchor", "middle");
                    percentForForecast.Style.FontFamily = "Montserrat";
                    percentForForecast.Style.FontSize = "36px";
                    percentForForecast.Style.FontWeight = "700";

                    Decimal decPercentForForecast = 0;

                    if (itExecutionPlanShopModel != null)
                    {
                        decPercentForForecast = Convert.ToDecimal(itExecutionPlanShopModel.PercentForecast);
                    }

                    percentForForecast.TextContent = $"{Math.Round(decPercentForForecast, 1)}%";

                    SVGCircleElement circleForecastStatus = (SVGCircleElement)document.CreateElementNS(SvgNamespace, "circle");

                    (string, string) colorForecast = getColor(decPercentForForecast);

                    decimal dashForecast = 597 - Math.Round(decPercentForForecast * 597 / 100);
                    decimal dashForecastWhite = 0;

                    circleForecastStatus.Cx.BaseVal.Value = 290.5F;
                    circleForecastStatus.Cy.BaseVal.Value = 861.5F;
                    circleForecastStatus.R.BaseVal.Value = 95F;
                    circleForecastStatus.SetAttribute("fill", "none");
                    circleForecastStatus.SetAttribute("stroke", colorForecast.Item1);
                    circleForecastStatus.SetAttribute("stroke-width", "17");
                    circleForecastStatus.SetAttribute("transform", "rotate(-90,225,865)");
                    circleForecastStatus.SetAttribute("stroke-dasharray", "597");

                    if (dashForecast >= 597)
                    {
                        dashForecastWhite = 0;
                    }
                    else if (dashForecast < 0)
                    {
                        dashForecastWhite = 597 + dashForecast;
                        dashForecast -= 4;
                        circleForecastStatus.SetAttribute("transform", "rotate(-92,224,866)");
                    }
                    else
                    {
                        dashForecastWhite = dashForecast - 604;
                    }

                    circleForecastStatus.SetAttribute("stroke-dashoffset", $"{dashForecast}");

                    SVGCircleElement circleForecast = (SVGCircleElement)document.CreateElementNS(SvgNamespace, "circle");

                    circleForecast.Cx.BaseVal.Value = 290.5F;
                    circleForecast.Cy.BaseVal.Value = 861.5F;
                    circleForecast.R.BaseVal.Value = 95F;
                    circleForecast.SetAttribute("fill", "none");
                    circleForecast.SetAttribute("stroke", "#38C421");
                    circleForecast.SetAttribute("stroke-opacity", "0.2");
                    circleForecast.SetAttribute("stroke-width", "23");
                    circleForecast.SetAttribute("transform", "rotate(-92,225,865)");
                    circleForecast.SetAttribute("stroke-dasharray", "597");
                    circleForecast.SetAttribute("stroke-dashoffset", $"{dashForecastWhite}");

                    //Prize

                    decimal percentPrize = 0.0m;

                    if (decPercentForForecast <= 80) percentPrize = 0.0m;
                    else if (decPercentForForecast > 80 && decPercentForForecast <= 100) percentPrize = 0.3m;
                    else if (decPercentForForecast > 100 && decPercentForForecast <= 105) percentPrize = 0.7m;
                    else if (decPercentForForecast > 105 && decPercentForForecast <= 110) percentPrize = 0.9m;
                    else if (decPercentForForecast > 110 && decPercentForForecast <= 112) percentPrize = 1.1m;
                    else if (decPercentForForecast > 112) percentPrize = 1.3m;

                    var factPrize = Math.Truncate(decPlanMonth / 100 * percentPrize);
                    
                    SVGTextElement prize = (SVGTextElement)document.CreateElementNS(SvgNamespace, "text");

                    prize.SetAttribute("height", "44px");
                    prize.SetAttribute("width", "102px");
                    prize.SetAttribute("x", "51%");
                    prize.SetAttribute("y", "1005px");
                    prize.SetAttribute("text-anchor", "middle");
                    prize.Style.FontFamily = "'Montserrat'";
                    prize.Style.FontSize = "36px";
                    prize.Style.FontWeight = "700";

                    prize.TextContent = $"{factPrize} грн";

                    XDocument gobletFile = XDocument.Load(colorForecast.Item2);

                    SVGElement goblet = (SVGElement)document.CreateElementNS(SvgNamespace, "svg");
                    goblet.SetAttribute("x", "143px");
                    goblet.SetAttribute("y", "967px");
                    goblet.InnerHTML = gobletFile.ToString();

                    //Backgound

                    XDocument backgroundFile = XDocument.Load("../images/empty.svg");

                    SVGElement b = (SVGElement)document.CreateElementNS(SvgNamespace, "svg");
                    b.InnerHTML = backgroundFile.ToString();

                    // import font

                    SVGDefsElement defsElement = (SVGDefsElement)document.CreateElementNS(SvgNamespace, "defs");

                    string import = "<link xmlns=\"http://www.w3.org/1999/xhtml\" href=\"https://fonts.googleapis.com/css?family=Montserrat:400,500,80\" type=\"text/css\" rel=\"stylesheet\" />";

                    defsElement.InnerHTML = $"{import}";

                    // Saving

                    string begin = "<svg xmlns=\"http://www.w3.org/2000/svg\" height=\"1190px\" width=\"450px\">";
                    string font = "<defs><link xmlns =\"http://www.w3.org/1999/xhtml\" href=\"https://fonts.googleapis.com/css?family=Montserrat:400,500,80\" type=\"text/css\" rel=\"stylesheet\" /></defs>";
                    string end = "</svg>";

                    string allSvg = $"{begin}\n{font}\n{backgroundFile}\n" +
                        $"{percentForDay.OuterHTML}\n{factDayText.OuterHTML}\n{factDay.OuterHTML}\n{planDayText.OuterHTML}\n{planDay.OuterHTML}\n{circleDayStatus.OuterHTML}\n{circleDay.OuterHTML}\n" +
                        $"{percentForMonth.OuterHTML}\n{factMonthText.OuterHTML}\n{factMonth.OuterHTML}\n{planMonthText.OuterHTML}\n{planMonth.OuterHTML}\n{circleMonthStatus.OuterHTML}\n{circleMonth.OuterHTML}\n" +
                        $"{percentForForecast.OuterHTML}\n{circleForecastStatus.OuterHTML}\n{circleForecast.OuterHTML}" +
                        $"{prize.OuterHTML}\n{gobletFile}\n{end}";

                    File.WriteAllText(documentPath, allSvg);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
            string path = "../images/gobletGray.svg";

            if (value <= 80) { color = "#999999"; path = "../images/gobletGray.svg"; }
            if (value > 80 && value <= 100) { color = "#E30613"; path = "../images/gobletRed.svg"; }
            if (value > 100 && value <= 105) { color = "#FFDD00"; path = "../images/gobletYellow.svg"; }
            if (value > 105) { color = "#38C321"; path = "../images/gobletGreen.svg"; }

            var result = (color, path);
            return result;
        }
    }
}