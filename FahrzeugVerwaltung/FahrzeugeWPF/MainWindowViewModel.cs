using Fahrzeuge;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FahrzeugeWPF
{
    class MainWindowViewModel
    {
        private readonly FahrzeugeModell _modell;

        public MainWindowViewModel(FahrzeugeModell modell)
        {
            this._modell = modell;
            this.InitialisiereDasViewModell();
        }

        
        private async void InitialisiereDasViewModell()
        {
           var fahrzeuge = await _modell.LadeAlleFahrzeuge();
          foreach (FahrzeugeModell fahrzeug in fahrzeuge)
         {
             this.Fahrzeuge.Add(fahrzeug);
         }
        }

        public ObservableCollection<Fahrzeug> Fahrzeuge { get; } = new();
    }
}
