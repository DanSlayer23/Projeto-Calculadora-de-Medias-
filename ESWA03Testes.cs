using CalculadoraUniversitaria.Core;
using System;
using Xunit;

// teste para validação do sistema ---------------------------------------------------------------------
namespace CalculadoraUniversitaria.Tests
{
    public class CalculadoraDeNotasTests
    {
        [Fact]
        public void TestingCalculadoraDeNotas_CalcularSemestre_AreEqual_RF001()
        {
            var resultado = CalculadoraDeNotas.CalcularSemestre(8.0, 7.0, 8.0);

            Assert.Equal(7.6, resultado.MediaSemestral);
            Assert.Equal(SituacaoAluno.AprovadoDireto, resultado.Situacao);
            Assert.Equal(0, resultado.NotaNecessariaExame);
        }

        [Fact]
        public void TestingCalculadoraDeNotas_CalcularSemestre_AreEqual_RF002()
        {
            var resultado = CalculadoraDeNotas.CalcularSemestre(5.0, 5.0, 5.0);

            Assert.Equal(5.0, resultado.MediaSemestral);
            Assert.Equal(SituacaoAluno.Exame, resultado.Situacao);
            Assert.Equal(5.0, resultado.NotaNecessariaExame);
        }

        [Fact]
        public void TestingCalculadoraDeNotas_CalcularExame_AreEqual_RF003()
        {
            var resultado = CalculadoraDeNotas.CalcularExame(5.0, 6.0);

            Assert.Equal(5.5, resultado.MediaFinal);
            Assert.Equal(SituacaoAluno.AprovadoNoExame, resultado.Situacao);
        }

        [Fact]
        public void TestingCalculadoraDeNotas_CalcularExame_AreEqual_RF004()
        {
            var resultado = CalculadoraDeNotas.CalcularExame(4.0, 4.0);

            Assert.Equal(4.0, resultado.MediaFinal);
            Assert.Equal(SituacaoAluno.Reprovado, resultado.Situacao);
        }

        [Theory]
        [InlineData(-1.0)]
        [InlineData(-0.1)]
        [InlineData(10.1)]
        [InlineData(15.0)]
        public void TestingCalculadoraDeNotas_ValidarNota_ThrowsException_RNF001(double nota)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                CalculadoraDeNotas.ValidarNota(nota, "Teste")
            );
        }
    }
}
