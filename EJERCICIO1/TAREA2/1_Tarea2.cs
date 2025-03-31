using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tarea12
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
		EN_ESPERA,
		EN_CONSULTA,
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
			int N_PACIENTES = 4;
			Random rnd = new Random();
			Stopwatch medicion = new Stopwatch();
			medicion.Start();
			for (int i = 0; i < N_PACIENTES; i++)
			{
				CM.LlegadaPaciente(new Paciente(rnd.Next(1,100), (int)medicion.ElapsedMilliseconds/1000, rnd.Next(5, 15)), (Prioridad)rnd.Next(0, 3));
				Task.Delay(2000).Wait();
			}
			medicion.Stop();
			Console.Read();
			//Cierre del centro medico.
			CM.CierreCentroMedico();
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

		/// <summary>
		/// Constructor consulta
		/// </summary>
		/// <param name="Id"></param>
		/// <param name="medicoAsignado"></param>
		/// <param name="pacienteAsignado"></param>
		/// <param name="duracionConsulta"></param>
		public Consulta(int Id, Medico medicoAsignado, Paciente pacienteAsignado, TimeSpan duracionConsulta)
		{
			id = Id;
			medico = medicoAsignado;
			paciente = pacienteAsignado;
			duracion = duracionConsulta;
			horaInicio = DateTime.Now;
			medico.disponible = false;
			paciente.Estado = Estado.EN_CONSULTA;
			procesoCita = new Thread(this.IniciarConsulta);
			procesoCita.Start();
		}

		/// <summary>
		/// Método que se ejecuta en el hilo de la consulta
		/// </summary>
		public void IniciarConsulta()
		{
			Console.WriteLine("" + horaInicio.ToString() + ":" + " Inicio de consulta" + id + ": (Paciente" + paciente.Id + "-Medico" + medico.Id + ")");
			while (true)
			{
				if (DateTime.Now - horaInicio > duracion)
				{
					medico.disponible = true;
					paciente.Estado = Estado.FINALIZADO;
					Console.WriteLine("" + DateTime.Now.ToString() + ":" + " Fin consulta" + id + ": (Paciente" + paciente.Id + "-Medico" + medico.Id + ")");
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
		public Estado Estado { get; set; }


		public Paciente(int Id, int LlegadaHospital, int TiempoConsulta)
		{
			this.Id = Id;
			this.LlegadaHospital = LlegadaHospital;
			this.TiempoConsulta = TiempoConsulta;
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
		private int nMedicos = 2;
		public List<Medico> LMedicos = new List<Medico>();
		public List<PacientePrioridad> LPacientes = new List<PacientePrioridad>();
		public List<Consulta> LConsultas = new List<Consulta>();
		public Thread procesoPrincipal;
		public bool cierre = false;

		/// <summary>
		/// Lanza el hilo del centro médico
		/// </summary>
		public void IniciarCentroMedico()
		{
			//Cargamos los médicos
			for (int i = 0; i < nMedicos; i++)
			{
				LMedicos.Add(new Medico(i + 1));
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
					if (!bloqueo && LPacientes.Where(x => x.paciente.Estado == Estado.EN_ESPERA).Count() > 0)
					{
						//Hay pacientes esperando
						Medico medicoCita = LMedicos.Where(x => x.disponible).FirstOrDefault();
						Paciente pacienteCita = LPacientes.Where(x => x.paciente.Estado == Estado.EN_ESPERA).OrderBy(x => x.prioridad).FirstOrDefault().paciente;
						//Creamos la cita
						Consulta cita = new Consulta(LConsultas.Count() + 1, medicoCita, pacienteCita, TimeSpan.FromSeconds(pacienteCita.TiempoConsulta));
						LConsultas.Add(cita);
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
			bloqueo = true;
			LPacientes.Add(new PacientePrioridad() { paciente = paciente, prioridad = prioridad });
			bloqueo = false;
			Console.WriteLine("" + DateTime.Now.ToString() + ":" + " Llegada paciente" + paciente.Id + " al centro médico con tiempo de llegada:" + paciente.LlegadaHospital + " con prioridad:" + prioridad.ToString() + " y tiempo de consulta:" + paciente.TiempoConsulta);
		}

		/// <summary>
		/// Cierra el proceso del centro médico
		/// </summary>
		public void CierreCentroMedico()
		{
			//Terminamos la tarea del centro médico
			cierre = true;

		}



	}
}
