```text
   ____     ____             _____
  / __/__  / / /__ _    __  / ___/_ _________ ___  ____
 / _// _ \/ / / _ \ |/|/ / / /__/ // / __(_-</ _ \/ __/
/_/  \___/_/_/\___/__,__/  \___/\_,_/_/ /___/\___/_/
```

# 🖱️ Follow Cursor en Unity 2D

Mueve el ratón por la vista **Game** y verás cómo un círculo va tras el cursor. Este proyecto acompaña al tutorial de Frogames Formación y muestra cómo convertir la posición del ratón en un destino dentro de la escena.

**[Lee el tutorial paso a paso en Frogames Formación](https://cursos.frogamesformacion.com/pages/blog/objeto-seguir-cursor-unity-2d)**

## Pruébalo en Unity

1. Clona o descarga este repositorio.
2. Abre la carpeta del proyecto desde Unity Hub con **Unity `6000.6.7f1`**.
3. Abre la [escena `FollowCursor`](Assets/Scenes/FollowCursor.unity), pulsa **Play** y mueve el ratón dentro de la vista **Game**.

Selecciona **Circle** en la jerarquía y cambia **Follow Speed** en el Inspector. El valor inicial es **5 unidades por segundo**. Prueba con **2** y luego con **10** para ver cómo cambia el seguimiento.

## Del ratón a la escena

Todo ocurre en [`FollowCursor.cs`](Assets/Scripts/FollowCursor.cs):

1. **Leer el ratón.** El Input System obtiene la posición del cursor en píxeles con `Mouse.current.position.ReadValue()`.
2. **Convertir la posición.** `Camera.ScreenToWorldPoint` convierte esos píxeles en coordenadas de la escena. El script conserva la coordenada **Z** del círculo para que se mueva en el plano **XY**.
3. **Acercar el círculo.** `Vector3.MoveTowards` avanza hacia el destino hasta un máximo de `followSpeed * Time.deltaTime` por fotograma.
