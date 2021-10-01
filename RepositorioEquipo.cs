using System;
using Conmebol.App.Persistencia.AppRepositories;
using Conmebol.App.Dominio;
using System.Linq;

namespace Conmebol.App.Consola
{
    public class RepositorioEquipo : IRepositorioEquipo
    {
        Conexion conexion = new Conexion();
        public int crearEquipo(Equipo equipo)
        {
            conexion.Equipos.Add(equipo);          
            conexion.SaveChanges();
            Console.WriteLine($"Equipo guardado con Id : {equipo.EquipoId}");
            return equipo.EquipoId;
        }

        public void consultarEquipo(Equipo equipo)
        {
            var equipoConsulta = conexion.Equipos.First(e => e.PaisEquipo == equipo.PaisEquipo && 
                e.NumeroJugadores == equipo.NumeroJugadores && 
                e.DirectorTecnico == equipo.DirectorTecnico);
            Console.WriteLine($"El equipo consultado es : {equipo.PaisEquipo} {equipo.NumeroJugadores} {equipo.DirectorTecnico}");
            //return equipoConsulta;
        }


        public void consultarEquipoNombre(string PaisEquipo)
        {
            var equipoConsulta = conexion.Equipos.First(e => e.PaisEquipo == PaisEquipo);
            Console.WriteLine($"El equipo consultado es : {equipoConsulta.PaisEquipo} No.Jugadores: {equipoConsulta.NumeroJugadores} Director Tecnico: {equipoConsulta.DirectorTecnico}");
            //return equipoConsulta;
        }

        public bool actualizarEquipo(Equipo equipo)
        {
            var equipoConsulta = conexion.Equipos.First(e => e.EquipoId == equipo.EquipoId);
            equipoConsulta.PaisEquipo = equipo.PaisEquipo;
            equipoConsulta.NumeroJugadores = equipo.NumeroJugadores;
            equipoConsulta.DirectorTecnico = equipo.DirectorTecnico;
            conexion.SaveChanges();
            return true;
        }

        public bool borrarEquipo(int EquipoId)
        {
            var equipoConsulta = conexion.Equipos.First(e => e.EquipoId == EquipoId);
            conexion.Equipos.Remove(equipoConsulta);
            conexion.SaveChanges();
            return true;
        }
    }
}