using ProyectoCore.Data;
using ProyectoCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoCore.Repositories
{
    public class RepositoryHospital: IRepositoryHospital
    {
        IHospitalContext context;

        public RepositoryHospital(IHospitalContext context)
        {
            this.context = context;
        }
        public List<Departamento> GetDepartamentos()
        {
            return this.context.Departamentos.ToList();
        }
        public void InsertarDepartamento(int numero, String nombre, String localidad)
        {
            Departamento d = new Departamento();
            d.Numero = numero;
            d.Nombre = nombre;
            d.Localidad = localidad;
            this.context.Departamentos.Add(d);
            this.context.SaveChanges();
        }
    }
}
