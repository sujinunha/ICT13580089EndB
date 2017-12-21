using System;
using System.Collections.Generic;

using Xamarin.Forms;
using static ICT13580089EndB.Models.Cars;

namespace ICT13580089EndB
{
    public partial class mainpage : ContentPage
    {
		public mainpage()
		{
			InitializeComponent();

			newButton.Clicked += NewButton_Clicked;
		}
		void LoadData()
		{
			productListView.ItemsSource = App.DbHelper.GetCars();
		}
		protected override void OnAppearing()
		{
			LoadData();
		}
		void NewButton_Clicked(object sender, EventArgs e)
		{
			Navigation.PushModalAsync(new CarsNewPage());
		}

		async void Delete_Clicked(object sender, System.EventArgs e)
		{
			var button = sender as MenuItem;
			var car = button.CommandParameter as Car;
			var isOk = await DisplayAlert("ยืนยัน", "คุณต้องการลบใช่มั้ย", "ใช่", "ไม่ใช่");
		}

		void Edit_Clicked(object sender, System.EventArgs e)
		{

			var button = sender as MenuItem;
			var car = button.CommandParameter as Car;
			Navigation.PushModalAsync(new CarsNewPage(car));
		}
	}
}