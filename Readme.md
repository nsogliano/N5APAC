Nota: 
Nunca pude ejecutar los tests porque la PC del laboratorio anda terrible y tuve que hacer el trabajo desde Visual Studio Code, y el vscode tiene .NET 7.0...
Tampoco se si hay errores de compilacion ni nada así porque no pude correrlo, pero bueno, es lo que hay jeje.
Para subir la solucion tuve que bajarme el ZIP del proyecto y lo subi una vez hecho en el orden de los ejercicios.

- **Ejercicio 4 (Pregunta teórica):**
    
    Pregunta: Cómo registraron la dependencia del ejercicio anterior? Por qué eligieron esa forma de registrarlo? Qué cambiaría en caso de utilizar alguno de los otros dos? 
    Deberán colorcar la respuesta a la pregunta en un archivo [Readme.md](http://Readme.md) en su repositorio forkeado.

Hice la inyección de dependencia mediante el uso del método AddScoped. Lo agregué en el Program.cs, justo antes de donde se registra el StudentRepository.
No uso AddTransient porque lo que hace es crear una nueva instancia de la clase (StudentLogic) cada vez que se requiera, es decir se generaría una instancia diferente por cada componente que use el servicio. No nos sirve esta alternativa porque aumentaría el uso de memoria y recursos ya que se generan mùltiples instancias innecesariamente.

No uso AddSingleton porque no es algo que se estila en lo que es desarrollo web. Los singleton se utilizan de otra manera, si lo usamos en este caso podrìamos tener problemas de concurrencia entre solicitudes. 