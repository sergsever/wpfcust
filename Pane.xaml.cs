using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpfcust
{
	/// <summary>
	/// Interaction logic for Pane.xaml
	/// </summary>
	public partial class Pane : UserControl
	{
		public Pane()
		{
			InitializeComponent();
			Debug.WriteLine("Pane datasource:" + this.DataContext);
		}

		public void Renew()
		{
			InitializeComponent();
		}
		public int RectHeight {
			get
			{
				return (int)GetValue(RectHeightProperty);
			}
			set
			{
				SetValue(RectHeightProperty, value);
				Debug.WriteLine($"New height:{value}");
			}
			}
		public static readonly DependencyProperty RectHeightProperty = DependencyProperty.Register("RectHeight", typeof(Int32), typeof(Pane), new PropertyMetadata(30, new PropertyChangedCallback(OnRectHeightChanged)));

		protected override void OnRender(DrawingContext drawingContext)
		{
			Debug.WriteLine($"RectHeight: {RectHeight}");
			Rect bounds = new Rect(0, 0, 100, RectHeight);
			Brush brush = new SolidColorBrush(Colors.Blue);
			drawingContext.DrawRectangle(brush, null, bounds);
		}

		private static void OnRectHeightChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			Debug.WriteLine("control height changed");
			Pane p = (Pane)d;
			p.Arrange(new Rect(0, 0, 100, p.RectHeight));

		}
	}
}
