using System;
using Conmebol.App.Dominio;
using Conmebol.App.Persistencia.AppRepositories;
using System.Linq;

namespace Conmebol.App.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            Conexion conexion = new Conexion();
            RepositorioDirectorT rd = new RepositorioDirectorT();
            RepositorioJugador rj = new RepositorioJugador();
            int opcionn = 0;
            while (opcionn != 5)
            {
                Console.WriteLine("");
                Console.WriteLine("Digita la opcion");
                Console.WriteLine("1: Crear registro");
                Console.WriteLine("2: Buscar registro");
                Console.WriteLine("3: Actualizar registro");
                Console.WriteLine("4: Borrar registro");
                Console.WriteLine("5: Salir");
                Console.WriteLine("");
                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {

                    case 1:
                        Console.WriteLine("1: Crear Equipo y Director tecnico");
                        Console.WriteLine("2: Crear Jugador");
                        Console.WriteLine("3: Crear Administrador");
                        int opcionUno = Convert.ToInt32(Console.ReadLine());
                        switch (opcionUno)
                        {
                            case 1:
                                creacionEquipo();
                                break;
                            case 2:
                                creacionJugador();
                                break;
                            case 3:
                                creacionAdministrador();
                                break;
                        }
                        break;
                    case 2:
                        Console.WriteLine("1: Buscar Equipo");
                        Console.WriteLine("2: Buscar Jugador");
                        Console.WriteLine("3: Buscar Director Tecnico ");
                        Console.WriteLine("4: Buscar Administrador ");
                        int opcionDos = Convert.ToInt32(Console.ReadLine());
                        switch (opcionDos)
                        {
                            case 1:
                                buscaEquipo();
                                break;
                            case 2:
                                buscaJugador();
                                break;
                            case 3:
                                buscaDT();
                                break;
                            case 4:
                                buscaAdministrador();
                                break;
                        }
                        break;
                    case 3:
                        Console.WriteLine("1 :Actualizar Equipo");
                        Console.WriteLine("2: Actualizar Jugador");
                        Console.WriteLine("3: Actualizar Director Tecnico ");
                        Console.WriteLine("4: Actualizar Administrador ");
                        int opcionTres = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 4:
                        Console.WriteLine("1: Borrar Equipo");
                        Console.WriteLine("2: Borrar Jugador");
                        Console.WriteLine("3: Borrar Director Tecnico ");
                        Console.WriteLine("4: Borrar Administrador ");
                        int opcionCuatro = Convert.ToInt32(Console.ReadLine());
                        switch (opcionCuatro)
                        {
                            case 1:
                                //eliminaEquipo();
                                break;
                            case 2:
                                eliminaJugador();

                                break;
                            case 3:
                                eliminaDT();

                                break;
                            case 4:
                                eliminaAdministrador();
                                break;
                        }
                        break;

                }
                opcionn = opcion;
            }

        }
        //METODO CREACION Equipo
        static void creacionEquipo()
        {
            Console.WriteLine("Nombre del Tecnico: ");
            string NombreT = Console.ReadLine();
            Console.WriteLine("Apellido del Tecnico: ");
            string ApellidoT = Console.ReadLine();
            Console.WriteLine("Nacionalidad del Tecnico: ");
            string NacionalidadT = Console.ReadLine();
            RepositorioDirectorT rd = new RepositorioDirectorT();
            DirectorTecnico dt = new DirectorTecnico();

            dt.Nombres = NombreT;
            dt.Apellidos = ApellidoT;
            dt.Nacionalidad = NacionalidadT;
            
            //conexion.DirectorT.Add(dt);
            //onexion.SaveChanges();
            //int IdDirector;
            //IdDirector = rd.crearDirectorT(dt);
            //Console.WriteLine($"DT guardato con Id : {dt.PersonaId}");

            //PIDE LOS DATOS DEL EQUIPO
            Console.WriteLine("Nombre del equipo a registrar: ");
            string NombreE = Console.ReadLine();
            Console.WriteLine("Numero de Jugadores: ");
            int NJugadoresE = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Paso linea Num jugadores ");
            
            RepositorioEquipo re = new RepositorioEquipo();
            Equipo equipo = new Equipo();
            equipo.PaisEquipo = NombreE;
            
            Console.WriteLine(" asiga nombre ");
            
            equipo.NumeroJugadores = NJugadoresE;

            Console.WriteLine(" asiga Nu jugador ");

            equipo.DirectorTecnico = dt;
            Console.WriteLine(" asiga DT ");

            int IdEquipo;
            Console.WriteLine($" variable Equipo: {equipo} ");
            IdEquipo = re.crearEquipo(equipo);
            //Conexion conexion = new Conexion();
            //conexion.Equipos.Add(equipo);
            //conexion.SaveChanges();
            Console.WriteLine($"Equipo guardado con Id : {dt.PersonaId}");
        }
        //Metodo Creacion Jugador

        static void creacionJugador()
        {
            Console.WriteLine("Cuantos Jugadores va registrar?  ");
            int Qjugadores = Convert.ToInt32(Console.ReadLine());
            int contador = 0;

            while (contador < Qjugadores)
            {
                contador = contador + 1;
                RepositorioJugador rj = new RepositorioJugador();
                Jugador jugador = new Jugador();
                Console.WriteLine("Numero de camiseta: ");
                int ncamiseta = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Nombre Jugador: ");
                string nojugador = Console.ReadLine();
                Console.WriteLine("Apellido Jugador: ");
                string Apjugador = Console.ReadLine();
                Console.WriteLine("Posición Jugador: ");
                string Posjugador = Console.ReadLine();
                Console.WriteLine("Pais Jugador: ");
                string Pajugador = Console.ReadLine();
                Console.WriteLine("Enter para continuar ");
                string entrada = Console.ReadLine();
                jugador.Nombres = nojugador;
                jugador.Apellidos = Apjugador;
                jugador.Posicion = Posjugador;
                jugador.NumeroCamiseta = ncamiseta;
                jugador.PaisJugador = Pajugador;
                int IdJugador;
                IdJugador = rj.crearJugador(jugador);
                
                Console.WriteLine($"jugador guardado con Id : {jugador.PersonaId}");
            }
        }

        static void creacionAdministrador()
        {
            Console.WriteLine("Nombre del Administrador: ");
            string NombreA = Console.ReadLine();
            Console.WriteLine("Apellido del Administrador: ");
            string ApellidoA = Console.ReadLine();
            Console.WriteLine("Cedula del Administrador: ");
            int CedulaA = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Codigo del Administrador: ");
            string CodigoA = Console.ReadLine();

            RepositorioAdministrador rad = new RepositorioAdministrador();
            Administrador ad = new Administrador();
            ad.Nombres = NombreA;
            ad.Apellidos = ApellidoA;
            ad.Cedula = CedulaA;
            ad.CodigoEmpleado = CodigoA;        
            int IdAdmin;
            IdAdmin = rad.crearAdministrador(ad);
            Console.WriteLine($"Administrador guardado con Id : {ad.PersonaId}");
        }
        

        static void buscaEquipo()
        {
            RepositorioEquipo re = new RepositorioEquipo();
            Console.WriteLine("Digita el nombre del equipo a buscar");
            string BuscaNombreE = Console.ReadLine();
            
            re.consultarEquipoNombre(BuscaNombreE);
            Console.WriteLine("Enter para continuar ");
            string entrada = Console.ReadLine();
        }
        static void buscaJugador()
        {
            RepositorioJugador rj = new RepositorioJugador();
            Console.WriteLine("Digita el nombre a buscar");
            string BuscaNombre = Console.ReadLine();
            
            rj.consultarJugadorNombre(BuscaNombre);
            Console.WriteLine("Enter para continuar ");
            string entrada = Console.ReadLine();
        }

        static void buscaDT()
        {
            RepositorioDirectorT rd = new RepositorioDirectorT();

            Console.WriteLine("Digita Nombre del Tecnico");
            string BuscaNombreT = Console.ReadLine();

            rd.consultarDirectorTNombre(BuscaNombreT);
            Console.WriteLine("Enter para continuar ");
            string entrada = Console.ReadLine();
        }
        static void buscaAdministrador()
        {
            RepositorioAdministrador rad = new RepositorioAdministrador();
            Console.WriteLine("Digita el nombre a buscar");
            string BuscaNombreA = Console.ReadLine();
            rad.consultarAdministradorNombre(BuscaNombreA);
            Console.WriteLine("Enter para continuar ");
            string entrada = Console.ReadLine();
        }

        static void eliminaJugador()
        {
            RepositorioJugador rj = new RepositorioJugador();
            Conexion conexion = new Conexion();
            Console.WriteLine("Digita el ID a Eliminar");
            int BuscaID = Convert.ToInt32(Console.ReadLine());
            var jugador = conexion.Jugadores.First(j => j.PersonaId == BuscaID);
            Console.WriteLine($"El nombre del jugador es : {jugador.Nombres} {jugador.Apellidos}");
            Console.WriteLine("Segur desea Borraro este registro  1: SI  2: NO");
            int siono = Convert.ToInt32(Console.ReadLine());
            if (siono == 1)
            {
                bool resultadoBorrado;
                resultadoBorrado = rj.borrarJugador(jugador.PersonaId);
                Console.WriteLine("Enter para continuar ");
                string entrada = Console.ReadLine();
            }

        }
        static void eliminaDT()
        {
            RepositorioDirectorT rd = new RepositorioDirectorT();
            Conexion conexion = new Conexion();
            Console.WriteLine("Digita nombre Tecnico a eliminar");
            string BorrarTecnico = Console.ReadLine();
            var persona = conexion.Personas.First(p => p.Nombres == BorrarTecnico);
            Console.WriteLine($"El nombre del DT a borrar es : {persona.Nombres} {persona.Apellidos}");
            Console.WriteLine("Segur desea Borraro este registro  1: SI  2: NO");
            int noosi = Convert.ToInt32(Console.ReadLine());
            if (noosi == 1)
            {
                bool resultadoBorradoDT;
                resultadoBorradoDT = rd.borrarDirectorT(persona.PersonaId);
                Console.WriteLine("Enter para continuar ");
                string entrada = Console.ReadLine();
            }
        }

        static void eliminaAdministrador()
        {
            RepositorioAdministrador rad = new RepositorioAdministrador();
            Conexion conexion = new Conexion();
            Console.WriteLine("Digita nombre Administrador a eliminar");
            string BorrarAdmin = Console.ReadLine();
            var persona = conexion.Personas.First(p => p.Nombres == BorrarAdmin);
            Console.WriteLine($"El nombre del DT a borrar es : {persona.Nombres} {persona.Apellidos}");
            Console.WriteLine("Segur desea Borraro este registro  1: SI  2: NO");
            int noosi = Convert.ToInt32(Console.ReadLine());
            if (noosi == 1)
            {
                bool resultadoBorradoAdmin;
                resultadoBorradoAdmin = rad.borrarAdministrador(persona.PersonaId);
                Console.WriteLine("Enter para continuar ");
                string entrada = Console.ReadLine();
            }
        }
    }
}
