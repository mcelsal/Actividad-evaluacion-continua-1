# **Actividad-evaluacion-continua-1**
**GESTIÓN ATENCIÓN HOSPITALARIA**

## PREGUNTAS: Ejercicio #2 – Unidades de diagnóstico – Tarea #2

### ❓ Explica la solución planteada en tu código y porqué las has escogido.
    
        Descripción General
            El sistema implementado en el código simula la gestión de un centro médico, donde los pacientes se atienden en función de su **prioridad médica** y su **estado**. 
            El sistema maneja consultas médicas y diagnósticas, asignando recursos (médicos y equipos de diagnóstico) de manera eficiente, siguiendo las prioridades de los pacientes. 
            Esta solución utiliza hilos (`Thread`) para simular la concurrencia en el proceso de atención médica y diagnóstico, permitiendo un manejo paralelo de las consultas y diagnósticos.
        
        **Estructura del Sistema:**
            El sistema se divide en varias clases que gestionan distintas entidades y procesos dentro del centro médico:
            
              - **Entidades Principales**:
                  - **Medico**: Representa a un médico en el centro médico.
                  - **EquioDiagnostico**: Representa a un equipo de diagnóstico, similar a la clase de los médicos.
                  - **Paciente**: Representa a un paciente que llega al centro médico, con propiedades como el tiempo de consulta y si necesita diagnóstico.
                  - **Consulta** y **ConsultaDiagnostica**: Representan las consultas médicas y de diagnóstico que se realizan, respectivamente. 
                    Ambas clases gestionan un hilo que simula el tiempo de consulta y diagnóstico.

              - **Proceso del Centro Médico**:
                 - **CentroMedico**: Es la clase central que gestiona la llegada de pacientes, la asignación de médicos y equipos de diagnóstico, y la simulación del flujo de trabajo en el centro médico. 
                   Controla la 0disponibilidad de los recursos (médicos y equipos de diagnóstico) y el estado de los pacientes.
   
            La estructura de clases está diseñada para separar las responsabilidades de cada entidad. Por ejemplo, los médicos y equipos de diagnóstico son responsables de su propia disponibilidad, 
            mientras que el centro médico se encarga de gestionar las consultas y diagnósticos de manera eficiente.
            
        **Uso de Concurrencia:**

             - Uno de los principales retos en este tipo de simulación es manejar las tareas concurrentes, como la asignación de médicos a pacientes y la realización de consultas. Para esto, 
               se utilizan **hilos** (`Thread`), lo que permite simular que las consultas y diagnósticos se realizan de manera independiente y no bloquean el resto del sistema.
   
             - El uso de hilos permite que varias consultas puedan ocurrir de manera simultánea, reflejando una situación real en la que los pacientes son atendidos en paralelo por médicos y equipos de diagnóstico. 

             - El **semaforo** (`semaforoPaciente`) es utilizado para evitar que los pacientes se gestionen simultáneamente en la misma instancia, asegurando que cada paciente se gestione correctamente en su turno.

        **Prioridades de Pacientes:**

             - Se implementa un sistema de **prioridades** para gestionar la urgencia con la que se deben atender los pacientes. Hay tres niveles de prioridad: `EMERGENCIAS_N1`, `URGENCIAS_N2`, y `CONSULTAS_GNERALES_N3`.                 Los pacientes con mayor prioridad (como los de emergencia) se atienden primero, mientras que los pacientes con menor prioridad deben esperar su turno.

             - Esta gestión de prioridades se logra mediante una lista `LPacientes`, que contiene pacientes junto con su prioridad. Al asignar un médico, el sistema selecciona al paciente de mayor prioridad y más antiguo                 en la cola.
             
         **Colas de Pacientes por Orden de Llegada:**
         
             - La solución hace uso de una lista (`LPacientes`) para gestionar a los pacientes en espera. Los pacientes se procesan en el orden de su llegada (en caso de tener la misma prioridad). Este enfoque refleja la                 práctica común en los hospitales, donde los pacientes son atendidos según el tiempo de llegada y su urgencia.

        **Simulación del Proceso Médico:**

             - Al llegar un paciente, se asigna a un médico disponible para realizar una consulta. Esta consulta tiene una duración que es simulada mediante un hilo.
   
             - Si el paciente necesita un diagnóstico, después de la consulta se asigna un equipo de diagnóstico disponible, y se simula la duración de este proceso también mediante otro hilo.

             - Al finalizar cada uno de estos procesos, se cambia el estado del paciente, de modo que se pueda hacer un seguimiento de su progreso desde la consulta hasta el diagnóstico y finalmente su finalización.

       **Decisiones Tomadas:**

             - **Uso de hilos para simular la concurrencia**: La simulación de múltiples pacientes siendo atendidos al mismo tiempo es una característica fundamental de este sistema, por lo que el uso de hilos fue       
               esencial para simular este comportamiento.
             - **Prioridades**: Para simular un centro médico real, es importante que las emergencias se atiendan antes que las consultas generales. El sistema de prioridades permite que los pacientes más urgentes reciban 
               atención primero.
             - **Simplicidad en el modelo**: Aunque el sistema puede expandirse para incluir más funcionalidades, se ha mantenido una estructura simple y clara que refleja el flujo de trabajo básico de un centro médico.

        **¿Por qué elegí esta solución?**

             - Esta solución proporciona un modelo sencillo y claro para simular la gestión de pacientes en un centro médico con atención médica concurrente. El uso de hilos y semáforos permite simular la simultaneidad de                 procesos sin complicar demasiado el modelo. Además, la inclusión de prioridades en la asignación de pacientes asegura que el sistema pueda simular un comportamiento realista, donde los pacientes más urgentes                sean atendidos primero.

             - En resumen, la solución es flexible y extensible, permitiendo la incorporación de más médicos, equipos de diagnóstico y pacientes si fuera necesario. Además, la arquitectura basada en clases y el uso de                     concurrencia refleja cómo funcionaría un centro médico real en términos de asignación de recursos y atención a los pacientes.

### ❓ Plantea otra posibilidad de solución a la que has programado.





