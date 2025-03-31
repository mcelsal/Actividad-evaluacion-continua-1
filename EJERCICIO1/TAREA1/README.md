# **Actividad-evaluacion-continua-1**
**GESTIÓN ATENCIÓN HOSPITALARIA**


## PREGUNTAS: Ejercicio #1 – Consulta médica – Tarea #1

### ❓ ¿Cuántos hilos se están ejecutando en este programa? Explica tu respuesta.
      El programa ejecuta múltiples hilos:
            Hilo principal: Main.
            Hilo del centro médico: Controla la asignación de médicos a pacientes.
            Hilos de consulta: Cada instancia de Consulta inicia un nuevo hilo "procesoCita" para controlar la duración de la consulta.
      Si hay 4 médicos y llegan 4 pacientes, se ejecutan al menos 6 hilos simultáneamente (1 principal, 1 del centro médico y 4 para consultas en paralelo si hay médicos disponibles).
### ❓ ¿Cuál de los pacientes entra primero en consulta? Explica tu respuesta.
      El primer paciente que entra en consulta es aquel con la mayor prioridad. El orden de prioridad es:
            Emergencias (EMERGENCIAS_N1) - Mayor prioridad
            Urgencias (URGENCIAS_N2)
            Consultas Generales (CONSULTAS_GNERALES_N3) - Menor prioridad
      Dentro de la misma prioridad, los pacientes se atienden en el orden en que llegaron (LlegadaPaciente).
### ❓ ¿Cuál de los pacientes sale primero de consulta? Explica tu respuesta.
      El paciente que tenga la consulta más corta será el primero en salir. La salida depende de la duración asignada (TiempoConsulta).
      Si varios pacientes entran en consulta al mismo tiempo, el paciente con EL menor "TiempoConsulta" finalizará primero, sin importar su prioridad.





