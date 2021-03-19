using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace wpfcust
{
    public static class ExtensionMethod
	{
		private static readonly Action EmptyDelegate = delegate { };
		public static void Refresh(this UIElement uielement)
		{
		uielement.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
	}
    }
}
