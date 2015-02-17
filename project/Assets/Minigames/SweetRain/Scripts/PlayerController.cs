using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SweetRain
{
	public class PlayerController : Player.Controller
	{
        // Aqui van los métodos que implementan la logica del
        // minijuego para el jugador.

        protected override bool GameOverCheck()
        {
            return GetScore() >= 20;
        }
	}
}
