using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileCore.Models;

namespace FileCore.Repositories
{
    public class EvidenciasRepository: Repository<Evidencias>
    {
        public void InsertEvidencia(Evidencias evidencia)
        {
            if(string.IsNullOrWhiteSpace(evidencia.Nombre))
                throw new ArgumentException("El nombre no debe estar vacio.");
            if (string.IsNullOrWhiteSpace(evidencia.Tipo))
                throw new ArgumentException("El tipo no debe estar vacio.");
            if (evidencia.Orden <= 0)
                throw new ArgumentException("El orden no debe de ser menor o igual a 0");
            if (GetAll().Any(x => x.Orden == evidencia.Orden))
                throw new ArgumentException("El orden ya esta asignado");
            if (GetAll().Any(x => x.Nombre == evidencia.Nombre))
                throw new ArgumentException("El nombre ya esta agregado");

            Insert(evidencia);
        }

        public void UpdateEvidencia(Evidencias evidencia)
        {
            if (string.IsNullOrWhiteSpace(evidencia.Nombre))
                throw new ArgumentException("El nombre no debe estar vacio.");
            if (string.IsNullOrWhiteSpace(evidencia.Tipo))
                throw new ArgumentException("El tipo no debe estar vacio.");
            if (evidencia.Orden <= 0)
                throw new ArgumentException("El orden no debe de ser menor o igual a 0");
            

            if(GetAll().Any(x=>x.IdEvidencias != evidencia.IdEvidencias && x.Nombre == evidencia.Nombre))
            {
                if (GetAll().Any(x => x.Orden == evidencia.Orden))
                {
                    var mismoOrden = GetAll().FirstOrDefault(x => x.Orden == evidencia.Orden);
                    int orden = mismoOrden.Orden;
                    mismoOrden.Orden = evidencia.Orden;
                    evidencia.Orden = orden;
                    Update(evidencia);
                    Update(mismoOrden);
                }
                else
                {
                    Update(evidencia);
                }
            }
            else
            {
                throw new ArgumentException("La evidencia ya existe.");
            }
        }
    }
}
