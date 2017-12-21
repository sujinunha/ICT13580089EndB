using System;
using System.Collections.Generic;

using Xamarin.Forms;
using static ICT13580089EndB.Models.Cars;

namespace ICT13580089EndB
{
    public partial class CarsNewPage : ContentPage
    {
		Car car;
		public CarsNewPage(Car car = null)
		{
			InitializeComponent();
			this.car = car;

			addCar.Clicked += AddCar_Clicked;
			cancelCar.Clicked += CancelCar_Clicked;

			typePicker.Items.Add("รถส่วนตัว");
			typePicker.Items.Add("รถบรรทุก");

			brandPicker.Items.Add("โตโยต้า");
			brandPicker.Items.Add("ฮอลด้า");

			colorPicker.Items.Add("แดง");
			colorPicker.Items.Add("ดำ");
			colorPicker.Items.Add("ฟ้า");

			provincePicker.Items.Add("เพชรบุรี");
			provincePicker.Items.Add("สุพรรณบุรี");
			provincePicker.Items.Add("ระยอง");
			provincePicker.Items.Add("น่าน");
			provincePicker.Items.Add("ปราจีนบุรี");

            mileSlider.ValueChanged += MileSlider_ValueChanged;
            yearStepper.ValueChanged += YearStepper_ValueChanged;


			if (car != null)
			{
				titleLabel.Text = "edit car";
                typePicker.SelectedItem = car.typeCar;
				brandPicker.SelectedItem = car.Brand;
				colorPicker.SelectedItem = car.Color;
				provincePicker.SelectedItem = car.Province;
				grandEntry.Text = car.Gen;

				yearLabel.Text = car.Year;
				priceEntry.Text = car.Price.ToString();
				mileLabel.Text = car.Km.ToString();
				detailEditor.Text = car.Description;
				phoneEntry.Text = car.Numberphone;



			}


		}

		async void AddCar_Clicked(object sender, EventArgs e)
		{
			var isOk = await DisplayAlert("ยืนยัน", "คุณต้องการบันทึกใช่หรือไม่", "ใช่", "ไม่ใช่");
			if (isOk)
			{


				if (car == null)
				{
					car = new Car();
					car.typeCar = typePicker.SelectedItem.ToString();
					car.Brand = brandPicker.SelectedItem.ToString();
					car.Color = colorPicker.SelectedItem.ToString();
					car.Province = provincePicker.SelectedItem.ToString();
					car.Gen = grandEntry.Text;

					car.Price = decimal.Parse(priceEntry.Text);
					car.Year = yearLabel.Text;
					car.Km = decimal.Parse(mileLabel.Text);
					car.Description = detailEditor.Text;
					car.Numberphone = phoneEntry.Text;


					var id = App.DbHelper.AddProduct(car);
					await DisplayAlert("บันทึกสำเร็จ", "รหัสรถของท่าน #" + id, "ตกลง");
				}
				else
				{


					car.typeCar = typePicker.SelectedItem.ToString();
					car.Brand = brandPicker.SelectedItem.ToString();
					car.Color = colorPicker.SelectedItem.ToString();
					car.Province = provincePicker.SelectedItem.ToString();
					car.Gen = grandEntry.Text;

					car.Price = decimal.Parse(priceEntry.Text);
					car.Year = yearLabel.Text;
					car.Km = decimal.Parse(mileLabel.Text);
					car.Description = detailEditor.Text;
					car.Numberphone = phoneEntry.Text;
					var id = App.DbHelper.UpdateProduct(car);
					await DisplayAlert("บันทึกสำเร็จ", "แก้ไขข้อมูลเรียบร้อย", "ตกลง");

				}

				await Navigation.PopModalAsync();



			}


		}

		void CancelCar_Clicked(object sender, EventArgs e)
		{
			Navigation.PopModalAsync();
		}
		void MileSlider_ValueChanged(object sender, ValueChangedEventArgs e)
		{
			mileLabel.Text = e.NewValue.ToString();
		}

		void YearStepper_ValueChanged(object sender, ValueChangedEventArgs e)
		{
			yearLabel.Text = e.NewValue.ToString();
		}
	}
}