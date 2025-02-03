# VR Programming Playground

## Descripción
**VR Programming Playground** es un entorno de realidad virtual diseñado para explorar y jugar con representaciones tridimensionales de los conceptos tradicionales de la programación.

## Cómo funciona
Al iniciar, encontrarás unas mesas con cuatro botones; cada uno permitirá instanciar un objeto diferente.

### Moneda (instanciable)
Este elemento representa los tipos de datos numéricos. En ella se podrá observar el valor que tiene actualmente y siempre se inicializa en cero (0).

### Martillo
Este objeto, junto con su correspondiente menú flotante, permite golpear las monedas para alterar su valor. En el menú se puede seleccionar una de cuatro operaciones básicas (suma, resta, multiplicación y división) y un valor. Luego de dar aceptar en el menú, el martillo quedará configurado con esta operación y valor, el cual será aplicado al valor actual de la moneda cada vez que se golpee con el martillo.

### Fichas (instanciable)
Este objeto permite representar datos de tipo `char`. Mediante juntar varias de estas se pueden crear cadenas. También, con un poco de fuerza, pueden ser separadas unas de otras.

El segundo propósito de este elemento es el de instanciar caracteres especiales para operaciones lógicas (`>`, `<`, `≥`, `≤`, `==`) que se usan en el campo de "operador" de la pista.

Para instanciarla, se debe elegir un carácter en el menú flotante, dar aceptar y oprimir el botón.

### Pistas (instanciable)
- **Pista simple**: Permite representar el flujo de una función. Para lograr esto, basta con instanciar una o varias pistas, alinearlas y poner una moneda encima de ellas para ver cómo se mueve a través del flujo.
- **Pista con condición**: Tiene dos campos adicionales, uno donde se debe colocar una ficha con un carácter especial y otro donde se coloca una moneda. Cuando una moneda pasa por esta pista en particular, se genera una comparación lógica. El resultado se obtiene mediante el cambio de color de la pista (verde para `true` y rojo para `false`).

## Repositorio
En la carpeta de **Assets** se encuentra lo necesario para editar o configurar el ambiente.

- **Assets/FBX**: Contiene todos los archivos `.fbx` pertenecientes a los modelos creados en Blender.
- **Assets/Prefabs**: Contiene los modelos usados para instanciar los objetos dentro de la experiencia.
- **Assets/Scripts**: Contiene todo lo relacionado al código en C# para la interacción y comportamientos de los objetos y el entorno.
- **Assets/Scenes**: Contiene la escena que representa el ambiente.

## Requerimientos
### Software
- Unity 2021 o superior
- XR Interaction Toolkit para interacción en VR
- Oculus Integration Package para compatibilidad con Oculus Quest 2

### Hardware
- Oculus Quest 2 con controladores
- PC con capacidad para desarrollo en Unity y VR

## Instalación
1. Clonar el repositorio:
   ```sh
   git clone https://github.com/jsalguero1/VR-Programming-Playground.git
   ```
2. Abrir el proyecto en Unity.
3. Instalar las dependencias necesarias (XR Interaction Toolkit, Oculus Integration).
4. Configurar Oculus Quest 2 en modo desarrollador y conectarlo al PC.
5. Ejecutar el proyecto desde Unity o compilarlo para Oculus Quest 2.

## Demo de funcionamiento
Para ver el video de explicación y demostración de este proyecto, dirígete al siguiente enlace de YouTube:
[![Demo en YouTube](https://img.youtube.com/vi/q3BrBxewIwg/0.jpg)](https://youtu.be/q3BrBxewIwg)


 
