namespace StockPortfolio
{
    public class MenuOption
    {
        private string _text;
        private Action _action;

        public MenuOption(string text, Action action)
        {
            _text = text;
            _action = action;
        }

        public string Text { get => _text; set => _text = value; }
        public Action Action { get => _action; set => _action = value; }
    }
}
