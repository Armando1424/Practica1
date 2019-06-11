using System;
using Xamarin.Forms;

//josé Manuel Mejía Martínez
//15290909

enum tipos
{
    stone,
    paper,
    scissor
}
namespace Practica1
{
    public partial class MainPage : ContentPage
    {
        int[] arr = { 0, 0, 0 };
        int cont = 0;
        Random rnd = new Random();
        public MainPage()
        {
            InitializeComponent();
            ShowGame.Text = string.Empty;
        }

        private void Stone_Clicked(object sender, EventArgs e)
        {
            //DisplayAlert("OMG","is a Stone","Acept");
            arr[0]++;//agregamos uno a 0 por que el usuario elijio piedra
            Process(0);
            ShowGame.Text += " And the user chose: Stone";
        }

        private void Paper_Clicked(object sender, EventArgs e)
        {
            //DisplayAlert("OMG", "is a Paper", "Acept");
            arr[1]++;//agregamos uno a 1 por que el usuario elijio papel
            Process(1);
            ShowGame.Text += " And the user chose: Paper";
        }

        private void Scissors_Clicked(object sender, EventArgs e)
        {
            //DisplayAlert("OMG", "is a Scissors", "Acept");
            arr[2]++;//agregamos uno a 2 por que el usuario elijio tijera
            Process(2);
            ShowGame.Text += " And the user chose: Scissor";
        }

        private void Process(int theNumber)//hace todo el proceso
        {
            int myNumber = 0;
            if (cont <= 3)//las 3 primeras veces es aleatorio
            {
                myNumber = rnd.Next(0,2);
                cont++;
            }
            else
            {
                myNumber = Lern();//despues es calculado segun su popularidad
            }
            switch (myNumber)//comenzamos a armar la eleccion del pc
            {
                case (int)tipos.stone: ShowGame.Text = "The computer chose: Stone";
                    break;
                case (int)tipos.paper: ShowGame.Text = "The computer chose: Paper";
                    break;
                case (int)tipos.scissor: ShowGame.Text = "The computer chose: Scissor";
                    break;
                default:
                    break;
            }
            DisplayAlert("OMG", MyCompare(myNumber, theNumber),"Acept");//mostramos el ganador
        }

        private int Lern()//aqui hacemos que calcule el mayor y lance una eleciion
        {
            var ok = arr[0];
            var here = 0;

            for (int i = 1; i < arr.Length; i++)//encontramos el mayor de piedra, papel o tijera
            {
                if (ok <= arr[i])
                {
                    ok = arr[i];
                }
            }

            //obtenemos el indice del arreglo para saber quien fue el mayor
            for (int i = 0; i < arr.Length; i++)
            {
                if (ok == arr[i])
                {
                    here = i;
                    //para que no tenga ventaja el usuario, si da clik mas de cuatro veces en la
                    //misma opcion se recetea el valor
                    if (ok > 4)
                    {
                        arr[here] = 0;
                    }
                    break;
                }
            }

            //dado que se sabe cual es el de mayor recurrencia se intenta elejir
            //la opcion que lo venceria
            switch (here)
            {
                case (int)tipos.stone: here = (int)tipos.paper;
                    break;
                case (int)tipos.paper: here = (int)tipos.scissor;
                    break;
                case (int)tipos.scissor: here = (int)tipos.stone;
                    break;
                default:
                    break;
            }
            return here;
        }

        private string MyCompare(int myNumber, int theNumber)//se comparan lo que se ha elejido
        {
            string winner = string.Empty;
            switch (theNumber)//se analiza lo que elijio el usuario contra lo que el pc elijio
            {
                case (int)tipos.stone://si el usuario elijio piedra
                    if ((int)tipos.stone == myNumber)//y el pc elijio piedra entonces es empate
                    {
                        winner = "Both";
                    }
                    else if ((int)tipos.paper == myNumber)//y el pc elijio papel gana pc
                    {
                        winner = "The Computer";
                    }
                    else// de lo contrario gana el usuaro por que la piedra vence a tijeras.
                    {
                        winner = "The user";
                    }
                    break;
                case (int)tipos.paper://se repite lo de arriva
                    if ((int)tipos.paper == myNumber)
                    {
                        winner = "Both";
                    }
                    else if ((int)tipos.scissor == myNumber)
                    {
                        winner = "The Computer";
                    }
                    else
                    {
                        winner = "The user";
                    }
                    break;
                case (int)tipos.scissor:
                    if ((int)tipos.scissor == myNumber)
                    {
                        winner = "Both";
                    }
                    else if ((int)tipos.stone == myNumber)
                    {
                        winner = "The Computer";
                    }
                    else
                    {
                        winner = "The user";
                    }
                    break;
                default:
                    break;
            }

            return winner;//se rretorna quien gano
        }
    }
}
