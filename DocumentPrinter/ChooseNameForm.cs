namespace DocumentPrinter
{
    public partial class ChooseNameForm : Form
    {
        private const int ButtonHeight = 20;
        private const int ButtonHorizontalMargin = 5;

        private readonly List<RadioButton> _radioButtons = new();
        private readonly IEnumerable<string> _elements;
        private RadioButton? _selectedRadioButton;

        public string? Result => _selectedRadioButton?.Text;

        public ChooseNameForm(IEnumerable<string> elements)
        {
            InitializeComponent();
            _elements = elements;
        }

        private void FormLoadHandler(object sender, EventArgs e)
        {
            AddButtons(_elements);
            Height = (int)(ButtonHeight * (_radioButtons.Count + 3.5));
        }

        private void AddButtons(IEnumerable<string> names)
        {
            var size = new Size(Width - ButtonHorizontalMargin * 2, ButtonHeight);
            var margin = new Padding(ButtonHorizontalMargin, 0, ButtonHorizontalMargin, 0);
            var lastLocation = new Point(ButtonHorizontalMargin, 0);

            foreach (var name in names)
            {
                var button = CreateButton(name, size, lastLocation, margin);
                _radioButtons.Add(button);
                Controls.Add(button);
                lastLocation.Y += ButtonHeight;
            }
        }

        private RadioButton CreateButton(string name, Size size, Point location, Padding margin)
        {
            var button = new RadioButton
            {
                Text = name,
                Size = size,
                Location = location,
                Margin = margin,
            };
            button.Click += RadioButtonClickHandler;
            return button;
        }

        private void RadioButtonClickHandler(object? sender, EventArgs e)
        {
            if (sender is not RadioButton clicked)
            {
                throw new InvalidOperationException("This event handler must be invoked by RadioButton");
            }
            _selectedRadioButton = clicked;
        }

        private void ConfirmClickHandler(object sender, EventArgs e)
        {
            if (_selectedRadioButton is null)
            {
                return;
            }
            Close();
        }
    }
}