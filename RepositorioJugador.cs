using System;
using Conmebol.App.Persistencia.AppRepositories;
using Conmebol.App.Dominio;
using System.Linq;

namespace Conmebol.App.Consola
{
    public class RepositorioJugador : IRepositorioJugador
    {
        Conexion conexion = new Conexion();
        public int crearJugador(Jugador jugador)
        {
            conexion.Jugadores.Add(jugador);
            conexion.SaveChanges();
            Console.WriteLine($"Equipo guardado con Id : {jugador.PersonaId}");
            return jugador.PersonaId;
        }

        public void consultarJugador(Jugador jugador)
        {
            var jugadorConsulta = conexion.Jugadores.First(j => j.Nombres == jugador.Nombres &&
                j.Apellidos == jugador.Apellidos &&
                j.Posicion == jugador.Posicion &&
                j.NumeroCamiseta == jugador.NumeroCamiseta &&
                j.PaisJugador == jugador.PaisJugador);
                Console.WriteLine($"El Jugador consultado es : {jugador.Nombres} {jugador.Apellidos} {jugador.Posicion} {jugador.NumeroCamiseta} {jugador.PaisJugador}");
            //return jugadorConsulta;
        }

        public void consultarJugadorNombre(string BuscaNombre)
        {
            var jugadorConsulta = conexion.Jugadores.First(j => j.Nombres == BuscaNombre);
            Console.WriteLine($"El Jugador consultado es : {jugadorConsulta.Nombres} {jugadorConsulta.Apellidos} {jugadorConsulta.Posicion} {jugadorConsulta.NumeroCamiseta} {jugadorConsulta.PaisJugador}");
            // return jugadorConsulta;
        }

        public bool actualizarJugador(Jugador jugador)
        {
            var jugadorConsulta = conexion.Jugadores.First(j => j.PersonaId == jugador.PersonaId);
            jugadorConsulta.Nombres = jugador.Nombres;
            jugadorConsulta.Apellidos = jugador.Apellidos;
            jugadorConsulta.Posicion = jugador.Posicion;
            jugadorConsulta.NumeroCamiseta = jugador.NumeroCamiseta;
            jugadorConsulta.PaisJugador = jugador.PaisJugador;
            conexion.SaveChanges();
            return true;
        }

        public bool borrarJugador(int PersonaId)
        {
            var jugadorConsulta = conexion.Jugadores.First(j => j.PersonaId == PersonaId);
            conexion.Jugadores.Remove(jugadorConsulta);
            conexion.SaveChanges();
            return true;
        }
    }
}