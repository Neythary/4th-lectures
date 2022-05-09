using FahrzeugDatenbank;
using Fahrzeuge;

namespace FahrzeugeMVC.Models
{
    public class FahrzeugListeModel
    {
        public FahrzeugListeModel(IEnumerable<FahrzeugDTO> fahrzeuge)
        {
            foreach (var fahrzeugDTO in fahrzeuge)
            {
                switch (fahrzeugDTO.Typ)
                {
                    case "Auto":
                        var auto = new Auto()
                        { Id = fahrzeugDTO.Id, Name = fahrzeugDTO.Name };
                        this.Fahrzeuge.Add(auto);
                        break;
                    case "Motorrad":
                        var motorrad = new Motorrad()
                        { Id = fahrzeugDTO.Id, Name = fahrzeugDTO.Name, };
                        this.Fahrzeuge.Add(motorrad);
                        break;
                    case "Fahrrad":
                        var fahrrad = new Fahrrad()
                        { Id = fahrzeugDTO.Id, Name = fahrzeugDTO.Name, };
                        this.Fahrzeuge.Add(fahrrad);
                        break;
                }
            }
        }

        public string? suche { get; set; }
        public List<Fahrzeug> Fahrzeuge { get; set; } = new();
    }
}