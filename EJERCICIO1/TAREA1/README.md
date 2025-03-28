# **Actividad-evaluacion-continua-1**
**GESTIÓN ATENCIÓN HOSPITALARIA**


## PREGUNTAS: Ejercicio #1 – Consulta médica – Tarea #1

### ❓ ¿Cuántos hilos se están ejecutando en este programa? Explica tu respuesta.
      Se están ejecutando 5 hilos:
      1 hilo principal (Main)
      4 hilos adicionales, uno por cada paciente (Thread hiloPacienteX)
    Cada hilo simula la llegada y atención del paciente, de forma concurrente.

### ❓ ¿Cuál de los pacientes entra primero en consulta? Explica tu respuesta.
    El Paciente 1 entra primero en consulta, ya que es el primero en llegar. La simulación introduce a los       pacientes cada 2 segundos, y al momento de llegar el Paciente 1, todos los médicos están disponibles, por lo tanto, se le asigna uno inmediatamente.

### ❓ ¿Cuál de los pacientes sale primero de consulta? Explica tu respuesta.
    También el Paciente 1 sale primero de consulta, porque fue el primero en ser atendido. Todos los pacientes son atendidos durante 10 segundos, por lo que el orden de salida sigue el orden de llegada, siempre que cada uno sea atendido justo al llegar (como ocurre en esta simulación con 4 médicos para 4 pacientes).



