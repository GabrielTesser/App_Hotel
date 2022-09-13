using System;
using System.Collections.Generic;
using System.Text;

namespace hotel.Model
{
    public class Hospedagem
    {

        int qnt_adulto;
        Suite quarto_escolhido;

        public Suite QuartoEscolhido
        {
            get => quarto_escolhido;
            set
            {
                if (value == null)
                    throw new Exception("Por favor, selecione sua acomodação");

                quarto_escolhido = value;
            }
        }

        public int Qntadulto
        {
            get => qnt_adulto;
            set
            {
                if (value == 0)
                    throw new Exception("Por favor, selelecio a quantidade de adultos");

                qnt_adulto = value;
            }
        }

        public int QntCriancas { get; set; }
        public DateTime DataCheckIn { get; set; }
        public DateTime DataCheckOut { get; set; }

        public int Estadia
        {
            get
            {
                return DataCheckOut.Subtract(DataCheckIn).Days;
            }
        }

        public double ValorTotal
        {
            get => ((Qntadulto * QuartoEscolhido.DiariaAdulto) + (QntCriancas* QuartoEscolhido.DiariaCrianca) * Estadia);
        }


    }
}
