namespace BattleTanks.Core.Interfaces
{
    /// <summary>
    /// Колода
    /// </summary>
    public interface ICardDeck
    {
        /// <summary>
        /// Название
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Все карты
        /// </summary>
        IEnumerable<IGameCard> All { get; }
        /// <summary>
        /// Хранилище
        /// </summary>
        IEnumerable<IGameCard> Store { get; }
        /// <summary>
        /// Кладбище
        /// </summary>
        IEnumerable<IGameCard> Cemetery { get; }
        /// <summary>
        /// Достижения
        /// </summary>
        IEnumerable<IAchievementCard> Achievements { get; }
        /// <summary>
        /// Медали
        /// </summary>
        IEnumerable<IMedalCard> Medals { get; }
        /// <summary>
        /// Свалка
        /// </summary>
        IEnumerable<IMedalCard> Dump { get; }
        /// <summary>
        /// Стартовый набор
        /// </summary>
        /// <returns>Коллекция карт стартового набора</returns>
        IEnumerable<IGameCard> GetStartDeck();
        /// <summary>
        /// Следующая карта из колоды
        /// </summary>
        /// <returns></returns>
        IGameCard GetNextCard();
        /// <summary>
        /// Отправить карту на кладбище
        /// </summary>
        /// <param name="card"></param>
        void PushToCemetery(IGameCard card);
        /// <summary>
        /// Взять медаль
        /// </summary>
        /// <returns></returns>
        IMedalCard GetMedal();
        void UpdateStore();
    }
}
