# **Actividad-evaluacion-continua-1**
**🏥 GESTIÓN ATENCIÓN HOSPITALARIA 🩺**

## 🧠 PREGUNTAS: Ejercicio #3 – Pacientes infinitos – Tarea #1

### ❓ Tarea 1, ¿cumple requisitos? 

         ✅ Requisitos y cumplimiento
                  Uso de múltiples hilos ✔️ Se utilizan Thread para consultas y diagnósticos.
                  Gestión de prioridades ✔️ Tres niveles definidos en el enum Prioridad.
                  Simulación realista con tiempos ✔️ Usa TimeSpan y DateTime.Now, simula tiempos de espera.
                  Manejo de recursos limitados (médicos, equipos) ✔️ Médicos y equipos marcados como disponible o no.
                  Estadísticas finales ✔️ Muestra pacientes atendidos y tiempos promedios por prioridad.
                  Control de acceso a recursos compartidos ✔️ Se usa una variable de bloqueo para controlar concurrencia de acceso.

         ⚙️ Explicación del diseño y decisiones tomadas
                  1. Multithreading
                           Cada consulta o diagnóstico se ejecuta en un hilo independiente (Thread). Esto simula de forma realista la                                      concurrencia de procesos en un centro médico.
                               📌 procesoCita = new Thread(this.IniciarConsulta);

                  2. Modelo basado en entidades
                           Se crean clases específicas para:
                                    - Paciente
                                    - Medico
                                    - Consulta
                                    - ConsultaDiagnostica
                           Esto permite encapsular el comportamiento y datos asociados a cada entidad.

                  3. Priorización de pacientes
                           Se utiliza un enum llamado Prioridad para clasificar pacientes en tres niveles:
                                    - EMERGENCIAS_N1
                                    - URGENCIAS_N2
                                    - CONSULTAS_GNERALES_N3
                           En el flujo de atención, los pacientes con mayor prioridad se atienden primero usando OrderBy(x => x.prioridad).

                  4. Gestión de estado del paciente
                           Cada paciente tiene un Estado, que cambia a lo largo de su paso por el centro médico:
                                    - Espera de consulta
                                    - En consulta
                                    - Espera de diagnóstico
                                    - En diagnóstico
                                    - Finalizado
                           Este seguimiento permite visualizar la trazabilidad de cada paciente en consola.

                  5. Estadísticas
                           Al finalizar la simulación, se muestran:
                                    - Pacientes atendidos por tipo
                                    - Tiempo promedio de espera
                                     - Uso de los equipos de diagnóstico
                                    
                           Esto ofrece una vista clara del rendimiento del centro médico.
                                    
         ⚠️ Posibles mejoras
                  Uso de lock o Monitor en lugar de la variable bloqueo para sincronización más robusta.
                  Sustitución de Thread por Task y async/await para mejor control de concurrencia moderna.
                  Persistencia de resultados en un archivo o base de datos.

### ❓ Tarea 2, ¿qué comportamientos no previstos detectas?

                  1. 🔁 Bucle de espera activo (while (true))
                           Problema: Tanto en la clase Consulta como en ConsultaDiagnostica, los métodos IniciarConsulta y                                                IniciarConsultaDiagnostica usan un while (true) que verifica si ha transcurrido el tiempo, sin dormir el hilo.
                                   
                  2. 🚫 Bloqueo de llegada de pacientes con Task.Delay
                           Problema: El bloqueo artificial usando Task.Delay no escala con más pacientes o entradas simultáneas y puede                                    provocar cuellos de botella.
                 3. 🩺 Identificador de llegada no usa tiempo real
                           Problema: Este valor no representa una marca de tiempo real sino un índice, lo que distorsiona las estadísticas de                              espera.
                  4. 📉 Posibles estadísticas distorsionadas
                  
                  5. 🪵 Diagnóstico no impacta estadísticas finales
                           Si un paciente pasa por diagnóstico, no se mide el tiempo de espera ni uso del recurso completo (entrada/salida                                 diagnóstica).
                  
                           Solo se registra que se finalizó, pero no hay desglose de tiempo por tipo de atención.
                  
### ❓ Tarea 3, ¿Cómo adaptarías tu solución? 
       
         1. 🏗️ Modularización del sistema
                  Antes: Clases como Consulta, ConsultaDiagnostica y ManejoPacientes estaban acopladas.
                  Ahora: Separar responsabilidades usando patrones como:
                           Productor/Consumidor para la llegada de pacientes.
                           Controladores por tipo de recurso (médico, diagnóstico).
                           Interfaces comunes para unificar el flujo de atención.

         2. ⏳ Tiempos reales y trazabilidad
                  Antes: Se usaban contadores o valores simulados para llegada y atención.
                  Ahora: Adaptar el sistema para registrar:
                  Marca de tiempo real (DateTime.Now) o temporizador (Stopwatch).
                  Diferenciar claramente: tiempo de espera vs. tiempo de atención vs. tiempo de diagnóstico.
         
         3. 🧾 Estructura de datos más robusta
                  Antes: Uso de listas compartidas (List<Paciente>) con bloqueos manuales.
                  Ahora: Usar estructuras como:        
                  ConcurrentQueue<Paciente> para cola de espera.       
                  PriorityQueue<Paciente> (si está disponible) o implementación manual basada en prioridad.
         
         4. 📈 Estadísticas más completas
                  Agregar estadísticas por:
                  Tiempo promedio de diagnóstico.
                  Carga de trabajo por médico.       
                  Uso de equipos de diagnóstico.            
                  Número de pacientes reprogramados o descartados (si aplica).
                  
         5. ⚙️ Control centralizado
                  Incorporar un coordinador de recursos que:                  
                  Verifique disponibilidad.           
                  Decida a qué recurso asignar el siguiente paciente.       
                  Optimice la asignación según tiempos de espera y prioridad.
         
         6. 🔄 Escenarios de simulación dinámicos
                  Nueva propuesta: Adaptar para que el sistema admita:            
                  Diferente número de médicos y equipos.        
                  Pacientes cargados desde archivo o entrada dinámica.       
                  Reglas de negocio configurables (p. ej., tiempo máximo de espera por prioridad).
                  
         🛠️ Tecnologías y herramientas
                  Lenguaje: C#
                  Concurrencia: Thread, Task, Monitor, ConcurrentQueue 
                  Medición de tiempo: Stopwatch  
                  Logging: Consola o salida a archivo opcional
         
         📌 Conclusión
                  La solución se adapta mediante:
                           Mejor estructura concurrente. 
                           Datos reales para trazabilidad.       
                           Separación clara de responsabilidades.                      
                           Escalabilidad para futuras extensiones (como pacientes en espera, reintentos, tipos de diagnóstico, etc).
                           
                  Esto permite un sistema más realista, mantenible y preparado para nuevos desafíos.



