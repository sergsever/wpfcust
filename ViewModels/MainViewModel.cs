using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace wpfcust.ViewModels
{
	class MainViewModel : INotifyPropertyChanged
	{
		public MainViewModel()
		{
			RectHeight = 30;
			PropertyDoChanged("RectHeight");
			Local = new Timer(new TimerCallback(DoTick), null, 1000, 500);
				
		}

		private Timer Local { get; set; }
		public event PropertyChangedEventHandler PropertyChanged;
		public void PropertyDoChanged(string name)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(name));
		}

		public int RectHeight { get; set; }
		 private void DoTick(object state)
		{
			Debug.WriteLine($"Timer click: height:{RectHeight}");
			RectHeight++;
			PropertyDoChanged("RectHeight");
		}
	}
}
