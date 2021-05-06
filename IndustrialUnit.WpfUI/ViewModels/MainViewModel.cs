using IndustrialUnit.WpfUI.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialUnit.WpfUI.ViewModels
{
  public class MainViewModel : BaseViewModel
  {
		private ValveViewModel _valveViewModel;
		public ValveViewModel ValveViewModel
		{
			get
			{
				return _valveViewModel;
			}
			set
			{
				_valveViewModel = value;
				//OnPropertyChanged(nameof(ValveViewModel));
			}
		}

		public MainViewModel()
		{
			ValveViewModel = new ValveViewModel();
		}
	}
}
