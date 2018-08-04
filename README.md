# Ricochet

Homage to the [classic BBC Micro game](http://bbcmicro.co.uk/game.php?id=949).

## Klotski

Klotski is a micro-framework sitting on top of monogame, supporting the easy creation of tile-based 2D platform games. It is named after a Polish sliding-tile puzzle. The framework is still in development alongside Ricochet.
    
Ricochet-specific logic should go in the Ricochet project, whereas game physics and general mechanics should go in Klotski. The Ricochet project should not need to reference monogame.

## Installation details for Windows/Visual Studio

- Download [Visual Studio 2017 Community](https://visualstudio.microsoft.com/downloads/)
- Download [Monogame 3.6 for Visual Studio](http://www.monogame.net/2017/03/01/monogame-3-6/)
- Download [the .net framework 4.6.1](https://www.microsoft.com/net/download/visual-studio-sdks)
- Download [mono](http://www.mono-project.com/download/stable/#download-win) (64-bit version and GTK#)
- In visual studio, go to tools, get tools -> get tools and features -> workloads and make sure you have these installed:
  - universal windows platform development
  - .net desktop development
  - mobile development with .net
  - .net core cross-platform development
