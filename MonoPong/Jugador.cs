using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoPong
{
    class Jugador
    {
        private Texture2D jugadorTextura;
        public Texture2D JugadorTextura
        {
            get{ return jugadorTextura;}
            set { this.JugadorTextura = jugadorTextura; }
        }

        //private Vector2 posicion;
        public Vector2 Posicion;

        private int puntuacion;
        public int Puntuacion
        {
            get { return puntuacion; }
            set { this.Puntuacion = puntuacion; }
        }

        private int ancho;
        public int Ancho
        {
            get { return ancho; }
        }


        private int alto;
        public int Alto
        {
            get { return alto; }
        }
        


        public void inicializar(Texture2D textura, Vector2 pos)
        {
            jugadorTextura = textura;
            Posicion = pos;
            alto = jugadorTextura.Height;
            ancho = jugadorTextura.Width;
            puntuacion = 0;
        }


        public void actualizar()
        {

        }

        public void dibujar(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(jugadorTextura, Posicion, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);            
        }

        public Jugador()
        {

        }
    }
}
