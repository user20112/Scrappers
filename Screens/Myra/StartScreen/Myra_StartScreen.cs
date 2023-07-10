using FontStashSharp.RichText;
using Myra.Graphics2D;
using Myra.Graphics2D.Brushes;
using Myra.Graphics2D.UI;
using Scrappers.Managers;
using System;

namespace Scrappers.Screens
{
    public class Myra_StartScreen : Grid, IDisposable
    {
        private Label _blinkingLabel;
        private int _blinkingLineAnimationId;

        public Myra_StartScreen()
        {
            Padding = new Thickness(50);
            Label titleLabel = new Label
            {
                Text = "Scrappers Boot  Utility",
                TextColor = ColorStorage.CreateColor(69, 224, 255, 255),
                Padding = new Thickness(2),
                GridColumnSpan = 0,
                GridRow = 0,
                Font = FontManager.WhiteRabbit.GetFont(FontManager.Massive)
            };

            Label playLabel = new Label
            {
                Text = "[P]lay Game",
                TextColor = ColorStorage.CreateColor(15, 248, 110, 255),
                Padding = new Thickness(2),
                GridColumn = 1,
                GridRow = 2,
                GridColumnSpan = 0,
                Font = FontManager.WhiteRabbit.GetFont(FontManager.Large)
            };

            Label optionsLabel = new Label
            {
                Text = "[O]ptions",
                TextColor = ColorStorage.CreateColor(15, 248, 110, 255),
                Padding = new Thickness(2),
                GridColumn = 1,
                GridRow = 4,
                GridColumnSpan = 0,
                Font = FontManager.WhiteRabbit.GetFont(FontManager.Large)
            };

            Label trainingLabel = new Label();
            trainingLabel.Text = "[D]rone Operator Training";
            trainingLabel.TextColor = ColorStorage.CreateColor(15, 248, 110, 255);
            trainingLabel.Padding = new Thickness(2);
            trainingLabel.GridColumn = 1;
            trainingLabel.GridRow = 5;
            trainingLabel.GridColumnSpan = 0;
            trainingLabel.Font = FontManager.WhiteRabbit.GetFont(FontManager.Large);

            Label helpLabel = new Label
            {
                Text = "[H]elp Manual",
                TextColor = ColorStorage.CreateColor(15, 248, 110, 255),
                Padding = new Thickness(2),
                GridColumn = 1,
                GridRow = 6,
                GridColumnSpan = 0,
                Font = FontManager.WhiteRabbit.GetFont(FontManager.Large)
            };

            Label statsLabel = new Label
            {
                Text = "[S]tats",
                TextColor = ColorStorage.CreateColor(15, 248, 110, 255),
                Padding = new Thickness(2),
                GridColumn = 1,
                GridRow = 7,
                GridColumnSpan = 0,
                Font = FontManager.WhiteRabbit.GetFont(FontManager.Large)
            };

            Label exitLabel = new Label
            {
                Text = "[E]xit",
                TextColor = ColorStorage.CreateColor(15, 248, 110, 255),
                Padding = new Thickness(2),
                GridColumn = 1,
                GridRow = 9,
                GridColumnSpan = 0,
                Font = FontManager.WhiteRabbit.GetFont(FontManager.Large)
            };

            Label inputLabel = new Label
            {
                Text = "Input Selection:",
                Font = FontManager.WhiteRabbit.GetFont(FontManager.Large)
            };

            _blinkingLabel = new Label
            {
                Text = "_",
                Font = FontManager.WhiteRabbit.GetFont(FontManager.Large)
            };

            var horizontalStackPanel1 = new HorizontalStackPanel();
            horizontalStackPanel1.Padding = new Thickness(2);
            horizontalStackPanel1.GridRow = 10;
            horizontalStackPanel1.GridColumnSpan = 0;
            horizontalStackPanel1.Widgets.Add(inputLabel);
            horizontalStackPanel1.Widgets.Add(_blinkingLabel);

            ColumnsProportions.Add(new Proportion
            {
                Type = Myra.Graphics2D.UI.ProportionType.Part,
            });
            ColumnsProportions.Add(new Proportion
            {
                Type = Myra.Graphics2D.UI.ProportionType.Part,
                Value = 25,
            });
            RowsProportions.Add(new Proportion
            {
                Type = Myra.Graphics2D.UI.ProportionType.Auto,
            });
            RowsProportions.Add(new Proportion
            {
                Type = Myra.Graphics2D.UI.ProportionType.Part,
            });
            RowsProportions.Add(new Proportion
            {
                Type = Myra.Graphics2D.UI.ProportionType.Auto,
            });
            RowsProportions.Add(new Proportion
            {
                Type = Myra.Graphics2D.UI.ProportionType.Part,
            });
            RowsProportions.Add(new Proportion
            {
                Type = Myra.Graphics2D.UI.ProportionType.Auto,
            });
            RowsProportions.Add(new Proportion
            {
                Type = Myra.Graphics2D.UI.ProportionType.Auto,
            });
            RowsProportions.Add(new Proportion
            {
                Type = Myra.Graphics2D.UI.ProportionType.Auto,
            });
            RowsProportions.Add(new Proportion
            {
                Type = Myra.Graphics2D.UI.ProportionType.Auto,
            });
            RowsProportions.Add(new Proportion
            {
                Type = Myra.Graphics2D.UI.ProportionType.Part,
            });
            RowsProportions.Add(new Proportion
            {
                Type = Myra.Graphics2D.UI.ProportionType.Auto,
            });
            RowsProportions.Add(new Proportion
            {
                Type = Myra.Graphics2D.UI.ProportionType.Auto,
            });
            RowsProportions.Add(new Proportion
            {
                Type = Myra.Graphics2D.UI.ProportionType.Part,
                Value = 2,
            });
            Margin = new Thickness(50);
            BorderThickness = new Thickness(1);
            Border = new SolidBrush("#15283BFF");
            Widgets.Add(titleLabel);
            Widgets.Add(playLabel);
            Widgets.Add(optionsLabel);
            Widgets.Add(trainingLabel);
            Widgets.Add(helpLabel);
            Widgets.Add(statsLabel);
            Widgets.Add(exitLabel);
            Widgets.Add(horizontalStackPanel1);
            _blinkingLineAnimationId = MyraAnimationManager.AddAnimation(250, new Command(BlinkTheLabel));
        }

        public void Dispose()
        {
            MyraAnimationManager.RemoveAnimation(_blinkingLineAnimationId);
        }

        private void BlinkTheLabel(object sender, object e)
        {
            _blinkingLabel.Visible = !_blinkingLabel.Visible;
        }
    }
}