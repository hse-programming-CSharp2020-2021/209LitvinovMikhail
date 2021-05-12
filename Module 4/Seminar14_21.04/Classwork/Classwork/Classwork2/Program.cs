using System;

namespace Classwork2
{

    public class State {

        public decimal Population { get; private set; }

        public decimal Area { get; private set; }

        public State () {
            this.Population = 0;
            this.Area = 0;
        }

        public State(decimal population, decimal area) {
            this.Population = population;
            this.Area = area;
        }

        public static State operator +(State firstState, State secondState) =>
            new State(firstState.Population + secondState.Population, firstState.Area + secondState.Area);

        public static bool operator >(State firstState, State secondState) {
            return ((firstState.Area <= 0) ? firstState.Population : firstState.Population / firstState.Area) >
                ((secondState.Area <= 0) ? secondState.Population : secondState.Population / secondState.Area);
        }

        public static bool operator <(State firstState, State secondState) {
            return ((firstState.Area <= 0) ? firstState.Population : firstState.Population / firstState.Area) <
                ((secondState.Area <= 0) ? secondState.Population : secondState.Population / secondState.Area);
        }

        public override string ToString() => $"Population: {this.Population}, Area: {this.Area}";
    }




    class Program
    {
        static void Main(string[] args)
        {
            State firstState = new State(25, 50);
            State secondState = new State(27, 48);
            State thirdState = firstState + secondState;
            Console.WriteLine(thirdState);
            Console.WriteLine(firstState > secondState);
        }
    }
}


/* Есть класс State, который представляет государство:



Добавьте в класс оператор сложения, который бы позволял объединять государства. А также операторы сравнения < и > для сравнения государств по какому-нибудь критерию (например, по населению или территории). Наподобие



Mariia, [21.04.21 17:49]
class State{ publicdecimal Population { get; set; } // население publicdecimal Area { get; set; } // территория}



Mariia, [21.04.21 17:49]
State state1 = newState();State state2 =new State();State state3 = state1 + state2;boolisGreater = state1 > state2;

*/