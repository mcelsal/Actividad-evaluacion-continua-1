 📌 ⚙️ 💡 💭 📋 🔄 📊 🤔

         ✅ 🧠 ✔️ 🧾 🔍 🛠

            ****🏥 GESTIÓN ATENCIÓN HOSPITALARIA 🩺****


# **Actividad-evaluacion-continua-1**
**🏥 GESTIÓN ATENCIÓN HOSPITALARIA 🩺**

## 🧠 PREGUNTAS: Ejercicio #2 – Estadísticas y logs – Tarea #5

### ❓ ¿Puedes explicar tu código y porque has decidido hacerlo así? 

    📌 Descripción del Proyecto:

        Este programa simula el funcionamiento de un centro médico que atiende pacientes con diferentes niveles de prioridad: Emergencias (N1), Urgencias (N2) y Consultas Generales (N3). El                sistema administra consultas médicas y diagnósticos usando múltiples hilos para representar médicos, pacientes y equipos diagnósticos trabajando en paralelo. El objetivo principal es               modelar el flujo de pacientes en un entorno concurrente, respetando la prioridad de atención y registrando estadísticas al finalizar.

        Las entidades principales del sistema son:

           - **Pacientes**: Pueden tener prioridad EMERGENCIAS, URGENCIAS o CONSULTAS GENERALES.
           - **Médicos**: Atienden consultas médicas.
           - **Equipos de Diagnóstico**: Atienden a pacientes que requieren diagnósticos adicionales.
           - **Centro Médico**: Coordina la asignación de recursos y maneja el flujo de pacientes.

     ⚙️ Lógica del Sistema

           - Se generan 20 pacientes con tiempos de consulta y diagnóstico aleatorios.
           - Cada paciente es asignado una prioridad aleatoria al llegar.
           - El centro médico tiene 4 médicos y 2 equipos de diagnóstico.
           - El sistema corre en **hilos paralelos** (`Thread`) para simular la concurrencia de procesos (consultas y diagnósticos).
           - El `CentroMedico` actúa como hilo principal que constantemente revisa la disponibilidad de médicos y equipos para atender pacientes.
           - Se recopilan estadísticas de tiempos de espera y uso de recursos al finalizar el proceso.

     💭 Elección del Planteamiento:

         Se ha utilizado un enfoque **multihilo** 🛠, donde: 

           - Cada consulta y diagnóstico se ejecuta en su propio hilo.
           - El centro médico tiene su propio hilo que constantemente busca asignar recursos disponibles.
           - Se aplican **bloqueos simples** (`bloqueo` con un `bool`) para evitar condiciones de carrera entre llegadas de pacientes y asignaciones.
     
     🤔 ¿Por qué se eligió esta solución?
     
           - Es **más accesible y fácil de entender** para quienes están aprendiendo sobre concurrencia.
           - Permite ver claramente la creación y ejecución de procesos simultáneos.
           - Proporciona una **base sólida** sobre la cual se puede evolucionar hacia una arquitectura más compleja y escalable si es necesario.
           
     ✅ Ventajas:

           - Emulación realista del comportamiento asíncrono del centro médico.
           - Permite ejecutar consultas y diagnósticos en paralelo, optimizando tiempos.
           - Código modular, donde cada entidad tiene su propia clase.

     📊 Estadísticas:
     
           - Al finalizar, el sistema calcula:
              - Cantidad de pacientes atendidos por prioridad.
              - Tiempos promedio de espera por prioridad.
              - Uso promedio de los equipos de diagnóstico.
              - Esto ayuda a evaluar el rendimiento del centro médico y detectar posibles cuellos de botella.
           
     📋 Conclusión:
     
         Este proyecto demuestra cómo modelar un sistema complejo como un centro de salud mediante programación concurrente, simulando múltiples recursos y prioridades. Es una buena base para               escalar a sistemas más realistas con mejoras como persistencia de datos, interfaz gráfica o simulación en tiempo real.













