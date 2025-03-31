# **Actividad-evaluacion-continua-1**
**🏥 GESTIÓN ATENCIÓN HOSPITALARIA 🩺**

## 🧠 Ejercicio #2 – Prioridades de los pacientes – Tarea #4

### ❓ Explica el planteamiento de tu código y plantea otra posibilidad de solución a la que has programado y porqué has escogido la tuya.

    📌 Enfoque actual implementado:

        ✔️ El sistema simula el funcionamiento de un centro médico mediante programación concurrente en C# con `Threads` y `Task.Delay`. La lógica principal se basa en:

              - **Simulación de pacientes** que llegan con distinta prioridad (`EMERGENCIAS_N1`, `URGENCIAS_N2`, `CONSULTAS_GENERALES_N3`) y necesidades (con o sin diagnóstico posterior).
              - **Gestión de recursos limitados**: médicos y equipos diagnósticos.
              - **Asignación por prioridad**: se atiende primero al paciente con mayor urgencia.
              - **Modelo multihilo**: se utilizan `Threads` para representar de forma paralela las consultas y diagnósticos.

            La clase `CentroMedico` gestiona el proceso general, en un hilo principal que revisa constantemente si hay recursos disponibles y pacientes en espera, priorizando a quienes tengan                  mayor urgencia. Las clases `Consulta` y `ConsultaDiagnostica` encapsulan la lógica de cada atención, simulando la duración de cada proceso mediante la comparación de tiempos.

            El sistema registra mediante trazas en consola el paso de los pacientes por los distintos estados: espera, consulta, diagnóstico y finalización.

     💡 Una alternativa al enfoque actual sería:
         
         🛠 Usar una **cola de prioridad** (como `PriorityQueue` o `SortedList`) en lugar de ordenar manualmente con `.OrderBy(...)` en cada ciclo.

             ✅ Ventajas:
                 - Mayor eficiencia al evitar ordenamientos repetitivos.
                 - Modelo de atención más fiel a estructuras reales de gestión de colas.
                 - Posible implementación más clara del comportamiento FIFO dentro de la misma prioridad.

     🔄 Otra posibilidad: utilizar `async/await` con `Task` en lugar de `Thread`:

             ✅ Ventajas:
                 - Mejor escalabilidad y gestión de recursos (los `Task` son más ligeros que los `Thread`).
                 - Permite una mayor flexibilidad y más control sobre la ejecución asíncrona.
                 - Facilita la implementación de cancelaciones, timeouts y pruebas unitarias.

     ⚙️ ¿Por qué se eligió este enfoque?

         Se optó por un modelo basado en `Thread` porque:
         
             - Es **más didáctico** para entender la ejecución paralela sin abstracciones.
             - Permite **control directo sobre los hilos** (ideal para simulaciones educativas).
             - Se ajusta al objetivo del proyecto: una simulación realista pero controlada del flujo de atención médica.
         
         El uso de `.OrderBy(x => x.prioridad)` y el control manual del ciclo permiten tener una lógica clara y personalizable, sin depender de estructuras avanzadas que podrían ocultar parte del           comportamiento interno.


      💭 Conclusión:

         El sistema implementado logra simular de forma efectiva el comportamiento de un centro médico con pacientes de distinta prioridad, gestionando recursos y tiempos de espera. La elección             del enfoque basado en `Thread` y ordenación manual ofrece claridad y control, aunque podrían explorarse mejoras en eficiencia o modernización del código usando estructuras y patrones más           avanzados.
