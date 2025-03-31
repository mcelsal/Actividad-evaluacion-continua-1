# **Actividad-evaluacion-continua-1**
**GESTIÓN ATENCIÓN HOSPITALARIA**


## PREGUNTAS: Ejercicio #1 – Pacientes con datos – Tarea #2

### ❓ ¿Cuál de los pacientes sale primero de consulta? Explica tu respuesta.
      El paciente que sale primero de consulta es aquel cuya **duración de consulta (`TiempoConsulta`) sea menor**.
          - Cada consulta se ejecuta en un **hilo independiente**, lo que significa que la duración de cada consulta es lo único que determina cuándo termina.
          - Dado que el `TiempoConsulta` se asigna aleatoriamente entre **5 y 15 segundos**, el paciente con el menor valor de `TiempoConsulta` será el primero en finalizar su consulta.
          - La **prioridad** solo afecta el orden de entrada a consulta, pero no la duración de la misma.
      Por lo tanto, **el paciente con la consulta más corta será el primero en salir**.











