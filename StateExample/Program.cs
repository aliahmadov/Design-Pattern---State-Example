using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateExample
{

    interface State
    {
        void XClick();

        void TriangleClick();

        void CircleClick();

        void RectangleClick();
    }

    class AttackState : State
    {
        public void CircleClick()
        {
            Console.WriteLine("Lob pass(Goyle atilan top) is executed.");
        }

        public void RectangleClick()
        {
            Console.WriteLine("Ball has been shooted.");
        }

        public void TriangleClick()
        {
            Console.WriteLine("Through Ball(Ara pasi) is executed.");
        }

        public void XClick()
        {
            Console.WriteLine("Pass has been executed.");
        }

    }


    class DefenseState : State
    {
        public void CircleClick()
        {
            Console.WriteLine("Sliding tackle(suruserek mudaxile) is executed.");
        }

        public void RectangleClick()
        {
            Console.WriteLine("Pressure is applied by non-controlled players.");
        }

        public void TriangleClick()
        {
            Console.WriteLine("Goalkeeper is brought out forward.");
        }

        public void XClick()
        {
            Console.WriteLine("Tackle(Mudaxile et).");
        }

    }


    class Game
    {
        private State _state;

        public void ChangeState(State state)
        {
            _state = state;
        }

        public void XClick()
        {
            _state.XClick();
        }

        public void TriangleClick()
        {
            _state.TriangleClick();
        }

        public void CircleClick()
        {
            _state.CircleClick();
        }

        public void RectangleClick()
        {
            _state.RectangleClick();
        }

        public void BallGained()
        {
            Console.WriteLine("Ball has been gained. Prepare, WE ARE MAKING ATTACK.");
            _state = new AttackState();
        }

        public void BallLost()
        {
            Console.WriteLine("Ball is lost, other team is making attack -> EVERYONE TO THE DEFENCE.");
            _state = new DefenseState();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            Console.WriteLine("Game Started\n===================================");
            game.BallGained();
            game.XClick();
            game.TriangleClick();
            game.CircleClick();
            game.RectangleClick();
            game.BallLost();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine();
            game.XClick();
            game.RectangleClick();
            game.CircleClick();
            game.BallGained();

            Console.WriteLine();
            Console.WriteLine("Game is going on and on like that ....");
            Console.WriteLine("When state changes, buttons behave differently.");
            Console.WriteLine();

        }
    }
}
