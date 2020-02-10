using RSLab.DAL.Enums;

namespace RSLab.BL.Models
{
    public class MSCIModel
    {
        /// <summary>
        // Аббревиатура акции
        /// </summary>
        public string SECID { get; set; }

        /// <summary>
        // Полное название компании
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        // Цена на закрытии вчера
        /// </summary>
        public double? PredPrice { get; set; }

        /// <summary>
        // Текущая цена
        /// </summary>
        public double? CurrentPrice { get; set; }

        /// <summary>
        /// Изменение в процентах
        /// </summary>
        public double? PercentChange { get; set; }

        /// <summary>
        /// Цвет карточки
        /// </summary>
        public string ColorCard { get; set; }

        /// <summary>
        // Отрасль  промышленности, к которой относится акция
        /// </summary>
        public IndustrialSectorEnum  IndustrialSector { get; set; }

    }
}
