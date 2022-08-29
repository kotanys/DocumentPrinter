using DocumentPrinter.Models;

namespace DocumentPrinter.Forms
{
    public partial class ChooseNameForm : Form
    {
        private const int ButtonHeight = 20;
        private const int ButtonHorizontalMargin = 5;

        private readonly List<RadioButton> _radioButtons = new();
        private readonly IEnumerable<string> _elements;
        private RadioButton? _selectedRadioButton;

        public string? CurrentName => _selectedRadioButton?.Text;

        public event EventHandler<ChosenNameEditedEventArgs>? NameSwitched;

        public ChooseNameForm(IEnumerable<string> elements)
        {
            InitializeComponent();
            _elements = elements;
        }

        private void FormLoadHandler(object sender, EventArgs e)
        {
            AddButtons(_elements);
            Height = ButtonHeight * (_radioButtons.Count + 2);
            MinimumSize = Size;
            MaximumSize = Size with { Width = Size.Width * 2 };
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
            if (ReferenceEquals(clicked, _selectedRadioButton))
            {
                return;
            }
            _selectedRadioButton = clicked;
            NameSwitched?.Invoke(this, new(clicked.Text));
        }

        /// <summary>
        /// для правильной работы курсора
        /// </summary>
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0x84) //WM_NCHITTEST
                m.Result = (HitTest)m.Result switch
                {
                    HitTest.Top or HitTest.Bottom => (nint)HitTest.Caption,
                    HitTest.TopLeft or HitTest.BottomLeft => (nint)HitTest.Left,
                    HitTest.TopRight or HitTest.BottomRight => (nint)HitTest.Right,
                    _ => m.Result
                };
        }
    }
}