
namespace Game
{
    /// <summary>
    /// Хранит актуальные объекты, которые полезны другим для их корректной работы
    /// </summary>
    static class ImportantObjectsKeeper
    {
        public static Player.Obj Player = new Player.Obj();

        public static Shop.StepanStock StepanStock = new Shop.StepanStock();

        public static Healer Healer = new Healer();

        static ImportantObjectsKeeper()
        {
            StepanStock.InitializeAll();
        }
    }
}
