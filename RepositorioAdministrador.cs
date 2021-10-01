using System;
using Conmebol.App.Persistencia.AppRepositories;
using Conmebol.App.Dominio;
using System.Linq;

namespace Conmebol.App.Consola
{
    public class RepositorioAdministrador : IRepositorioAdministrador 
    {
      Conexion conexion = new Conexion();
        public int crearAdministrador(Administrador admin)
        {
            conexion.Admin.Add(admin);
            conexion.SaveChanges();
            Console.WriteLine($"Administrador guardado con Id : {admin.PersonaId}");
            return admin.PersonaId;
        }

        public void consultarAdministrador(Administrador admin)
        {
            var adminConsulta = conexion.Admin.First(a => a.Nombres == admin.Nombres &&
                a.Apellidos == admin.Apellidos &&
                a.Cedula == admin.Cedula &&
                a.CodigoEmpleado == admin.CodigoEmpleado );
                Console.WriteLine($"El administrador consultado es : {admin.Nombres} {admin.Apellidos} {admin.Cedula} {admin.CodigoEmpleado}");
            //return adminConsulta;
        }

        public void consultarAdministradorNombre(string Nombres)
        {
            var adminConsulta = conexion.Admin.First(a => a.Nombres == Nombres);
            Console.WriteLine($"El administrador consultado es : {adminConsulta.Nombres} {adminConsulta.Apellidos} {adminConsulta.Cedula} {adminConsulta.CodigoEmpleado}");
            //return adminConsulta;
        }

        public bool actualizarAdministrador(Administrador admin)
        {
            var adminConsulta = conexion.Admin.First(a => a.PersonaId == admin.PersonaId);
            adminConsulta.Cedula = admin.Cedula;
            adminConsulta.CodigoEmpleado = admin.CodigoEmpleado;
            conexion.SaveChanges();
            return true;
        }

        public bool borrarAdministrador(int PersonaId)
        {
            var adminConsulta = conexion.Admin.First(a => a.PersonaId == PersonaId);
            conexion.Admin.Remove(adminConsulta);
            conexion.SaveChanges();
            return true;
        }
    }
}