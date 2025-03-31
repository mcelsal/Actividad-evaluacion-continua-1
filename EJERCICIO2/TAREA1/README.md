# **Actividad-evaluacion-continua-1**
**GESTIÓN ATENCIÓN HOSPITALARIA**

## PREGUNTAS: Ejercicio #2 – Unidades de diagnóstico – Tarea #1

### ❓ ¿Los pacientes que deben esperar para hacerse las pruebas diagnostico entran luego a hacerse las pruebas por orden de llegada? Explica que tipo de pruebas has realizado para comprobar este comportamiento. 

      Sí, en el código proporcionado, los pacientes que deben esperar para hacerse las pruebas diagnósticas entran a hacerse las pruebas por orden de llegada, pero con una consideración importante: 
      la prioridad del paciente.

      Los pacientes que están esperando diagnóstico son atendidos según el orden de su prioridad. Aunque los pacientes son atendidos por orden de llegada, aquellos con mayor prioridad son atendidos antes. 
      La prioridad es un criterio que se respeta al momento de asignar un equipo de diagnóstico disponible.

      📌 Detalles de cómo se asignan las consultas y diagnósticos:

          1. **Ingreso de Pacientes:**
             Los pacientes llegan al centro médico y se les asigna una prioridad (Emergencia, Urgencia, o Consulta General). 
             Los pacientes se añaden a una lista de espera (`LPacientes`) con su respectiva prioridad.

          2. **Atención Médica:**
             Los pacientes son atendidos por médicos disponibles según su prioridad. Si un paciente tiene una mayor prioridad, se le asigna el médico más rápido disponible, incluso si llegó después que otros pacientes con               menor prioridad.

          3. **Diagnóstico:**
             Los pacientes que requieren diagnóstico se colocan en una lista de espera para ser atendidos por equipos de diagnóstico disponibles. A pesar de que los pacientes pueden llegar en diferente orden, aquellos con               mayor prioridad tienen preferencia en la asignación de los equipos de diagnóstico.

       El sistema asegura que los pacientes con mayor prioridad sean atendidos antes, respetando su nivel de urgencia.
      
      📌 Pruebas realizadas para comprobar este comportamiento:
          
          1. **Creación de pacientes con diferentes prioridades:**
          Para simular este comportamiento, se crearon varios pacientes con diferentes prioridades (Emergencia, Urgencia, Consultas Generales). 
          Cada paciente tiene una prioridad asignada de forma aleatoria, lo que permite observar si el sistema respeta esa prioridad al asignar los recursos para las pruebas diagnósticas.

          2. **Simulación de llegada de pacientes:**
          Los pacientes llegaron al centro médico en intervalos de 2 segundos, y se les asignó una prioridad aleatoria. 
          Durante la simulación, se observó que, aunque llegaran en diferentes momentos, los pacientes con mayor prioridad eran los primeros en ser asignados para las pruebas de diagnóstico.

          3. **Monitoreo de los estados de los pacientes:**
          A lo largo de la ejecución, se imprimieron mensajes en consola para visualizar el estado de los pacientes, su prioridad, y los tiempos transcurridos. Esto permitió verificar que los pacientes con mayor prioridad            pasaban primero por el diagnóstico, independientemente de su orden de llegada.
              Ejemplos:
                Paciente 1. Llegado el 1 con prioridad EMERGENCIAS_N1. Requiere diagnóstico: Sí Estado: EN_ESPERA_DIAGNOSTICO. Duración consulta: 10 segundos. Tiempo transcurrido: 15 segundos.
                Paciente 2. Llegado el 2 con prioridad URGENCIAS_N2. Requiere diagnóstico: Sí Estado: EN_ESPERA_DIAGNOSTICO. Duración consulta: 12 segundos. Tiempo transcurrido: 18 segundos.

          4. **Verificación de recursos disponibles:**
          Se verificó que los equipos de diagnóstico solo atendían a un paciente a la vez, y si había varios pacientes esperando, el equipo diagnosticaba primero a los pacientes con mayor prioridad.
      
       ✅ Conclusión:
            El comportamiento observado es que los pacientes que requieren diagnóstico son atendidos según su prioridad, lo que garantiza que aquellos con mayor prioridad (como emergencias) son atendidos antes que aquellos             con menor prioridad (como consultas generales), independientemente de su orden de llegada. Las pruebas realizadas, como la simulación de llegada de pacientes con diferentes prioridades y el monitoreo del flujo              en consola, confirmaron este comportamiento.







