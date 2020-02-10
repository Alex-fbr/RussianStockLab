using RSLab.DAL.Enums;
using System;

namespace RSLab.BL.Models
{
    public class TQBRModel
    {
        /// <summary>
        // Отрасль  промышленности, к которой относится акция
        /// </summary>
        public IndustrialSectorEnum IndustrialSector { get; set; }

        public Securities StaticData { get; set; } = new Securities();

        public MarketData DinamicData { get; set; } = new MarketData();

    }

    public class Securities
    {
        /// <summary>
        /// Код акцции ("ABDR")
        /// </summary>
        public string SECID { get; set; }

        /// <summary>
        /// Идентификатор режима торгов
        /// </summary>
        public string BOARDID { get; set; }

        public string SHORTNAME { get; set; }

        /// <summary>
        /// Курс последней сделки предыдущего торгового дня
        /// </summary>
        public double? PREVPRICE { get; set; }

        /// <summary>
        /// Количество валюты в одном стандартном лоте
        /// </summary>
        public int? LOTSIZE { get; set; }

        /// <summary>
        /// Установленное количество инструмента, для которого указывается курс в котировках
        /// </summary>
        public double? FACEVALUE { get; set; }

        /// <summary>
        /// Индикатор "торговые операции разрешены/запрещены"
        /// </summary>
        public string STATUS { get; set; }

        /// <summary>
        /// Наименование режима
        /// </summary>
        public string BOARDNAME { get; set; }

        /// <summary>
        /// Количество десятичных знаков дробной части числа. 
        /// Используется для форматирования значений полей с типом PRICE.
        /// </summary>
        public int? DECIMALS { get; set; }

        /// <summary>
        /// Название компании
        /// </summary>
        public string SECNAME { get; set; }


        public string REMARKS { get; set; }

        /// <summary>
        /// 	Идентификатор рынка на котором торгуется финансовый инструмент
        /// </summary>
        public string MARKETCODE { get; set; }

        /// <summary>
        /// Идентификатор группы инструментов
        /// </summary>
        public string INSTRID { get; set; }


        public string SECTORID { get; set; }

        /// <summary>
        /// инимально возможная разница между курсами, указанными в заявках на покупку/продажу ценных бумаг
        /// </summary>
        public double? MINSTEP { get; set; }

        /// <summary>
        /// Значение оценки предыдущего торгового дня
        /// </summary>
        public double? PREVWAPRICE { get; set; }

        /// <summary>
        /// Валюта, в которой выражен номинал инструмента
        /// </summary>
        public string FACEUNIT { get; set; }

        /// <summary>
        /// Дата на которую предоставляется инфа по акции
        /// </summary>
        public DateTime? PREVDATE { get; set; }


        public long? ISSUESIZE { get; set; }
        public string ISIN { get; set; }

        /// <summary>
        /// Название компании на англ
        /// </summary>
        public string LATNAME { get; set; }

        public string REGNUMBER { get; set; }

        /// <summary>
        ///  Официальная цена закрытия предыдущего дня, рассчитываемая в соответствии с правилами торгов как средневзвешенная цена сделок
        ///  за последние 10 минут торговой сессии, включая сделки послеторгового периода или аукциона закрытия
        /// </summary>
        public double? PREVLEGALCLOSEPRICE { get; set; }

        public double? PREVADMITTEDQUOTE { get; set; }
        public string CURRENCYID { get; set; }
        public string SECTYPE { get; set; }
        public int? LISTLEVEL { get; set; }
        public DateTime? SETTLEDATE { get; set; }

    }

    public class MarketData
    {
        /// <summary>
        /// Цена последней сделки к оценке предыдущего дня
        /// </summary>
        public double? PRICEMINUSPREVWAPRICE { get; set; }

        /// <summary>
        /// Средневзвешенная цена
        /// </summary>
        public double? WAPRICE { get; set; }

        /// <summary>
        /// Цена последней сделки
        /// </summary>
        public double? LAST { get; set; }

        /// <summary>
        /// Изменение средневзвешенной цены относительно средневзвешенной цены предыдущего торгового дня, %
        /// </summary>
        public double? WAPTOPREVWAPRICEPRCNT { get; set; }
    }
}
