using FahrzeugDatenbank;
using Fahrzeuge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FahrzeugeWPF
{
    internal class FahrzeugeModell
    {
        private readonly FahrzeugRepository _repository;

        public FahrzeugeModell(FahrzeugRepository repository)
        {
            this._repository = repository;
        }

        public async Task<IEnumerable<FahrzeugeModell>>? LadeAlleFahrzeuge()
        {
            List<FahrzeugDTO>? fahrzeuge = await Task.Run(() =>
            {
                return _repository.HoleAlleFahrzeuge();
            });
            var fahrzeugListe = KonvertiereFahrzeuge(fahrzeuge);
            return (IEnumerable<FahrzeugeModell>)fahrzeugListe;
        }

        private IEnumerable<Fahrzeug> KonvertiereFahrzeuge(
            IEnumerable<FahrzeugDTO> fahrzeuge)
        {
            return (IEnumerable<Fahrzeug>)fahrzeuge.Select(
                fahrzeug => KonvertiereFahrzeuge((IEnumerable<FahrzeugDTO>)fahrzeug));
        }

        private Fahrzeug KonvertiereFahrzeug(FahrzeugDTO fahrzeugDTO)
        {
            switch (fahrzeugDTO.Typ)
            {
                case "Auto":
                    var auto = new Auto()
                    { Id = fahrzeugDTO.Id, Name = fahrzeugDTO.Name };
                    return auto;
                case "Motorrad":
                    var motorrad = new Motorrad()
                    { Id = fahrzeugDTO.Id, Name = fahrzeugDTO.Name };
                    return motorrad;
                case "Fahrrad":
                    var fahrrad = new Fahrrad()
                    { Id = fahrzeugDTO.Id, Name = fahrzeugDTO.Name };
                    return fahrrad;
            }
            throw new Exception($"Unbekannter FahrzeugTyp: {fahrzeugDTO.Typ}");
        }
    }
}