# **Actividad-evaluacion-continua-1**
**🏥 GESTIÓN ATENCIÓN HOSPITALARIA 🩺**

## 🧠 PREGUNTAS: Ejercicio #2 – Más pacientes – Tarea #3

### ❓ Explica el planteamiento de tu código y plantea otra posibilidad de solución a la que has programado y porqué has escogido la tuya.
    
        Este proyecto simula el funcionamiento de un centro médico, donde los pacientes son atendidos según su **prioridad médica** (emergencias, urgencias o consultas generales), considerando también la disponibilidad de  **médicos** y **equipos de diagnóstico**.
                
        1. 🔧 Solución Implementada

           Se ha desarrollado una solución basada en **programación concurrente** usando hilos (`Thread`). Esto permite que tanto las consultas médicas como las pruebas diagnósticas se realicen en            paralelo, replicando el comportamiento real de un centro médico donde distintos pacientes pueden estar siendo atendidos al mismo tiempo.
               - **Ingreso aleatorio de pacientes**, con prioridades asignadas y posibilidad de requerir diagnóstico.
               - **Asignación automática de médicos disponibles** a los pacientes según su prioridad.
               - **Asignación de equipos de diagnóstico** cuando el paciente lo requiere.
               - **Control del estado de cada paciente**, desde que entra al centro hasta que finaliza su proceso.
               - **Control de trazabilidad y tiempos**, con medición del tiempo total de atención y seguimiento del estado de cada paciente.
           Se han utilizado listas para gestionar pacientes, médicos, equipos y citas y para evitar problemas de concurrencia en momentos críticos como el ingreso de pacientes, se utiliza una                 bandera de control (`bloqueo`) que sincroniza los accesos.
        
        2. ✔️ ¿Por qué esta solución?

                - Simula un entorno **realista y concurrente** donde múltiples recursos y procesos ocurren al mismo tiempo.
                - Permite **priorizar la atención médica** de forma efectiva.
                - Favorece la **escalabilidad**, pudiendo fácilmente ampliar el número de médicos, equipos o pacientes.
                - Aumenta la **fidelidad de simulación**, mostrando tiempos de espera y atención individual.
                - Refleja mejor la **complejidad y dinamismo** de un entorno real de atención médica.
         
         3. Otra Posible Solución 💡
            Una alternativa más sencilla podría ser un **modelo secuencial sin concurrencia**:
                - Los pacientes se gestionan uno a uno en orden de llegada.
                - No hay hilos: cada paciente espera su turno para ser atendido por un único médico y, si lo requiere, por un único equipo diagnóstico.
                - El flujo es lineal: Cada paciente espera a que el anterior termine por completo (consulta y diagnóstico) antes de ser atendido.
                  ✅ Ventajas:    
                      - Muy fácil de implementar.
                      - No requiere control de sincronización ni hilos.
                      - Ideal para entornos educativos o centros médicos con bajo volumen de pacientes.
                  📌 Desventajas:  
                      - No refleja la realidad de un centro médico con múltiples recursos.
                      - Ineficiente: tiempos de espera más largos.
                      - No permite simulación simultánea ni escalabilidad para situaciones más complejas.

            4. Justificación de la elección 💭

               Se ha optado por la solución concurrente porque se ajusta mucho mejor a una **simulación realista** de un entorno clínico moderno. Permite ver cómo interactúan múltiples recursos,                  cómo se priorizan casos críticos y cómo se gestiona el tiempo de forma más eficiente.
                
               Además, ofrece una **oportunidad educativa más rica**, al permitir trabajar con hilos, sincronización y estados múltiples dentro de un flujo asíncrono.

### ❓ ¿Los pacientes que deben esperar entran luego a la consulta por orden de llegada? Explica que tipo de pruebas has realizado para comprobar este comportamiento. 

    📋  No exactamente. Los pacientes **no entran a consulta estrictamente por orden de llegada**, sino que se priorizan según su **nivel de urgencia**. El sistema implementa una **gestión por            prioridad médica**, donde los pacientes con:

            1. `EMERGENCIAS_N1` son atendidos antes que
            2. `URGENCIAS_N2`, quienes a su vez se priorizan sobre
            3. `CONSULTAS_GENERALES_N3`

          Dentro de cada grupo de prioridad, **sí se respeta el orden de llegada**.

     🔍 Pruebas realizadas para validar este comportamiento

          Para comprobar que el sistema respeta esta lógica de atención, se realizaron las siguientes pruebas:

          1. **Prueba con pacientes mixtos**:
             - Se introdujeron pacientes con diferentes niveles de prioridad de forma alternada.
             - Se comprobó que siempre se atendía primero al de mayor prioridad, aunque haya llegado después.
             - Resultado esperado: un paciente con `EMERGENCIAS_N1` es atendido antes que uno con `URGENCIAS_N2` llegado previamente.

          2. **Prueba con pacientes de la misma prioridad**:
             - Se simularon varios pacientes con la misma prioridad (por ejemplo, todos `URGENCIAS_N2`).
             - Se verificó que dentro de ese grupo, el orden de llegada se mantenía.
             - Resultado esperado: se respeta el orden FIFO (First In, First Out) dentro de la misma prioridad.
          
          3. **Verificación con trazas**:
             - Se usó la traza por consola (`TrazaCambioEstado`) que muestra el orden de llegada y el momento en que el paciente es atendido.
             - Se compararon los identificadores de llegada (`LlegadaHospital`) y los cambios de estado.

     ✅ Conclusión

          El sistema **combina prioridad médica con orden de llegada** de manera jerárquica: primero se atienden los más urgentes, y dentro de cada grupo, se mantiene la equidad temporal. Las                pruebas demostraron que este comportamiento se cumple correctamente.




                      
       
