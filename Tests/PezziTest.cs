using System;
using System.Linq;
using Scacchi.Modello.Pezzi;
using Xunit;

namespace Scacchi.Modello
{
    public class PezziTest
    {
/*--------------------------------------PEDONE------------------------------------------ */
        [Fact]
        public void IlPedoneBiancoPuoMuovereAvantiDiUnaCasa()
        {
            //Given
            Pedone pedone = new Pedone(Colore.Bianco);
            //When
            bool esito = pedone.PuòMuovere(
                    colonnaPartenza: Colonna.A,
                    traversaPartenza: Traversa.Seconda,
                    colonnaArrivo: Colonna.A,
                    traversaArrivo: Traversa.Terza);

            //Then
            Assert.True(esito);
        }


        [Theory]
        [InlineData(typeof(Donna))]
        [InlineData(typeof(Pedone))]
        [InlineData(typeof(Cavallo))]
        [InlineData(typeof(Alfiere))]
        [InlineData(typeof(Re))]
        [InlineData(typeof(Torre))]
        public void IPezziNonPossonoRestareFermi(Type t) {
            //Given
            IPezzo pezzo = Activator.CreateInstance(t, Colore.Bianco) as IPezzo;
            //When
            bool esito = pezzo.PuòMuovere(Colonna.A, Traversa.Prima, Colonna.A, Traversa.Prima);
            //Then
            Assert.False(esito, t.Name);
        }
        [Fact]
        public void IlPedoneBiancoNonPuoMuovereIndietroDiUnaCasa(){
            //Given
            Pedone pedone = new Pedone(Colore.Bianco);
            //When
            bool esito = pedone.PuòMuovere(
                colonnaPartenza: Colonna.A,
                traversaPartenza: Traversa.Settima,
                colonnaArrivo: Colonna.A,
                traversaArrivo: Traversa.Sesta);
            //Then
            Assert.False(esito);
        }

        [Fact]
        public void IlPedoneNeroNonPuoMuovereIndietroDiUnaCasa(){
            //Given
            Pedone pedone = new Pedone(Colore.Nero);
            //When
            bool esito = pedone.PuòMuovere(
                colonnaPartenza: Colonna.A,
                traversaPartenza: Traversa.Terza,
                colonnaArrivo: Colonna.A,
                traversaArrivo: Traversa.Quarta);
            //Then
            Assert.False(esito);
        }

        [Fact]
        public void IlPedoneBiancoPuoMuovereAvantiDiDueCaseDallaSecondaTravers(){
            //Given
            Pedone pedone = new Pedone(Colore.Bianco);
            //When
            bool esito = pedone.PuòMuovere(
                colonnaPartenza: Colonna.A,
                traversaPartenza: Traversa.Seconda,
                colonnaArrivo: Colonna.A,
                traversaArrivo: Traversa.Quarta);
            //Then
            Assert.True(esito);
        }

        [Fact]
        public void IlPedoneNeroPuoMuovereAvantiDiDueCaseDallaSettimaTravers(){
            //Given
            Pedone pedone = new Pedone(Colore.Nero);
            //When
            bool esito = pedone.PuòMuovere(
                colonnaPartenza: Colonna.A,
                traversaPartenza: Traversa.Settima,
                colonnaArrivo: Colonna.A,
                traversaArrivo: Traversa.Quinta);
            //Then
            Assert.True(esito);
        }


/*--------------------------------------------TORRE--------------------------------------- */
        [Theory]
        [InlineData(Colore.Bianco)]
        [InlineData(Colore.Nero)]
        public void LaTorrePuoMuovereInVerticale(Colore colore){
            //Given
            Torre torre = new Torre(colore);
            //When
            bool esito = torre.PuòMuovere(
                colonnaPartenza: Colonna.A,
                traversaPartenza: Traversa.Prima,
                colonnaArrivo: Colonna.A,
                traversaArrivo: Traversa.Sesta);
            //Then
            Assert.True(esito);

        }
        [Theory]
        [InlineData(Colore.Bianco)]
        [InlineData(Colore.Nero)]
        public void LaTorrePuoMuovereInOrizzontale(Colore colore){
            //Given
            Torre torre = new Torre(colore);
            //When
            bool esito = torre.PuòMuovere(
                colonnaPartenza: Colonna.A,
                traversaPartenza: Traversa.Prima,
                colonnaArrivo: Colonna.F,
                traversaArrivo: Traversa.Prima);
            //Then
            Assert.True(esito);
        }
        [Theory]
        [InlineData(Colore.Bianco)]
        [InlineData(Colore.Nero)]
        public void LaTorreNonPuoMuovereInDiagonale(Colore colore){
            //Given
            Torre torre = new Torre(colore);
            //When
            bool esito = torre.PuòMuovere(
                colonnaPartenza: Colonna.A,
                traversaPartenza: Traversa.Prima,
                colonnaArrivo: Colonna.F,
                traversaArrivo: Traversa.Quarta);
            //Then
            Assert.False(esito);
        }
/*--------------------------------------ALFIERE------------------------------- */
        [Theory]
        [InlineData(Colore.Bianco)]
        [InlineData(Colore.Nero)]
        public void LAlfierePuoMuovereInDiagonale(Colore colore){
                //Given
                Alfiere alfiere = new Alfiere(colore);
                //When
                bool esito = alfiere.PuòMuovere(
                    colonnaPartenza: Colonna.A,
                    traversaPartenza: Traversa.Prima,
                    colonnaArrivo: Colonna.F,
                    traversaArrivo: Traversa.Sesta);
                //Then
                Assert.True(esito);
        }
        [Theory]
        [InlineData(Colore.Bianco)]
        [InlineData(Colore.Nero)]
        public void LAlfierePuoMuovereSoloInDiagonale(Colore colore){
                //Given
                Alfiere alfiere = new Alfiere(colore);
                //When
                bool esito = alfiere.PuòMuovere(
                    colonnaPartenza: Colonna.F,
                    traversaPartenza: Traversa.Ottava,
                    colonnaArrivo: Colonna.C,
                    traversaArrivo: Traversa.Quarta);
                //Then
                Assert.False(esito);
        }

/*--------------------------------CAVALLO---------------------------------------- */

        [Theory]
        [InlineData(Colore.Bianco)]
        [InlineData(Colore.Nero)]
        public void IlCavalloPuoMuovereAdL(Colore colore){
                //Given
                Cavallo cavallo = new Cavallo(colore);
                //When
                bool esito = cavallo.PuòMuovere(
                    colonnaPartenza: Colonna.B,
                    traversaPartenza: Traversa.Prima,
                    colonnaArrivo: Colonna.A,
                    traversaArrivo: Traversa.Terza);
                //Then
                Assert.True(esito);
        }

        [Theory]
        [InlineData(Colore.Bianco)]
        [InlineData(Colore.Nero)]
        public void IlCavalloPuoMuovereSoloAdL(Colore colore){
                //Given
                Cavallo cavallo = new Cavallo(colore);
                //When
                bool esito = cavallo.PuòMuovere(
                    colonnaPartenza: Colonna.G,
                    traversaPartenza: Traversa.Ottava,
                    colonnaArrivo: Colonna.E,
                    traversaArrivo: Traversa.Sesta);
                //Then
                Assert.False(esito);
        }
/*------------------------------------Donna-------------------------------------- */
        [Theory]
        [InlineData(Colore.Bianco)]
        [InlineData(Colore.Nero)]
        public void LaDonnaPuoMuovereInVerticale(Colore colore){
            //Given
            Donna donna = new Donna(colore);
            //When
            bool esito = donna.PuòMuovere(
                colonnaPartenza: Colonna.A,
                traversaPartenza: Traversa.Prima,
                colonnaArrivo: Colonna.A,
                traversaArrivo: Traversa.Sesta);
            //Then
            Assert.True(esito);

        }
        [Theory]
        [InlineData(Colore.Bianco)]
        [InlineData(Colore.Nero)]
        public void LaDonnaPuoMuovereInOrizzontale(Colore colore){
            //Given
            Donna donna = new Donna(colore);
            //When
            bool esito = donna.PuòMuovere(
                colonnaPartenza: Colonna.A,
                traversaPartenza: Traversa.Prima,
                colonnaArrivo: Colonna.F,
                traversaArrivo: Traversa.Prima);
            //Then
            Assert.True(esito);
        }

        [Theory]
        [InlineData(Colore.Bianco)]
        [InlineData(Colore.Nero)]
        public void LaDonnaPuoMuovereInDiagonale(Colore colore){
                //Given
            Donna donna = new Donna(colore);
            //When
            bool esito = donna.PuòMuovere(
                    colonnaPartenza: Colonna.A,
                    traversaPartenza: Traversa.Prima,
                    colonnaArrivo: Colonna.F,
                    traversaArrivo: Traversa.Sesta);
                //Then
                Assert.True(esito);
        }

        [Theory]
        [InlineData(Colore.Bianco)]
        [InlineData(Colore.Nero)]
        public void LaDonnaPuoMuovereSoloInDiagonaleOrizzontaleVerticale(Colore colore){
                //Given
                Donna donna = new Donna(colore);
                //When
                bool esito = donna.PuòMuovere(
                    colonnaPartenza: Colonna.F,
                    traversaPartenza: Traversa.Ottava,
                    colonnaArrivo: Colonna.C,
                    traversaArrivo: Traversa.Quarta);
                //Then
                Assert.False(esito);
        }

/*-----------------------------------------RE--------------------------------------------- */
        [Theory]
        [InlineData(Colore.Bianco)]
        [InlineData(Colore.Nero)]
        public void IlRePuoMuovereInVerticaleDiUno(Colore colore){
            //Given
            Re re = new Re(colore);
            //When
            bool esito = re.PuòMuovere(
                colonnaPartenza: Colonna.A,
                traversaPartenza: Traversa.Prima,
                colonnaArrivo: Colonna.A,
                traversaArrivo: Traversa.Seconda);
            //Then
            Assert.True(esito);

        }
        [Theory]
        [InlineData(Colore.Bianco)]
        [InlineData(Colore.Nero)]
        public void IlRePuoMuovereInOrizzontaleDiUno(Colore colore){
            //Given
            Re re = new Re(colore);
            //When
            bool esito = re.PuòMuovere(
                colonnaPartenza: Colonna.A,
                traversaPartenza: Traversa.Prima,
                colonnaArrivo: Colonna.B,
                traversaArrivo: Traversa.Prima);
            //Then
            Assert.True(esito);
        }

        [Theory]
        [InlineData(Colore.Bianco)]
        [InlineData(Colore.Nero)]
        public void IlRePuoMuovereInDiagonaleDiUno(Colore colore){
            //Given
            Re re = new Re(colore);
            //When
            bool esito = re.PuòMuovere(
                    colonnaPartenza: Colonna.A,
                    traversaPartenza: Traversa.Prima,
                    colonnaArrivo: Colonna.B,
                    traversaArrivo: Traversa.Seconda);
                //Then
                Assert.True(esito);
        }

        [Theory]
        [InlineData(Colore.Bianco)]
        [InlineData(Colore.Nero)]
        public void IlRePuoMuovereSoloDiUno(Colore colore){
            //Given
            Re re = new Re(colore);
            //When
            bool esito = re.PuòMuovere(
                    colonnaPartenza: Colonna.F,
                    traversaPartenza: Traversa.Ottava,
                    colonnaArrivo: Colonna.C,
                    traversaArrivo: Traversa.Quarta);
                //Then
                Assert.False(esito);
        }

    }
}