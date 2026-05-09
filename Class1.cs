using System;

namespace CalculadoraUniversitaria.Core
{
    public enum SituacaoAluno
    {
        AprovadoDireto,
        Exame,
        AprovadoNoExame,
        Reprovado
    }

    // Obtenção e definição das médias ----------------------------------------------------------
    public class ResultadoSemestre
    {
        public double MediaSemestral { get; set; }
        public SituacaoAluno Situacao { get; set; }
        public double NotaNecessariaExame { get; set; }
    }

    public class ResultadoExame
    {
        public double MediaFinal { get; set; }
        public SituacaoAluno Situacao { get; set; }
    }

    // Classe de lógica de cálculo de notas ---------------------------------------------------
    public class CalculadoraDeNotas
    {
        public static ResultadoSemestre CalcularSemestre(double np1, double np2, double pim)
        {
            ValidarNota(np1, "NP1");
            ValidarNota(np2, "NP2");
            ValidarNota(pim, "PIM");

            double media = ((np1 * 4) + (np2 * 4) + (pim * 2)) / 10.0;

            var resultado = new ResultadoSemestre();
            resultado.MediaSemestral = media;

            if (media >= 7.0)
            {
                resultado.Situacao = SituacaoAluno.AprovadoDireto;
                resultado.NotaNecessariaExame = 0;
            }
            else
            {
                resultado.Situacao = SituacaoAluno.Exame;
                resultado.NotaNecessariaExame = 10.0 - media;
            }

            return resultado;
        }
        public static ResultadoExame CalcularExame(double mediaSemestral, double notaExame)
        {
            ValidarNota(notaExame, "Exame");

            double mediaFinal = (mediaSemestral + notaExame) / 2.0;

            var resultado = new ResultadoExame();
            resultado.MediaFinal = mediaFinal;

            if (mediaFinal >= 5.0)
            {
                resultado.Situacao = SituacaoAluno.AprovadoNoExame;
            }
            else
            {
                resultado.Situacao = SituacaoAluno.Reprovado;
            }

            return resultado;
        }
        public static void ValidarNota(double nota, string nomeAvaliacao)
        {
            if (nota < 0.0 || nota > 10.0)
            {
                throw new ArgumentOutOfRangeException(nomeAvaliacao, "A nota deve estar entre 0 e 10.");
            }
        }
    }
}