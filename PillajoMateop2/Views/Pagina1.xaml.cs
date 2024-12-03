using System;
using System.IO;
using Microsoft.Maui.Controls;

namespace PillajoMateop2.Views
{
    public partial class Pagina1 : ContentPage
    {
        private const string FileName = "MateoPillajo.txt";

        public Pagina1()
        {
            InitializeComponent();
            LoadLastRecharge();
        }

        private void OnRechargeClicked(object sender, EventArgs e)
        {
            string phoneNumber = mpillajo_entryPhoneNumber.Text;
            string name = mpillajo_entryName.Text;

            if (string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(name))
            {
                DisplayAlert("Error", "Por favor ingrese todos los datos.", "OK");
                return;
            }

            string filePath = Path.Combine(FileSystem.AppDataDirectory, FileName);
            string rechargeInfo = $"Nombre: {name}\nNúmero: {phoneNumber}";

            File.WriteAllText(filePath, rechargeInfo);

            DisplayAlert("Éxito", "Recarga realizada con éxito.", "OK");
            LoadLastRecharge();
            ClearInputs();
        }

        private void LoadLastRecharge()
        {
            string filePath = Path.Combine(FileSystem.AppDataDirectory, FileName);

            if (File.Exists(filePath))
            {
                string lastRecharge = File.ReadAllText(filePath);
                mpillajo_labelLastRecharge.Text = lastRecharge;
            }
        }

        private void ClearInputs()
        {
            mpillajo_entryPhoneNumber.Text = string.Empty;
            mpillajo_entryName.Text = string.Empty;
        }
    }
}