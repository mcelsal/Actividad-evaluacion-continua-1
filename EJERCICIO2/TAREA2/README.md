# **Actividad-evaluacion-continua-1**
**GESTIÓN ATENCIÓN HOSPITALARIA**

## PREGUNTAS: Ejercicio #2 – Unidades de diagnóstico – Tarea #2

### ❓ Explica la solución planteada en tu código y porqué las has escogido.
    
        Descripción General
            El sistema implementado en el código simula la gestión de un centro médico, donde los pacientes se atienden en función de su **prioridad médica** y su **estado**. 
            El sistema maneja consultas médicas y diagnósticas, asignando recursos (médicos y equipos de diagnóstico) de manera eficiente, siguiendo las prioridades de los pacientes. 
            Esta solución utiliza hilos (`Thread`) para simular la concurrencia en el proceso de atención médica y diagnóstico, permitiendo un manejo paralelo de las consultas y diagnósticos.
        
        📌 **Estructura del Sistema:**
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
            
        📌 **Uso de Concurrencia:**

             - Uno de los principales retos en este tipo de simulación es manejar las tareas concurrentes, como la asignación de médicos a pacientes y la realización de consultas. Para esto, 
               se utilizan **hilos** (`Thread`), lo que permite simular que las consultas y diagnósticos se realizan de manera independiente y no bloquean el resto del sistema.
   
             - El uso de hilos permite que varias consultas puedan ocurrir de manera simultánea, reflejando una situación real en la que los pacientes son atendidos en paralelo por médicos y equipos de diagnóstico. 

             - El **semaforo** (`semaforoPaciente`) es utilizado para evitar que los pacientes se gestionen simultáneamente en la misma instancia, asegurando que cada paciente se gestione correctamente en su turno.

        📌 **Prioridades de Pacientes:**

             - Se implementa un sistema de **prioridades** para gestionar la urgencia con la que se deben atender los pacientes. Hay tres niveles de prioridad: `EMERGENCIAS_N1`, `URGENCIAS_N2`, y `CONSULTAS_GNERALES_N3`.                  Los pacientes con mayor prioridad (como los de emergencia) se atienden primero, mientras que los pacientes con menor prioridad deben esperar su turno.

             - Esta gestión de prioridades se logra mediante una lista `LPacientes`, que contiene pacientes junto con su prioridad. Al asignar un médico, el sistema selecciona al paciente de mayor prioridad y más antiguo                  en la cola.
             
         📌 **Colas de Pacientes por Orden de Llegada:**
         
             - La solución hace uso de una lista (`LPacientes`) para gestionar a los pacientes en espera. Los pacientes se procesan en el orden de su llegada (en caso de tener la misma prioridad). Este enfoque refleja la                  práctica común en los hospitales, donde los pacientes son atendidos según el tiempo de llegada y su urgencia.

        📌 **Simulación del Proceso Médico:**

             - Al llegar un paciente, se asigna a un médico disponible para realizar una consulta. Esta consulta tiene una duración que es simulada mediante un hilo.
   
             - Si el paciente necesita un diagnóstico, después de la consulta se asigna un equipo de diagnóstico disponible, y se simula la duración de este proceso también mediante otro hilo.

             - Al finalizar cada uno de estos procesos, se cambia el estado del paciente, de modo que se pueda hacer un seguimiento de su progreso desde la consulta hasta el diagnóstico y finalmente su finalización.

        📌 **Decisiones Tomadas:**

             - **Uso de hilos para simular la concurrencia**: La simulación de múltiples pacientes siendo atendidos al mismo tiempo es una característica fundamental de este sistema, por lo que el uso de hilos fue       
               esencial para simular este comportamiento.
             - **Prioridades**: Para simular un centro médico real, es importante que las emergencias se atiendan antes que las consultas generales. El sistema de prioridades permite que los pacientes más urgentes reciban 
               atención primero.
             - **Simplicidad en el modelo**: Aunque el sistema puede expandirse para incluir más funcionalidades, se ha mantenido una estructura simple y clara que refleja el flujo de trabajo básico de un centro médico.

         ✅ **¿Por qué elegí esta solución?**

             - Esta solución proporciona un modelo sencillo y claro para simular la gestión de pacientes en un centro médico con atención médica concurrente. El uso de hilos y semáforos permite simular la simultaneidad de                procesos sin complicar demasiado el modelo. Además, la inclusión de prioridades en la asignación de pacientes asegura que el sistema pueda simular un comportamiento realista, donde los pacientes más                        urgentes sean atendidos primero.

             - En resumen, la solución es flexible y extensible, permitiendo la incorporación de más médicos, equipos de diagnóstico y pacientes si fuera necesario. Además, la arquitectura basada en clases y el uso de                    concurrencia refleja cómo funcionaría un centro médico real en términos de asignación de recursos y atención a los pacientes.

### ❓ Plantea otra posibilidad de solución a la que has programado.

    El enfoque alternativo que planteo consiste en la asignación de recursos, tales como médicos y equipos de diagnóstico, mediante el uso de **colas de prioridad**. 
    En lugar de utilizar la llegada del paciente como criterio único para asignar médicos y equipos, los pacientes pidrían ser atendidos en función de su **prioridad médica**, y en segundo lugar por su **tiempo de             llegada**. Esto garantizaría que los pacientes más urgentes fuesen atendidos primero, sin tener que esperar a que se libere un médico o un equipo de diagnóstico disponible.

    - Cambios Propuestos y Esquema de Funcionamiento:

        1. **Uso de Colas de Prioridad**:
           En lugar de gestionar manualmente las prioridades de los pacientes dentro de una lista y asignar recursos de manera secuencial, podríamos usar un sistema de colas prioritarias para gestionar los pacientes en               espera, que permiten que los pacientes con mayor prioridad sean atendidos antes que los de menor prioridad sin necesidad de ordenar constantemente la lista de pacientes. 
                - Los pacientes serian añadidos a una cola de prioridad según su nivel de urgencia (`EMERGENCIAS_N1`, `URGENCIAS_N2`, `CONSULTAS_GNERALES_N3`).
                - Dentro de cada prioridad, los pacientes serían atendidos según el tiempo de llegada, de modo que los más antiguos (en términos de llegada) sean atendidos primero.
        2. **Asignación Dinámica de Médicos y Equipos de Diagnóstico**:
           Los médicos y equipos de diagnóstico serían asignados dinámicamente a los pacientes en función de su prioridad. Si un paciente de alta prioridad llega, se le asignaría el primer recurso disponible, sin importar            el orden de llegada, priorizando siempre la urgencia.
                - Los médicos y equipos de diagnóstico disponibles serían asignados a los pacientes de acuerdo con el orden de prioridad de la cola.
                - Si un paciente requiere diagnóstico, se le asignaría un equipo de diagnóstico disponible tras finalizar la consulta médica.
        3. **Optimización de la Gestión de Estado**:
           La gestión del estado del paciente se realizaría de manera más eficiente con una estructura de eventos que coordinase el paso de un estado a otro, reduciendo el uso de consulta continua en los hilos.
                - Cuando un paciente es atendido, su estado cambiaría a `EN_CONSULTA`, luego pasaría a `EN_ESPERA_DIAGNOSTICO` si es necesario, y finalmente a `FINALIZADO` cuando todo el proceso termine.
                - El estado de cada paciente sería gestionado por una máquina de estados basada en eventos, evitando que los hilos estuviesen constantemente en espera de cambios de estado.
        4. **Escalabilidad**:
           La solución estará diseñada para escalar fácilmente, permitiendo añadir más médicos y equipos de diagnóstico sin necesidad de modificar la lógica central del sistema.

    - Beneficios

        - **Atención Prioritaria**: Los pacientes más urgentes serán atendidos primero, sin que deban esperar a que otros pacientes sean atendidos según el orden de llegada.
        - **Simplicidad**: Usar una cola prioritaria puede simplificar la lógica de asignación de pacientes, ya que la cola se encarga de mantener a los pacientes en el orden correcto según su prioridad. No sería                    necesario realizar consultas adicionales a la lista de pacientes para seleccionar al paciente con mayor prioridad.
        - **Mejor Uso de los Recursos**: Los recursos (médicos y equipos de diagnóstico) se asignarán de manera más eficiente, lo que maximiza la utilización de los mismos.
        - **Eficiencia**: Las colas prioritarias son más eficientes en cuanto a tiempo de ejecución al agregar y eliminar elementos, ya que se mantienen ordenadas de forma automática.
        - **Visualización en tiempo real**: Los administradores podrían ver de manera clara qué pacientes están siendo atendidos, qué médicos y equipos de diagnóstico están disponibles, y cómo se está gestionando el flujo           de pacientes en el centro médico.
        - **Mayor control sobre el proceso**: Este modelo permite simular escenarios más complejos y agregar reglas adicionales para gestionar el flujo de pacientes de manera aún más eficiente (por ejemplo, priorización 
          de pacientes por múltiples criterios, eventos inesperados, etc.).
     
    - Implementación

        Para implementar esta solución, se necesitarían cambios en el código para introducir las **colas de prioridad**. A continuación, se presentan algunos fragmentos clave de código que ilustran cómo se podría                  implementar esta mejora:

            1. **Definir una Cola de Prioridad para Pacientes**:
            2. Añadir Pacientes a la Cola:
        
            Cuando un paciente llega, se añadirá a la cola de prioridad según su nivel de urgencia:
           
            3. Asignación de Recursos:
        
            Los médicos y equipos de diagnóstico serán asignados en función de la prioridad del paciente:
            4. Gestión de Estados:
        
            Los pacientes cambiarán de estado según el progreso de su atención, y el sistema los mantendrá informados de su estado sin necesidad de esperar innecesariamente.     
        
        Conclusión
        La implementación de un sistema de colas de prioridad para gestionar la atención de los pacientes por urgencia podrían optimizar o simplificar el sistema dependiendo de los objetivos y requerimientos del centro            médico, asegurando que los pacientes más críticos reciban atención primero. Además, optimiza el uso de los recursos médicos y de diagnóstico, lo que mejora la capacidad de respuesta del sistema ante situaciones de         alta demanda.



