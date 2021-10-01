using System;
using Conmebol.App.Persistencia.AppRepositories;
using Conmebol.App.Dominio;
using System.Linq;

namespace Conmebol.App.Consola
{
    public class RepositorioDirectorT : IRepositorioDirectorT
    {
        Conexion conexion = new Conexion();
        public int crearDirectorT(DirectorTecnico directorT)
        {
            conexion.Directores.Add(directorT);
            conexion.SaveChanges();
            Console.WriteLine($"Director Tecnico guardado con Id : {directorT.PersonaId}");
            return directorT.PersonaId;
        }

        public void consultarDirectorT(DirectorTecnico directorT)
        {
            
            var directorConsulta = conexion.Directores.First(d => d.Nombres == directorT.Nombres &&
                d.Apellidos == directorT.Apellidos &&
                d.Nacionalidad == directorT.Nacionalidad);
                Console.WriteLine($"El Director tecnico consultado es : {directorT.Nombres} {directorT.Apellidos} {directorT.Nacionalidad}");
            //return directorConsulta;
        }

        public void consultarDirectorTNombre(string Nombres)
        {
            var directorConsulta = conexion.Directores.First(d => d.Nombres == Nombres);
            Console.WriteLine($"El Director tecnico consultado es : {directorConsulta.Nombres} {directorConsulta.Apellidos} {directorConsulta.Nacionalidad}");
            //return directorConsulta;
        }

        public bool actualizarDirectorT(DirectorTecnico directorT)
        {
            var directorConsulta = conexion.Directores.First(d => d.PersonaId == directorT.PersonaId);
            directorConsulta.Nombres = directorT.Nombres;
            directorConsulta.Apellidos = directorT.Apellidos;
            directorConsulta.Nacionalidad = directorT.Nacionalidad;
            conexion.SaveChanges();
            return true;
        }

        public bool borrarDirectorT(int PersonaId)
        {
            var directorConsulta = conexion.Directores.First(d => d.PersonaId == PersonaId);
            conexion.Directores.Remove(directorConsulta);
            conexion.SaveChanges();
            return true;
        }
    }
}