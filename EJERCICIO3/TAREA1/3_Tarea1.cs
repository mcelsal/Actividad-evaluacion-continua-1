using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tarea31
{
	/// <summary>
	/// Prioridades
	/// </summary>
	public enum Prioridad
	{
		EMERGENCIAS_N1,
		URGENCIAS_N2,
		CONSULTAS_GNERALES_N3
	}

	/// <summary>
	/// Estados
	/// </summary>
	public enum Estado
	{
		EN_ESPERA_CONSULTA,
		EN_CONSULTA,
		EN_ESPERA_DIAGNOSTICO,
		EN_DIGNOSTICO,
		FINALIZADO
	}

	/// <summary>
	/// Clase ejecutable
	/// </summary>
	class Program
	{
		/// <summary>
		/// Metodo main
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{
			//Iniciar centro médico
			CentroMedico CM = new CentroMedico();
			CM.IniciarCentroMedico();
			//Entrada de pacientes
			int N_PACIENTES = 100;
			Random rnd = new Random();

			for (int i = 0; i < N_PACIENTES; i++)
			{
				bool RequiereDiagnostico = rnd.Next(0, 2) == 1 ? true : false;
				Paciente p = new Paciente(rnd.Next(1, 100), 0, rnd.Next(5, 16), RequiereDiagnostico, 15);
				CM.LlegadaPaciente(p, (Prioridad)rnd.Next(0, 3));
			}


			//Cierre del centro medico.
			CM.CierreCentroMedico();

			Console.Read();
		}

	}

	/// <summary>
	/// Clase que encapsula la entidad médico.
	/// </summary>
	public class Medico
	{
		public int Id { get; set; }
		public bool disponible { get; set; }
		public Medico(int id)
		{
			Id = id;
			disponible = true;
		}
	}

	/// <summary>
	/// Clase que encapsula la entidad equipo diagnóstico.
	/// </summary>
	public class EquioDiagnostico
	{
		public int Id { get; set; }
		public bool disponible { get; set; }
		public EquioDiagnostico(int id)
		{
			Id = id;
			disponible = true;
		}
	}

	/// <summary>
	/// Clase que encapsula la entidad consulta.
	/// </summary>
	public class Consulta
	{
		public int id { get; set; }
		public Medico medico { get; set; }
		public Paciente paciente { get; set; }
		public DateTime horaInicio { get; set; }
		public TimeSpan duracion { get; set; }
		public Thread procesoCita { get; set; }
		public Prioridad prioridad { get; set; }

		/// <summary>
		/// Constructor consulta
		/// </summary>
		/// <param name="Id"></param>
		/// <param name="medicoAsignado"></param>
		/// <param name="pacienteAsignado"></param>
		/// <param name="duracionConsulta"></param>
		public Consulta(int Id, Medico medicoAsignado, Paciente pacienteAsignado, TimeSpan duracionConsulta, Prioridad prioridad)
		{
			id = Id;
			medico = medicoAsignado;
			paciente = pacienteAsignado;
			duracion = duracionConsulta;
			horaInicio = DateTime.Now;
			medico.disponible = false;
			paciente.Estado = Estado.EN_CONSULTA;
			this.prioridad = prioridad;
			procesoCita = new Thread(this.IniciarConsulta);
			procesoCita.Start();

		}

		/// <summary>
		/// Método que se ejecuta en el hilo de la consulta
		/// </summary>
		public void IniciarConsulta()
		{
			while (true)
			{
				if (DateTime.Now - horaInicio > duracion)
				{
					medico.disponible = true;
					paciente.Estado = Estado.FINALIZADO;
					if (paciente.requiereDiagnostico)
						paciente.Estado = Estado.EN_ESPERA_DIAGNOSTICO;
					CentroMedico.TrazaCambioEstado(paciente, prioridad);
					break;
				}
			}
		}

	}
	/// <summary>
	/// Clase que encapsula la entidad consulta.
	/// </summary>
	public class ConsultaDiagnostica
	{
		public int id { get; set; }
		public EquioDiagnostico equipo { get; set; }
		public Paciente paciente { get; set; }
		public DateTime horaInicio { get; set; }
		public TimeSpan duracion { get; set; }
		public Thread procesoCita { get; set; }
		public Prioridad prioridad { get; set; }

		/// <summary>
		/// Constructor consulta
		/// </summary>
		/// <param name="Id"></param>
		/// <param name="medicoAsignado"></param>
		/// <param name="pacienteAsignado"></param>
		/// <param name="duracionConsulta"></param>
		public ConsultaDiagnostica(int Id, EquioDiagnostico equipoDiagnosctio, Paciente pacienteAsignado, TimeSpan duracionConsulta, Prioridad prioridad)
		{
			id = Id;
			equipo = equipoDiagnosctio;
			paciente = pacienteAsignado;
			duracion = duracionConsulta;
			horaInicio = DateTime.Now;
			equipo.disponible = false;
			paciente.Estado = Estado.EN_DIGNOSTICO;
			this.prioridad = prioridad;
			procesoCita = new Thread(this.IniciarConsultaDiagnostica);
			procesoCita.Start();

		}

		/// <summary>
		/// Método que se ejecuta en el hilo de la consulta
		/// </summary>
		public void IniciarConsultaDiagnostica()
		{
			while (true)
			{
				if (DateTime.Now - horaInicio > duracion)
				{
					equipo.disponible = true;
					paciente.Estado = Estado.FINALIZADO;
					CentroMedico.TrazaCambioEstado(paciente, prioridad);
					break;
				}
			}
		}

	}


	/// <summary>
	/// Clase que encapsula la entidad paciente
	/// </summary>
	public class Paciente
	{
		public int Id { get; set; }
		public int LlegadaHospital { get; set; }
		public int TiempoConsulta { get; set; }
		public int TiempoDiagnostico { get; set; }
		public int EntradaConsulta { get; set; }
		public int SalidaConsulta { get; set; }
		public int EntradaDiaganostico { get; set; }
		public int Salida { get; set; }

		public Estado Estado { get; set; }
		public bool requiereDiagnostico { get; set; }

		public Paciente(int Id, int LlegadaHospital, int TiempoConsulta, bool RequiereDiagnostico, int TiempoDiagnostico)
		{
			this.Id = Id;
			this.LlegadaHospital = LlegadaHospital;
			this.TiempoConsulta = TiempoConsulta;
			this.requiereDiagnostico = RequiereDiagnostico;
			this.TiempoDiagnostico = TiempoDiagnostico;
		}
	}

	/// <summary>
	/// Clase para asociar el paciente con la prioridad asignada
	/// </summary>
	public class PacientePrioridad
	{
		public Paciente paciente { get; set; }
		public Prioridad prioridad { get; set; }
	}





	/// <summary>
	/// Clase que recoje la lógica del centro medico
	/// </summary>
	public class CentroMedico
	{
		public bool bloqueo = false;
		private int MAX_Pacientes = 20;
		private int nMedicos = 4;
		private int nEquiposDiagnosticos = 2;
		public List<Medico> LMedicos = new List<Medico>();
		public List<PacientePrioridad> LPacientes = new List<PacientePrioridad>();
		public List<Consulta> LConsultas = new List<Consulta>();
		public List<ConsultaDiagnostica> LConsultasDiagnostica = new List<ConsultaDiagnostica>();
		public List<EquioDiagnostico> LEquiposDiagnosticos = new List<EquioDiagnostico>();


		public Thread procesoPrincipal;
		public bool cierre = false;
		public static Stopwatch medicion = new Stopwatch();


		/// <summary>
		/// Lanza el hilo del centro médico
		/// </summary>
		public void IniciarCentroMedico()
		{

			string TrazaInicio = "" +
			"-----------------------------------------------------------------------------\r\n" +
			"Apertura centro médico  :\r\n" +
			"-----------------------------------------------------------------------------\r\n" +
			"Hora Inicio:" + DateTime.Now.ToString("HH:mm:ss") + "\r\n" +
			"Número de médicos disponibles:" + nMedicos + "\r\n" +
			"Número de equipos diagnósticos disponibles:" + nEquiposDiagnosticos + "\r\n" +
			"-----------------------------------------------------------------------------\r\n";
			Console.WriteLine(TrazaInicio);


			//Cargamos los médicos
			for (int i = 0; i < nMedicos; i++)
			{
				LMedicos.Add(new Medico(i + 1));
			}
			//Cargamos los equipos diagnósticos
			for (int i = 0; i < nEquiposDiagnosticos; i++)
			{
				LEquiposDiagnosticos.Add(new EquioDiagnostico(i + 1));
			}
			//Lanzamos el hilo del centro médico
			procesoPrincipal = new Thread(IniciarProceso);
			procesoPrincipal.Start();
		}

		/// <summary>
		/// Método que ejecuta el proceso del centro médico
		/// </summary>
		public void IniciarProceso()
		{
			while (!cierre)
			{
				if (LMedicos.Where(x => x.disponible).Count() > 0)
				{
					//Hay médicos disponibles
					if (!bloqueo && LPacientes.Where(x => x.paciente.Estado == Estado.EN_ESPERA_CONSULTA).Count() > 0)
					{
						//Hay pacientes esperando
						Medico medicoCita = LMedicos.Where(x => x.disponible).FirstOrDefault();
						PacientePrioridad pacientePrioridad = LPacientes.Where(x => x.paciente.Estado == Estado.EN_ESPERA_CONSULTA).OrderBy(x => x.prioridad).FirstOrDefault();

						//Creamos la cita
						Consulta cita = new Consulta(LConsultas.Count() + 1, medicoCita, pacientePrioridad.paciente, TimeSpan.FromSeconds(pacientePrioridad.paciente.TiempoConsulta), pacientePrioridad.prioridad);
						LConsultas.Add(cita);
						pacientePrioridad.paciente.EntradaConsulta = (int)medicion.ElapsedMilliseconds / 1000;
						TrazaCambioEstado(pacientePrioridad.paciente, pacientePrioridad.prioridad);
					}
				}

				if (LEquiposDiagnosticos.Where(x => x.disponible).Count() > 0)
				{
					//Hay equipos disponibles
					if (!bloqueo && LPacientes.Where(x => x.paciente.Estado == Estado.EN_ESPERA_DIAGNOSTICO).Count() > 0)
					{
						//Hay pacientes esperando diagnostico
						EquioDiagnostico equipocita = LEquiposDiagnosticos.Where(x => x.disponible).FirstOrDefault();
						PacientePrioridad pacientePrioridad = LPacientes.Where(x => x.paciente.Estado == Estado.EN_ESPERA_DIAGNOSTICO).OrderBy(x => x.prioridad).FirstOrDefault();

						//Creamos la cita diagnóstica
						ConsultaDiagnostica citaDiagnostica = new ConsultaDiagnostica(LConsultas.Count() + 1, equipocita, pacientePrioridad.paciente, TimeSpan.FromSeconds(pacientePrioridad.paciente.TiempoDiagnostico), pacientePrioridad.prioridad);
						LConsultasDiagnostica.Add(citaDiagnostica);
						pacientePrioridad.paciente.EntradaDiaganostico = (int)medicion.ElapsedMilliseconds / 1000;
						TrazaCambioEstado(pacientePrioridad.paciente, pacientePrioridad.prioridad);
					}

				}


			}
		}

		/// <summary>
		/// Llegada de un nuevo paciente
		/// </summary>
		/// <param name="paciente"></param>
		/// <param name="prioridad"></param>
		public void LlegadaPaciente(Paciente paciente, Prioridad prioridad)
		{
			if (LPacientes.Count() == 0)
				medicion.Start();

			paciente.LlegadaHospital = LPacientes.Count() + 1;
			bloqueo = true;
			Task.Delay(1000).Wait();
			LPacientes.Add(new PacientePrioridad() { paciente = paciente, prioridad = prioridad });
			TrazaCambioEstado(paciente, prioridad);
			Task.Delay(1000).Wait();
			bloqueo = false;


		}

		/// <summary>
		/// Cierra el proceso del centro médico
		/// </summary>
		public void CierreCentroMedico()
		{
			//Terminamos la tarea del centro médico
			while (LPacientes.Where(x => x.paciente.Estado != Estado.FINALIZADO).Count() > 0) { }
			Task.Delay(1000).Wait();
			medicion.Stop();
			cierre = true;
			string TrazaInicio = "" +
			"-----------------------------------------------------------------------------\r\n" +
			"Cierre centro médico  :\r\n" +
			"-----------------------------------------------------------------------------\r\n" +
			"Hora cierre:" + DateTime.Now.ToString("HH:mm:ss") + "\r\n" +
			"-----------------------------------------------------------------------------\r\n";
			Console.WriteLine(TrazaInicio);
			PintaEstadisticas();


		}


		/// <summary>
		/// Deja traza en consola de la situación del paciente
		/// </summary>
		/// <param name="paciente"></param>
		/// <param name="prioridad"></param>
		public static void TrazaCambioEstado(Paciente paciente, Prioridad prioridad)
		{
			string traza = String.Format("Paciente {0}. Llegado el {1} con prioridad {2}.Requiere diagnóstico: {3}. Estado: {4}. Duración consulta: {5} segundos. Tiempo transcurrido: {6} segundos", paciente.Id, paciente.LlegadaHospital, prioridad.ToString(), paciente.requiereDiagnostico ? "Sí" : "No", paciente.Estado.ToString(), paciente.TiempoConsulta, (int)medicion.ElapsedMilliseconds / 1000);
			Console.WriteLine(traza);
		}


		public void PintaEstadisticas()
		{
			int pacientesAtendidosEmergencis = LPacientes.Where(x => x.paciente.Estado == Estado.FINALIZADO && x.prioridad == Prioridad.EMERGENCIAS_N1).Count();
			int pacientesAtendidosUrgencias = LPacientes.Where(x => x.paciente.Estado == Estado.FINALIZADO && x.prioridad == Prioridad.URGENCIAS_N2).Count();
			int pacientesAtendidosConsultas = LPacientes.Where(x => x.paciente.Estado == Estado.FINALIZADO && x.prioridad == Prioridad.CONSULTAS_GNERALES_N3).Count();

			double TiempoPromedioEsperaEmergencias = LPacientes.Where(x => x.prioridad == Prioridad.EMERGENCIAS_N1).Average(x => x.paciente.EntradaConsulta - x.paciente.LlegadaHospital);
			double TiempoPromedioEsperaUrgencias = LPacientes.Where(x => x.prioridad == Prioridad.URGENCIAS_N2).Average(x => x.paciente.EntradaConsulta - x.paciente.LlegadaHospital);
			double TiempoPromedioEsperaConsultas = LPacientes.Where(x => x.prioridad == Prioridad.CONSULTAS_GNERALES_N3).Average(x => x.paciente.EntradaConsulta - x.paciente.LlegadaHospital);

			double UsoPromedioEquiposDiagnosticos = (LConsultasDiagnostica.Sum(x => x.duracion.TotalSeconds)) / ((medicion.ElapsedMilliseconds / 1000) * nEquiposDiagnosticos);


			string TrazaEstadisticas = "" +
			"-----------------------------------------------------------------------------\r\n" +
			"Pacientes atendidos:\r\n" +
			"    -Emergencias:" + pacientesAtendidosEmergencis + "\r\n" +
			"    -Urgencias:" + pacientesAtendidosUrgencias + "\r\n" +
			"    -Consultas generales:" + pacientesAtendidosConsultas + "\r\n" +
			"-----------------------------------------------------------------------------\r\n" +
			"Tiempo promedio de espera:\r\n" +
			"    -Emergencias:" + TiempoPromedioEsperaEmergencias + "s\r\n" +
			"    -Urgencias:" + TiempoPromedioEsperaUrgencias + "s\r\n" +
			"    -Consultas generales:" + TiempoPromedioEsperaConsultas + "s\r\n" +
			"-----------------------------------------------------------------------------\r\n" +
			"Uso promedio de equipos diagnósticos:" + UsoPromedioEquiposDiagnosticos * 100 + "%\r\n" +
			"-----------------------------------------------------------------------------\r\n" +
			"-----------------------------------------------------------------------------\r\n";
			Console.WriteLine(TrazaEstadisticas);


		}

	}
}
